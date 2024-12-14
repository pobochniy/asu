import {ChangeDetectorRef, Component, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { UserService } from '../../shared/core/user.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';
import { epicFormModel } from '../../shared/form-models/epic-form.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import {TimeTrackingModel} from "../../shared/models/time-tracking.model";
import {TimeTrackingPopupComponent} from "../../shared/time-tracking-popup/time-tracking-popup.component";

@Component({
  selector: 'edit-epic',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [EpicApiService]
})
export class EditComponent implements OnInit {

  @ViewChild(TimeTrackingPopupComponent) timePopup!: TimeTrackingPopupComponent;
  public epicForm = epicFormModel;
  public profiles: UserProfileModel[] = [];
  public epicPriority: { id: number; name: string }[] = [];
  public roles = UserRoleEnum;

  public get EpicId() {
    return this.epicForm?.controls['id']?.value || 0;
  }

  constructor(private service: EpicApiService
    , private userApiService: UsersApiService
    , private router: Router
    , private route: ActivatedRoute
    , private cdRef: ChangeDetectorRef
    , public userService: UserService
  ) { }

  async ngOnInit() {
    this.profiles = await this.userApiService.GetProfiles() || [];

    for (var n in IssuePriorityEnum) {
      if (typeof IssuePriorityEnum[n] === 'number') {
        this.epicPriority.push({ id: <any>IssuePriorityEnum[n], name: n });
      }
    }

    const id = +(this.route.snapshot.paramMap.get('id') || 0);
    if (id) {
      this.epicForm.patchValue({['id']: id});
    }

    if (!this.epicForm.value['id'] || this.epicForm.value['id'] == 0) {
      this.storageRestore();
    } else {
      const epic = await this.service.Details(id);

      this.epicForm.setValue({
        id: epic.id
        , assignee: epic.assignee
        , reporter: epic.reporter
        , priority: epic.priority
        , name: epic.name
        , description: epic.description
        , dueDate: epic.dueDate ? epic.dueDate?.substr(0, 10) : new Date()
      });
    }

    this.cdRef.detectChanges();
  }

  async onSubmit() {
    Object.keys(this.epicForm.controls).forEach(key => {
      this.epicForm.get(key)?.markAsDirty();
    });

    try {
      if (this.epicForm.valid) {
        if (this.epicForm.value['id'] || 0 > 0) {
          await this.service.Update(this.epicForm);
        }
        else {
          this.storageSave();
          await this.service.Create(this.epicForm);
        }

        await this.router.navigateByUrl('/epic/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }

  storageSave() {
    localStorage.setItem('epic-last-assignee', this.epicForm.controls["assignee"].value || "");
    localStorage.setItem('epic-last-reporter', this.epicForm.controls["reporter"].value || "");
  }

  storageRestore() {
    this.getStorageValue('assignee');
    this.getStorageValue('reporter');
  }

  getStorageValue(name: string, fieldtype: string = 'string') {
    const strVal = localStorage.getItem(`epic-last-${name}`);
    const val = fieldtype == 'number' ? +(strVal || 0) : strVal;
    if (val) {
      this.epicForm.patchValue({[name]: val});
      this.cdRef.detectChanges();
    }
  }

  public showTimeTrack() {
    if (this.EpicId == 0) return;

    const model = new TimeTrackingModel();
    model.epicId = this.EpicId;
    model.issueEpicName = this.epicForm?.controls['name']?.value || "";
    this.timePopup.show(model).subscribe((x: any) => {
    });
  }
}


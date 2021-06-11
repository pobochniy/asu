import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { UserService } from '../../shared/core/user.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';
import { epicFormModel } from '../../shared/form-models/epic-form.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';

@Component({
  selector: 'edit-epic',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [EpicApiService]
})
export class EditComponent implements OnInit {

  public epicForm = epicFormModel;
  public profiles: UserProfileModel[];
  public epicPriority: { id: number; name: string }[] = [];
  public roles = UserRoleEnum;

  constructor(private service: EpicApiService
    , private userApiService: UsersApiService
    , private router: Router
    , private route: ActivatedRoute
    , private cdRef: ChangeDetectorRef
    , public userService: UserService
  ) { }

  async ngOnInit() {
    this.profiles = await this.userApiService.GetProfiles();

    for (var n in IssuePriorityEnum) {
      if (typeof IssuePriorityEnum[n] === 'number') {
        this.epicPriority.push({ id: <any>IssuePriorityEnum[n], name: n });
      }
    }

    const id = +this.route.snapshot.paramMap.get('id');

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

    if (this.epicForm.value['id'] == 0) this.storageRestore();

    this.cdRef.detectChanges()
  }

  async onSubmit() {
    for (let item in this.epicForm.controls) {
      this.epicForm.controls[item].markAsDirty();
    }

    try {
      if (this.epicForm.valid) {
        if (this.epicForm.value['id'] || 0 > 0) {
          await this.service.Update(this.epicForm);
        }
        else {
          this.storageSave();
          await this.service.Create(this.epicForm);
        }

        this.router.navigateByUrl('/epic/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }

  storageSave() {
    localStorage.setItem('epic-last-assignee', this.epicForm.controls["assignee"].value);
    localStorage.setItem('epic-last-reporter', this.epicForm.controls["reporter"].value);
  }

  storageRestore() {
    this.getStorageValue('assignee');
    this.getStorageValue('reporter');
  }

  getStorageValue(name: string, fieldtype: string = 'string') {
    const strVal = localStorage.getItem(`epic-last-${name}`);
    const val = fieldtype == 'number' ? +strVal : strVal;
    if (val) this.epicForm.controls[name].setValue(val);
  }
}


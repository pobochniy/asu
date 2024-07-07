import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { UserService } from '../../shared/core/user.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { IssueTypeEnum } from '../../shared/enums/issue-type.enum';
import { SizeEnum } from '../../shared/enums/size.enum';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';
import { issueFormModel } from '../../shared/form-models/issue-form.model';
import { EpicModel } from '../../shared/models/epic.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';

@Component({
  selector: 'edit-issue',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [IssueApiService, EpicApiService]
})
export class EditComponent implements OnInit {

  public issueForm = issueFormModel;
  public profiles: UserProfileModel[] = [];
  public epics: EpicModel[] = [];
  public issueTypes: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string }[] = [];
  public issueSize: { id: number; name: string }[] = [];
  public SizeType = SizeEnum;
  public roles = UserRoleEnum;

  public getCheckedType(val: number): boolean {
    //console.log(val, this.issueForm.controls['type'].value, (this.issueForm.controls['type'].value || 0) == val);
    return (this.issueForm.controls['type'].value || 0) == val;
  }

  constructor(private service: IssueApiService
    , private userApiService: UsersApiService
    , private epicApiService: EpicApiService
    , private router: Router
    , private route: ActivatedRoute
    , private cdRef: ChangeDetectorRef
    , public userService: UserService
  ) { }

  async ngOnInit() {

    this.profiles = await this.userApiService.GetProfiles() || [];
    this.epics = await this.epicApiService.GetList() || [];

    const id = +(this.route.snapshot.paramMap.get('id') || 0);

    const issue = await this.service.Details(id);

    this.cdRef.detectChanges()

    this.issueForm.setValue({
      id: issue.id
      , assignee: issue.assignee
      , reporter: issue.reporter
      , summary: issue.summary
      , description: issue.description
      , type: issue.type
      , status: issue.status
      , priority: issue.priority
      , estimatedTime: issue.estimatedTime
      , size: issue.size
      , dueDate: issue.dueDate ? issue.dueDate?.substr(0, 10) : new Date()
      , epicLink: issue.epicLink
    });

    //console.log('ngOnInit', this.issueForm.controls['type'].value);
    for (var n in IssueTypeEnum) {
      if (typeof IssueTypeEnum[n] === 'number') {
        this.issueTypes.push({ id: <any>IssueTypeEnum[n], name: n });
      }
    }

    for (var n in IssuePriorityEnum) {
      if (typeof IssuePriorityEnum[n] === 'number') {
        this.issuePriority.push({ id: <any>IssuePriorityEnum[n], name: n });
      }
    }

    for (var n in SizeEnum) {
      if (typeof SizeEnum[n] === 'number') {
        this.issueSize.push({ id: <any>SizeEnum[n], name: n });
      }
    }

    if (!this.issueForm.value.id) this.storageRestore();
  }

  async onSubmit() {
    Object.keys(this.issueForm.controls).forEach(key => {
      this.issueForm.get(key)?.markAsDirty();
    });

    try {
      if (this.issueForm.valid) {
        if (this.issueForm.value['id'] || 0 > 0) {
          await this.service.Update(this.issueForm);
        }
        else {
          this.storageSave();
          await this.service.Create(this.issueForm);
        }

        this.router.navigateByUrl('/issue/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }

  storageSave() {
    localStorage.setItem('issue-last-assignee', this.issueForm.value.assignee || '');
    localStorage.setItem('issue-last-reporter', this.issueForm.value.reporter || '');
    localStorage.setItem('issue-last-type', this.issueForm.value.type || '');
  }

  storageRestore() {
    this.getStorageValue('assignee');
    this.getStorageValue('reporter');
    this.getStorageValue('type', 'number');
  }

  getStorageValue(name: string, fieldtype: string = 'string') {
    const strVal = localStorage.getItem(`issue-last-${name}`);
    const val = fieldtype == 'number' ? +(strVal || 0) : strVal;
    if (val) this.issueForm.patchValue({[name]: val});
  }
}


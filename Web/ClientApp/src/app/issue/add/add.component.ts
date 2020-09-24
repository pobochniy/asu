import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { IssueStatusEnum } from '../../shared/enums/issue-status.enum';
import { IssueTypeEnum } from '../../shared/enums/issue-type.enum';
import { issueFormModel } from '../../shared/form-models/issue-form.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { SizeEnum } from '../../shared/enums/size.enum';
import { EpicModel } from '../../shared/models/epic.model';
import { EpicApiService } from '../../shared/api/epic-api.service';

@Component({
  selector: 'add-issue',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
  providers: [IssueApiService, UsersApiService, EpicApiService]
})
export class AddComponent implements OnInit {

  public issueForm = issueFormModel;
  public profiles: UserProfileModel[];
  public epics: EpicModel[];
  public issueTypes: { id: number; name: string }[] = [];
  public issueStatus: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string }[] = [];
  public issueSize: { id: number; name: string }[] = [];
  public SizeType = SizeEnum;

  public get getCheckedType(): number {
    return this.issueForm.controls['type'].value;
  }

  constructor(private service: IssueApiService
    , private userApiService: UsersApiService
    , private epicApiService: EpicApiService
    , private router: Router
  ) { }

  async ngOnInit() {
    this.profiles = await this.userApiService.GetProfiles();
    this.epics = await this.epicApiService.GetList();

    for (var n in IssueTypeEnum) {
      if (typeof IssueTypeEnum[n] === 'number') {
        this.issueTypes.push({ id: <any>IssueTypeEnum[n], name: n });
      }
    }

    for (var n in IssueStatusEnum) {
      if (typeof IssueStatusEnum[n] === 'number') {
        this.issueStatus.push({ id: <any>IssueStatusEnum[n], name: n });
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

    this.storageRestore();
  }

  async onSubmit() {
    for (let item in this.issueForm.controls) {
      this.issueForm.controls[item].markAsDirty();
    }

    this.storageSave();
    try {
      if (this.issueForm.valid) {
        let epicId = await this.service.Create(this.issueForm);
        this.router.navigateByUrl('/issue/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }

  storageSave() {
    localStorage.setItem('issue-last-assignee', this.issueForm.controls["assignee"].value);
    localStorage.setItem('issue-last-reporter', this.issueForm.controls["reporter"].value);
    localStorage.setItem('issue-last-type', this.issueForm.controls["type"].value);
  }

  storageRestore() {
    this.getStorageValue('assignee');
    this.getStorageValue('reporter');
    this.getStorageValue('type', 'number');
  }

  getStorageValue(name: string, fieldtype: string = 'string') {
    const strVal = localStorage.getItem(`issue-last-${name}`);
    const val = fieldtype == 'number' ? +strVal : strVal;
    if (val) this.issueForm.controls[name].setValue(val);
  }
}


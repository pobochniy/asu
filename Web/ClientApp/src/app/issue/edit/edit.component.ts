import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { issueFormModel } from '../../shared/form-models/issue-form.model';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssueStatusEnum } from '../../shared/enums/issue-status.enum';
import { IssueTypeEnum } from '../../shared/enums/issue-type.enum';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [IssueApiService]
})
export class EditComponent implements OnInit {

  public issueForm = issueFormModel;
  public profiles: UserProfileModel[];
  public issueTypes: { id: number; name: string }[] = [];
  public issueStatus: { id: number; name: string }[] = [];
  public issuePriority: { id: number; name: string }[] = [];

  constructor(private service: IssueApiService
    , private route: ActivatedRoute
    , private userApiService: UsersApiService
    , private router: Router) { }

  async ngOnInit() {

    const id = +this.route.snapshot.paramMap.get('id');

    const issue = await this.service.Details(id);
    debugger;
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

    this.profiles = await this.userApiService.GetProfiles();

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
  }

  async onSubmit() {
    for (let item in this.issueForm.controls) {
      this.issueForm.controls[item].markAsDirty();
    }

    try {
      if (this.issueForm.valid) {
        let issueId = await this.service.Update(this.issueForm);
        this.router.navigateByUrl('/issue/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }
}

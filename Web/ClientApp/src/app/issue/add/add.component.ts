import { Component, OnInit, ViewEncapsulation} from '@angular/core';
import { Router } from '@angular/router';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { IssueModel } from '../../shared/models/issue.model';
import { issueFormModel } from '../../shared/form-models/issue-form.model';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';
import { UsersApiService } from '../../shared/api/users-api.service';
import { UserProfileModel } from '../../shared/models/user-profile.model';
import { IssueTypeEnum } from '../../shared/enums/issue-type.enum';

@Component({
  selector: 'add-issue',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
  providers: [IssueApiService, UsersApiService]
})
export class AddComponent implements OnInit {

  public issueForm = issueFormModel;
  public profiles: UserProfileModel[];
  public issueTypes = IssueTypeEnum;


  constructor(private service: IssueApiService
    , private userApiService: UsersApiService
    , private router: Router
  ) { }

  async ngOnInit() {
    this.profiles = await this.userApiService.GetProfiles();
    var assigneeCtrl = this.issueForm.controls['assignee'];
    var reporterCtrl = this.issueForm.controls['reporter'];
  }

  async onSubmit() {
    for (let item in this.issueForm.controls) {
      this.issueForm.controls[item].markAsDirty();
    }

    try {
      if (this.issueForm.valid) {
        let issueId = await this.service.Create(this.issueForm);
        this.router.navigateByUrl('/issue/list');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }
}


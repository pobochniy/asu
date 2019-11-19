import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IssueApiService } from '../../shared/api/issue-api.service';

import { IssueModel } from '../../shared/models/issue.model';
import { issueFormModel } from '../../shared/form-models/issue-form.model';

@Component({
  selector: 'add-issue',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css'],
  providers: [IssueApiService]
})
export class AddComponent implements OnInit {

  public issueForm = issueFormModel;
  //public dataSource: IssueModel;

  constructor(private service: IssueApiService
    , private router: Router
  ) { }

  async ngOnInit() {
  //  this.dataSource = await this.service.Create();
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

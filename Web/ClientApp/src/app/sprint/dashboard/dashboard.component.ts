import { Component, OnInit } from '@angular/core';
import { IssueModel } from '../../shared/models/issue.model';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { DashboardModel } from '../../shared/models/dashboard.model';
import { GetIssueStatus } from '../../shared/enums/issue-status.enum';

@Component({
  selector: 'sprint-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  providers: [IssueApiService]
})
export class DashboardComponent implements OnInit {

  public dataSource: DashboardModel;

  constructor(private issueService: IssueApiService) {
    this.dataSource = new DashboardModel();
  }

  async ngOnInit() {
    this.dataSource.issues = await this.issueService.GetList();
  }

  public getIssuesByStatus(status: number) {
    return this.dataSource.issues.filter(el => el.status == status);
  }

  public GetIssueStatus(id: number) {
    return GetIssueStatus(id);
  }
}


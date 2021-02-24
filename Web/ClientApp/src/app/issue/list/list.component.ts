import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { IssueModel } from '../../shared/models/issue.model';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssueStatusEnum } from '../../shared/enums/issue-status.enum';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';

@Component({
  selector: 'list-issue',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [IssueApiService]
})
export class ListComponent implements OnInit{

  public dataSource: IssueModel[];
  //public issueStatus: IssueStatusEnum;

  constructor(private service: IssueApiService
    , private userApiService: UsersApiService
    , private router: Router
  ) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();
    //this.profiles = await this.userApiService.GetProfiles();
  }

  GetPriority(id: number) {
    const priority = IssuePriorityEnum[id];
    if (priority) return priority;

    return id;
  }

  GetStatus(id: number) {
    const priority = IssueStatusEnum[id];
    if (priority) return priority;

    return id;
  }
}

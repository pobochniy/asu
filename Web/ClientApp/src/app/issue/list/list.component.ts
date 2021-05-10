import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IssueApiService } from '../../shared/api/issue-api.service';
import { IssueModel } from '../../shared/models/issue.model';
import { UsersApiService } from '../../shared/api/users-api.service';
import { IssueStatusEnum } from '../../shared/enums/issue-status.enum';
import { IssuePriorityEnum } from '../../shared/enums/issue-priority.enum';
import { UserService } from '../../shared/core/user.service';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';

@Component({
  selector: 'list-issue',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [IssueApiService]
})
export class ListComponent implements OnInit{

  public dataSource: IssueModel[];
  public roles = UserRoleEnum;

  constructor(private service: IssueApiService
    , private userApiService: UsersApiService
    , private userService: UserService
    , private router: Router
  ) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();
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

  hasRole(roleId: number): boolean {
    return this.userService.hasRole(roleId);
  }
}

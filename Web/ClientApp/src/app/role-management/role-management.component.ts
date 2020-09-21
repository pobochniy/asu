import { Component, OnInit } from '@angular/core';
import { UserRoleInfoModel } from '../shared/models/user-role-info.model';
import { UserRoleEnum } from '../shared/enums/user-role.enum';

@Component({
  selector: 'app-role-management',
  templateUrl: './role-management.component.html',
  styleUrls: ['./role-management.component.css']
})
export class RoleManagementComponent implements OnInit {

  public UserRoleEnum: typeof UserRoleEnum;
  public roles: [UserRoleInfoModel, boolean][];
  public roleGroups: string[];

  constructor() {
    this.UserRoleEnum = UserRoleEnum
    this.roles = [
      [new UserRoleInfoModel(UserRoleEnum.none, 'Без ролей', 'none'), false],
      [new UserRoleInfoModel(UserRoleEnum.roleManagement, 'Role Management', 'roleManagement'), false],
      [new UserRoleInfoModel(UserRoleEnum.issueRead, 'Просмотр Issue', 'issue'), false],
      [new UserRoleInfoModel(UserRoleEnum.issueCreate, 'Создание Issue', 'issue'), false],
      [new UserRoleInfoModel(UserRoleEnum.issueUpdate, 'Редактирование Issue', 'issue'), false],
      [new UserRoleInfoModel(UserRoleEnum.issueDelete, 'Удаление Issue', 'issue'), false]
    ]

    this.roleGroups = [];
    for (const role of this.roles) {
      if (!this.roleGroups.includes(role[0].groupCode)) {
        this.roleGroups.push(role[0].groupCode);
      }
    }
  }

  ngOnInit() {
  }

  getRolesByGroupCode(group: string): [UserRoleInfoModel, boolean][] {
    let result = [];

    for (const role of this.roles) {
      if (role[0].groupCode == group) {
        result.push(role);
      }
    }

    return result;
  }
}

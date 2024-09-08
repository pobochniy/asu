import { Component, OnInit } from '@angular/core';
import { UsersApiService } from '../shared/api/users-api.service';
import { UserService } from '../shared/core/user.service';
import { UserRoleEnum } from '../shared/enums/user-role.enum';
import { UserProfileModel } from '../shared/models/user-profile.model';
import { UserRoleInfoModel } from '../shared/models/user-role-info.model';

@Component({
  selector: 'app-role-management',
  templateUrl: './role-management.component.html',
  styleUrls: ['./role-management.component.css']
})
export class RoleManagementComponent implements OnInit {

  public roles?: UserRoleInfoModel[];
  public roleGroups: string[] = [];
  public profiles?: UserProfileModel[];
  public userId?: string;
  public userRoles?: number[] = [];
  public roleEnum = UserRoleEnum;

  constructor(
    private service: UsersApiService,
    public userService: UserService
  ) {
  }

  async ngOnInit() {
    this.fillRoles();

    for (const role of this.roles!) {
      if (!this.roleGroups.includes(role.groupCode)) {
        this.roleGroups.push(role.groupCode);
      }
    }

    this.profiles = await this.service.GetProfiles();
  }

  public async userSelected(val: any) {
    this.userRoles = [];

    if (val && this.userId != val) {
      this.userId = val;
      await this.checkRoles();
    }
  }

  public getRolesByGroupCode(group: string): UserRoleInfoModel[] {
    return this.roles!.filter(x => x.groupCode == group);
  }

  public CheckAllOptions(group: string) {
    let checkboxes = this.roles!.filter(x => x.groupCode == group);

    if (checkboxes.every(val => val.checked))
      checkboxes.forEach(val => { val.checked = false });
    else
      checkboxes.forEach(val => { val.checked = true });
  }

  public async saveRoles() {
    const checked = this.roles!.filter(x => x.checked).map(x => x.id);
    await this.service.setUserRoles(this.userId!, checked);
    await this.checkRoles();
  }

  private async checkRoles() {
    this.userRoles = await this.service.getUserRoles(this.userId!);
    this.roles!.forEach(x=> { x.checked = this.userRoles!.includes(x.id) });
  }

  private fillRoles() {
    this.roles = [
      new UserRoleInfoModel(UserRoleEnum.roleManagement, 'Role Management', 'roleManagement'),

      new UserRoleInfoModel(UserRoleEnum.issueRead, 'Просмотр Issue', 'issue'),
      new UserRoleInfoModel(UserRoleEnum.issueCrud, 'Редактирование, содание, удаление Issue', 'issue'),

      new UserRoleInfoModel(UserRoleEnum.epicRead, 'Просмотр Epic', 'epic'),
      new UserRoleInfoModel(UserRoleEnum.epicCrud, 'Редактирование, содание, удаление Epic', 'epic'),

      new UserRoleInfoModel(UserRoleEnum.sprintRead, 'Просмотр Sprint', 'sprint'),
      new UserRoleInfoModel(UserRoleEnum.sprintCrud, 'Редактирование, содание, удаление Sprint', 'sprint'),

      new UserRoleInfoModel(UserRoleEnum.hourlyPayRead, 'Просмотр ставок', 'hourlyPay'),
      new UserRoleInfoModel(UserRoleEnum.hourlyPayCrud, 'Редактирование ставок', 'hourlyPay'),

      new UserRoleInfoModel(UserRoleEnum.finPeriodRead, 'Просмотр финансовых периодов', 'finPeriod'),
      new UserRoleInfoModel(UserRoleEnum.finPeriodEdit, 'Редактирование финансовых периодов', 'finPeriod'),
    ]
  }

}

import { UserRoleEnum } from "../enums/user-role.enum";

/** User Role Info */
export class UserRoleInfoModel {
  /** enum */
  public id: UserRoleEnum;

  /** Описание */
  public summary: string;

  /** Категория */
  public groupCode: string;

  /** Присутствует у пользователя */
  public checked: boolean;

  constructor(id: UserRoleEnum, summary: string, groupCode: string) {
    this.id = id;
    this.summary = summary;
    this.groupCode = groupCode;
    this.checked = false;
  }
}

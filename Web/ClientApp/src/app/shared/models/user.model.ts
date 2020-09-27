import { UserProfileModel } from "./user-profile.model";

/** Пользователь */
export class UserModel extends UserProfileModel {

  /** Список ролей */
  public roles: string[];

  hasRole(roleName: string): boolean {
    if (this.roles == null) return false;

    return this.roles.indexOf(roleName) > -1;
  }
}

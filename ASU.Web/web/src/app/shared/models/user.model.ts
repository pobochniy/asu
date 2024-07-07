import { UserProfileModel } from "./user-profile.model";

/** Пользователь */
export class UserModel extends UserProfileModel {

  /** Список ролей */
  public roles: number[] = [];

}

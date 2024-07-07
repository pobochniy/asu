import { Injectable } from '@angular/core';
import { UserModel } from '../models/user.model';

@Injectable()
export class UserService {

  private _user?: UserModel = undefined;

  public get User(): UserModel | undefined {
    if (this._user != null) return this._user;

    const usr = localStorage.getItem('user');
    if (usr != null) this._user = JSON.parse(usr) as UserModel;

    return this._user;
  };

  public set User(val: UserModel | undefined) {
    if (val == undefined) localStorage.removeItem('user');
    else localStorage.setItem('user', JSON.stringify(val));

    this._user = val;
  }

  constructor(
  ) {
  }

  get isAuth(): boolean {
    return this.User != null && this.User.userName != null;
  }

  // TODO: нужен перезаход при изменении доступных, возможно обновить пользователя в сервисе после role-management
  hasRole(roleId: number): boolean {
    if (!this.isAuth || this.User?.roles == null)
      return false;

    return this.User.roles.indexOf(roleId) > -1;
  }

  //async logOut() {
  //  this.User = null;
  //  await this.authServ.logOut();
  //  this.router.navigateByUrl('/');
  //}
}

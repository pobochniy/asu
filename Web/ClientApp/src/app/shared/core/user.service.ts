import { Injectable } from '@angular/core';
//import { Router } from '@angular/router';
import { UserModel } from '../models/user.model';
//import { AuthService } from '../api/auth.service';

@Injectable()
export class UserService {

  private _user: UserModel = null;

  public get User(): UserModel {
    if (this._user != null) return this._user;

    const usr = localStorage.getItem('user');
    if (usr != null) this._user = JSON.parse(usr) as UserModel;

    return this._user;
  };

  public set User(val: UserModel) {
    if (val == null) localStorage.removeItem('user');
    else localStorage.setItem('user', JSON.stringify(val));

    this._user = val;
  }

  constructor(
    //private authServ: AuthService
    //,
    //  private router: Router
  ) {
  }

  get shortName(): string {
    if (!this.User) return '';
    return this.User.login || this.User.email || this.User.phone;
  }

  get isAuth(): boolean {
    return this.User != null && this.User.login != null;
  }

  hasRole(roleName: string): boolean {
    if (this.User == null || this.User.roles == null) return false;

    return this.User.roles.indexOf(roleName) > -1;
  }

  //async logOut() {
  //  this.User = null;
  //  await this.authServ.logOut();
  //  this.router.navigateByUrl('/');
  //}
}

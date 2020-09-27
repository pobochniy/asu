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
  ) {
  }

  get isAuth(): boolean {
    return this.User != null && this.User.userName != null;
  }

  //async logOut() {
  //  this.User = null;
  //  await this.authServ.logOut();
  //  this.router.navigateByUrl('/');
  //}
}

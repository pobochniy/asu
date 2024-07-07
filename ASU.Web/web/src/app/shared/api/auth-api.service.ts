import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UserModel } from '../models/user.model';
import { BaseApiService } from "./base-api.service";

@Injectable()
export class AuthApiService extends BaseApiService {
  constructor(http: HttpClient) {
    super('Auth', http)
  }

  public async register(model: FormGroup) {
    return this.post<UserModel>('Register', model.value).toPromise();
  }

  public async login(model: FormGroup) {
    return this.post<UserModel>('Login', model.value).toPromise();
  }

  public async logOut() {
    return this.post<void>('LogOut', {}).toPromise();
  }
}

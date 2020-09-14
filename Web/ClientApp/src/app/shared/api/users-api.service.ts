import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UserModel } from '../models/user.model';
import { BaseApiService } from "./base-api.service";
import { UserProfileModel } from "../models/user-profile.model";


@Injectable()
export class UsersApiService extends BaseApiService {
  constructor(public http: HttpClient) {
    super('Users', http)
  }

  public async GetProfiles() {
    return this.get<UserProfileModel[]>('GetProfiles').toPromise();
  }

  public async getUserRoles(userId: string) {
    return this.get<number[]>('GetRoles?userId=' + userId).toPromise();
  }

  public async setUserRoles(userId: string, roles: number[]) {
    return this.post('SetRoles', { userId: userId, roles: roles }).toPromise();
  }
}

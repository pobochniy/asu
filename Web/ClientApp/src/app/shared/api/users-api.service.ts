import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { UserProfileModel } from "../models/user-profile.model";
import { BaseApiService } from "./base-api.service";


@Injectable()
export class UsersApiService extends BaseApiService {
  private storage: UserProfileModel[] = null;

  constructor(public http: HttpClient) {
    super('Users', http);
  }

  public async GetProfiles() {
    if (!this.storage) {
      this.storage = (await this.get<any[]>('GetProfiles').toPromise()).map(x => new UserProfileModel(x));
    }

    return this.storage;
  }

  public async getUser(userId: string) {
    const profiles = await this.GetProfiles();
    return profiles.find(x => x.id == userId) || new UserProfileModel();
  }

  public async getUserRoles(userId: string) {
    return this.get<number[]>('GetRoles?userId=' + userId).toPromise();
  }

  public async setUserRoles(userId: string, roles: number[]) {
    return this.post('SetRoles', { userId: userId, roles: roles }).toPromise();
  }
}

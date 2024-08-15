import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { TimeTrackingModel, IUserTracking } from "../models/time-tracking.model";
import { BaseApiService } from './base-api.service';
import {FormGroup} from "@angular/forms";

@Injectable()
export class TimeTrackingApiService extends BaseApiService {

  constructor(http: HttpClient) { super('TimeTracking', http) }

  public async Details() {
    return this.get<TimeTrackingModel>('Details').toPromise();
  }

  public async Create(model: FormGroup) {
    return this.post<TimeTrackingModel>('Create', model.value).toPromise();
  }

  public async UserTracking() {
    return this.get<IUserTracking[]>('UserTracking').toPromise();
  }
}

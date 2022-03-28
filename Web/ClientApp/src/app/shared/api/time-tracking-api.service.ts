import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { TimeTrackingModel } from "../models/time-tracking.model";
import { BaseApiService } from './base-api.service';

@Injectable()
export class TimeTrackingApiService extends BaseApiService {

  constructor(public http: HttpClient) { super('TimeTracking', http) }

  public async Details() {
    return this.get<TimeTrackingModel>('Details').toPromise();
  }

  public async Create(model: TimeTrackingModel) {
    return this.post<TimeTrackingModel>('Create', model).toPromise();
  }
}

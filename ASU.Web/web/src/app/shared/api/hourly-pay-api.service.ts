import {HttpClient} from "@angular/common/http";
import {Injectable} from '@angular/core';
import {FormGroup} from '@angular/forms';
import {BaseApiService} from "./base-api.service";
import {HourlyPayModel} from "../models/hourly-pay.model";


@Injectable()
export class HourlyPayApiService extends BaseApiService {
  constructor(http: HttpClient) {
    super('HourlyPay', http)
  }

  public async GetList(userId: string) {
    return this.get<HourlyPayModel[]>(`GetList?userId=${userId}`).toPromise();
  }

  public async Create(model: FormGroup) {
    return this.post<number>('Create', model.value).toPromise();
  }
}

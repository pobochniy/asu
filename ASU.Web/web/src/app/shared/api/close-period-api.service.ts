import {HttpClient} from "@angular/common/http";
import {Injectable} from '@angular/core';
import {BaseApiService} from './base-api.service';
import {FormGroup} from "@angular/forms";
import {ICrystalProfitPeriod} from "../models/i-crystal-profit-period";

@Injectable()
export class ClosePeriodApiService extends BaseApiService {

  constructor(http: HttpClient) {
    super('ClosePeriod', http)
  }

  public async Calculate(model: FormGroup) {
    return this.post('Calculate', model.value).toPromise();
  }

  public async GetList() {
    return this.get<ICrystalProfitPeriod[]>('GetList').toPromise();
  }
}

import { Injectable } from '@angular/core';
import { extend } from 'webdriver-js-extender';
import { BaseApiService } from './base-api.service';
import { HttpClient } from "@angular/common/http";
import { EpicModel } from '../models/epic.model';
import { FormGroup } from '@angular/forms';
@Injectable()
export class EpicApiService extends BaseApiService{

  constructor(public http: HttpClient) {super('Epic', http) }


public async GetList() {
  return this.get<EpicModel[]>('GetList').toPromise();
}
  
  public async Create(model: FormGroup) {
  return this.post<number>('Create', model.value).toPromise();
}

}

import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { EpicModel } from '../models/epic.model';
import { BaseApiService } from './base-api.service';
@Injectable()
export class EpicApiService extends BaseApiService {

  constructor(http: HttpClient) { super('Epic', http) }

  public async GetList() {
    return this.get<EpicModel[]>('GetList').toPromise();
  }

  public async Create(model: FormGroup) {
    return this.post<number>('Create', model.value).toPromise();
  }

  public async Delete(id: number) {
    return this.post<number>('Delete', id).toPromise();
  }

  public async Details(id: number) {
    return this.get<any>('Details?id=' + id).toPromise();
  }

  public async Update(model: FormGroup) {
    return this.post<number>('Update', model.value).toPromise();
  }
}

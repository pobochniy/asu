import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IssueModel } from '../models/issue.model';
import { BaseApiService } from "./base-api.service";


@Injectable()
export class IssueApiService extends BaseApiService {
  constructor(public http: HttpClient) {
    super('Issue', http)
  }

  public async GetList() {
    return this.get<IssueModel[]>('GetList').toPromise();
  }
  
  public async Create(model: FormGroup) {
    return this.post<number>('Create', model.value).toPromise();
  }
}

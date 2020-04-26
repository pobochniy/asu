import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseApiService } from "./base-api.service";
import { IssueModel } from "../models/issue.model";
import { IssueTypeEnum } from "../enums/issue-type.enum";


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

  public async Update(model: FormGroup) {
    return this.post<number>('Update', model.value).toPromise();
  }

  public async Details(id: number) {
    return this.get<any>('Details?id=' + id).toPromise();
  }
}

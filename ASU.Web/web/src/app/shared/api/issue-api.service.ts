import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IssueModel } from "../models/issue.model";
import { BaseApiService } from "./base-api.service";


@Injectable()
export class IssueApiService extends BaseApiService {
  constructor(http: HttpClient) {
    super('Issue', http)
  }

  public async GetList(epicId?: number) {
    return this.get<IssueModel[]>('GetList?epicId=' + epicId).toPromise();
  }

  public async Create(model: FormGroup) {
    model.controls["type"].setValue(+model.controls["type"].value);
    return this.post<number>('Create', model.value).toPromise();
  }

  public async Update(model: FormGroup) {
    model.controls["type"].setValue(+model.controls["type"].value);
    return this.post<number>('Update', model.value).toPromise();
  }

  public async Details(id: number) {
    return this.get<any>('Details?id=' + id).toPromise();
  }
}

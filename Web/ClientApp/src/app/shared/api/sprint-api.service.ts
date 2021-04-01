import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DashboardModel } from '../models/dashboard.model';
import { BaseApiService } from './base-api.service';

@Injectable()
export class SprintApiService extends BaseApiService {
  constructor(public http: HttpClient) {
    super('Sprint', http)
  }

  public async GetList() {
    return this.get<DashboardModel[]>('GetList').toPromise();
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

  public async Delete(id: number) {
    return this.get<any>('Delete?id=' + id).toPromise();
  }

  public async AddIssue(sprintId: number, issueId: number) {
    return this.get<any>('AddIssue?sprintId=' + sprintId + '&issueId=' + issueId).toPromise();
  }

  public async DeleteIssue(sprintId: number, issueId: number) {
    return this.get<any>('DeleteIssue?sprintId=' + sprintId + '&issueId=' + issueId).toPromise();
  }
}

import { Data } from "@angular/router";
import { IssueModel } from "./issue.model";
 /* Доска спринтов */
export class DashboardModel {
  public id!: number;
  public startDate?: Date;
  public finishDate?: Date;
  public isEnded?: number;
  public issues?: IssueModel[] = [];
}

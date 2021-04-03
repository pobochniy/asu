import { Data } from "@angular/router";
import { IssueModel } from "./issue.model";
 /* Доска спринтов */
export class DashboardModel {

  public Id: number;
  public StartDate: Date;
  public FinishDate: Date;
  public IsEnded: number;
  public issues: IssueModel[] = [];

}

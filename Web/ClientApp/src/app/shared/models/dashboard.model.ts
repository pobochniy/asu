import { Data } from "@angular/router";
import { IssueModel } from "./issue.model";
 /* Доска спринтов */
export class DashboardModel {

  public dateStart: Date;
  public dateEnd: Date;
  public issues: IssueModel[] = [];

}

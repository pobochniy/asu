import { IssuePriorityEnum } from "../enums/issue-priority.enum";
import { Time } from "@angular/common";

export class EpicModel {

  public id: number;

  public reporter: string;

  public priority: IssuePriorityEnum;

  public name: string;

  public description: string;

  public dueDate: Time;
}

import { IssueTypeEnum } from "../enums/issue-type.enum";
import { IssueStatusEnum } from "../enums/issue-status.enum";
import { IssuePriorityEnum } from "../enums/issue-priority.enum";
import { Time } from "@angular/common";

export class IssueModel {

  public id?: number;
  /// Исполнитель
  public assignee?: string;

  /// Инициатор
  public reporter?: string;

  /// Сводка
  public summary?: string;

  /// Описание
  public description?: string;

  /// Тип события
  public type!: IssueTypeEnum;

  /// Статус
  public status!: IssueStatusEnum;

  /// Приоритет события
  public priority!: IssuePriorityEnum;

  /// Предполагаемое время исполнителя
  public assigneeEstimatedTime?: number;

  /// Предполагаемое время инициатора
  public reporterEstimatedTime?: number;

  /// Дата крайнего срока завершения события
  public dueDate?: Date;

  /// Ссылки на эпики
  public epicLink?: number;
}

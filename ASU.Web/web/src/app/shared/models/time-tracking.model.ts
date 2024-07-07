export class TimeTrackingModel {

  public id: number = 0;

  /** День на который списывать время */
  public date!: Date;

  /** Время "с" */
  public from!: Date;

  /** Время "по" */
  public to!: Date;

  /** Описание работы */
  public comment!: string;

  /** Пользователь, потративший время */
  public userId!: string;

  /** Задача, на которую потрачено время */
  public issueId?: number;

  /** Эпик, на который потрачено время */
  public epicId?: number;
}

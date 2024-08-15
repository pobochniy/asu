export class TimeTrackingModel {

  public id?: number;

  /** День на который списывать время */
  public date?: Date;

  /** Время "с" */
  public from?: Date;

  /** Время "по" */
  public to?: Date;

  /** Описание работы */
  public comment?: string;

  /** Пользователь, потративший время */
  public userId?: string;

  /** Задача, на которую потрачено время */
  public issueId?: number;

  /** Эпик, на который потрачено время */
  public epicId?: number;

  /** Наименование задачи или эпика */
  public issueEpicName: string = '';
}


export class UserTracking {
  public date: string;
  public timeTracks: TimeTracks[] = []
  public totalTimeTracks: string;
}

export class TimeTracks {
  public from: string;
  public to: string;
  public comment: string;
  public issueId?: number;
  public epicId?: number;

  constructor(obj: any = {}) {
    this.from = obj.from.substring(0, 5);
    this.to = obj.to.substring(0, 5);
    this.comment = obj.comment;
  }
}

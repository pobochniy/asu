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

export interface IUserTracking {
  date: string;
  timeTracks: ITimeTracks[];
  totalTimeTracks: string;
}

export interface ITimeTracks {
  from: string;
  to: string;
  comment: string;
  issueId?: number;
  epicId?: number;
}

import {AlertModel} from "../models/alert.model";

export class AlertsService {
  private nextId = 0;
  public alerts: AlertModel[] = [];

  public push(alertClass: "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark"
    , content: string
    , timeToCloseMs: number = 0) {

    const id = ++this.nextId;
    this.alerts.push(new AlertModel({id: id, alertClass: alertClass, content: content}));
    if (timeToCloseMs > 0) setTimeout(() => {
      this.remove(id);
    }, timeToCloseMs)
  }

  public remove(id: number) {
    this.alerts = this.alerts.filter(x => x.id !== id);
  }
}

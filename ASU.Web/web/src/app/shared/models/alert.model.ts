export class AlertModel {
  /** Id */
  public id: number;

  /** Level */
  public alertClass: "primary" | "secondary" | "success" | "danger" | "warning" | "info" | "light" | "dark";

  /** Text */
  public content: string;

  constructor(obj: any = {}) {
    this.id = obj.id;
    this.alertClass = obj.alertClass || "danger";
    this.content = obj.content;
  }
}

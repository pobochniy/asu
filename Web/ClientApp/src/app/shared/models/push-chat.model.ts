import { isNull } from "util";

export class PushChatModel {
  public message: string;
  public to?: Array<string>;
  public privat?: Array<string>;

  constructor(text: string) {
    this.message = text != undefined ? text : "";
    while (this.fillToArray()) { };
    while (this.fillPrivateArray()) { };

    this.message = this.message.trim();
  }

  private fillToArray(): boolean {
    const exist = /to \[(.*?)\]/i.exec(this.message);
    if (this.to === undefined) this.to = [];

    if (exist) {
      this.to = this.to.concat(exist[1].split(',').map(item => item.trim()));

      this.message = this.message.replace(exist[0], '');
    }

    return !isNull(exist);
  }

  private fillPrivateArray(): boolean {
    const exist = /private \[(.*?)\]/i.exec(this.message);
    if (this.privat === undefined) this.privat = [];

    if (exist) {
      this.privat = this.privat.concat(exist[1].split(',').map(item => item.trim()));

      this.message = this.message.replace(exist[0], '');
    }

    return !isNull(exist);
  }

  public toString(): string {
    let result: string = "";

    if (this.privat && this.privat.length > 0) {
        result += "private [" + this.privat.join(', ') + "] ";
    }

    if (this.to && this.to.length > 0) {
        result += "to [" + this.to.join(', ') + "] ";
    }

    if (this.message) {
      result += this.message;
    }

    return result;
  }
}

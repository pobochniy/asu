import { ChatTypeEnum } from "../enums/chat-type.enum";
import { PushChatModel } from "./push-chat.model";
import { forEach } from "@angular/router/src/utils/collection";

export class ChatModel extends PushChatModel {
  public Id: string;
  public type: ChatTypeEnum;
  public login: string;

  public time: string;

  constructor() {
    super("");

    this.time = new Date().toLocaleTimeString();
  }

  public toAsString(needPrefix: boolean): string {

    let to: string = "";
    let prefix: string = "";
    if (needPrefix)
      prefix = "to ";

    if (this.to.length > 0) {

      to = prefix + "[";
      this.to.forEach(function (value) {
        to += value + ", ";
      });

      to = to.substring(0, to.length - 2);
      to += "]";
    }

    return to;
  }

  public privatAsString(needPrefix: boolean) {

    let privat: string = "";
    let prefix: string = "";
    if (needPrefix)
      prefix = "private ";

    if (this.privat.length > 0) {

      privat = prefix + "[";
      this.privat.forEach(function (value) {
        privat += value + ", ";
      });

      privat = privat.substring(0, privat.length - 2);
      privat += "]";
    }

    return privat;
  }  
}



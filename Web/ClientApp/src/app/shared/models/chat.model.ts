import { ChatTypeEnum } from "../enums/chat-type.enum";
import { PushChatModel } from "./push-chat.model";

export class ChatModel extends PushChatModel {
  public Id: string;
  public type: ChatTypeEnum;
  public login: string;

  constructor(data: any) {
    super("");

    this.Id = data.id != undefined ? data.id : "";
    this.login = data.login != undefined ? data.login : "";
    this.message = data.message != undefined ? data.message : "";
    this.privat = data.privat != undefined ? data.privat : [];
    this.to = data.to != undefined ? data.to : [];
    this.type = data.type != undefined ? data.type : ChatTypeEnum.text;   
  }

  public getTime(): string {
    let ticks = parseInt(this.Id);
    let ticksToMicrotime = ticks / 10000;
    let tickDate = new Date(ticksToMicrotime);

    let result: string = tickDate.toLocaleTimeString();

    return result;
  }
}



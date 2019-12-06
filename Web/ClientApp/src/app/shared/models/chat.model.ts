import { ChatTypeEnum } from "../enums/chat-type.enum";
import { PushChatModel } from "./push-chat.model";
import { forEach } from "@angular/router/src/utils/collection";
import { debug } from "util";

export class ChatModel extends PushChatModel {
  public Id: string;
  public type: ChatTypeEnum;
  public login: string;

  constructor() {
    super("");    
  }

  public getTime(): string {
    var ticks = parseInt(this.Id);
    var ticksToMicrotime = ticks / 10000;
    var tickDate = new Date(ticksToMicrotime);

    let result: string = tickDate.toLocaleTimeString();
    debugger

    return result;
  }
}



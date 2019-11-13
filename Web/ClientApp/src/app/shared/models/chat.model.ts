import { ChatTypeEnum } from "../enums/chat-type.enum";
import { PushChatModel } from "./push-chat.model";
import { forEach } from "@angular/router/src/utils/collection";

export class ChatModel extends PushChatModel {
  public Id: string;
  public type: ChatTypeEnum;
  public login: string;

  constructor() {
    super("");    
  }

  public getTime(): string {
    let result: string = "";

    if (this.Id) {
      debugger
      result = new Date(parseInt(this.Id)).toLocaleTimeString();
    }
    else
      result = new Date().toLocaleTimeString();

    return result;
  }
}



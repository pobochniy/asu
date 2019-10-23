import { Injectable } from '@angular/core';
import { ChatModel } from '../models/chat.model';
import * as signalR from "@aspnet/signalr";
import { HubConnection } from "@aspnet/signalr";
import { PushChatModel } from '../models/push-chat.model';

@Injectable()
export class ChatService {
  private chatList: ChatModel[] = [];
  public msgs: Array<ChatModel> = []; // это с сервераs
  public connection: HubConnection;

  constructor() { }

  public sendMessage(model: ChatModel) {
    this.chatList.push(model);
  }

  public get getMessageList(): ChatModel[] {
    return this.chatList;
  }

  public initConnection() {
    //var kk = signalR.;
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('/chat')
      .build();
  }

  public connectionWebSocket() {
    this.connection.start();

    this.connection.on("BroadCastMessage", data => {
      debugger
      let chatModel: ChatModel = Object.assign(new ChatModel(), data);

      console.log(chatModel);
      if (chatModel.message.length) {
        //let message = chatModel.toChatMessage();

        this.msgs.push(chatModel);
      }
    });
  }

  send(text: string) {
    const msg = new PushChatModel(text);
    this.connection.invoke("PushMessage", msg);
  }
}

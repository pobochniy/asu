import { Injectable } from '@angular/core';
import { ChatModel } from '../models/chat.model';
import * as signalR from "@aspnet/signalr";
import { HubConnection } from "@aspnet/signalr";

@Injectable()
export class ChatService {
  private chatList: ChatModel[] = [];
  public msgs: Array<string> = []; // это с сервераs
  public connection: HubConnection;

  constructor() { }

  public sendMessage(model: ChatModel) {
    this.chatList.push(model);
  }

  public get getMessageList(): ChatModel[] {
    return this.chatList;
  }

  public initConnection() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/chat")
      .build();
  }

  public connectionWebSocket() {
    this.connection.start();

    this.connection.on("BroadCastMessage", data => {
      console.log(data);
      if (data.length) {
        this.msgs.push(data);
      }
    });
  }

  send(text: string) {


    this.connection.invoke("PushMessage", text);  
  }
}

import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { HubConnection } from "@aspnet/signalr";
import { UsersApiService } from '../api/users-api.service';
import { ChatTypeEnum } from '../enums/chat-type.enum';
import { ChatModel } from '../models/chat.model';
import { PushChatModel } from '../models/push-chat.model';
import { UserProfileModel } from '../models/user-profile.model';

@Injectable()
export class ChatService {
  private chatList: ChatModel[] = [];
  public msgs: Array<ChatModel> = []; // это с сервера
  public connection?: HubConnection;
  public onlineUsers: Array<string> = [];

  constructor(public userService: UsersApiService) { }

  public sendMessage(model: ChatModel) {
    this.chatList.push(model);
  }

  public get getMessageList(): ChatModel[] {
    return this.chatList;
  }

  public initConnection() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('/chat')
      .build();
  }

  public connectionWebSocket() {
    this.connection!.start();

    this.connection!.on("BroadCastMessage", (data: any) => {
      let chatModel: ChatModel = new ChatModel(data);

      if (chatModel.message.length) {
        this.msgs.push(chatModel);
      }
    });

    this.connection!.on("SysMessages", (res: any) => {
      switch (res.type) {
        case ChatTypeEnum.user:
          this.userService.changeUser(new UserProfileModel(res.data));
          break;
      }
    });

    this.connection!.on("SendUsers", (data: any) => {
      this.onlineUsers = data;
    });

  }

  async send(text: string) {
    //if (this.connection.state == 0) {
    //  await this.connectionWebSocket();
    //}

    const msg = new PushChatModel(text);
    this.connection!.invoke("PushMessage", msg);
  }
}

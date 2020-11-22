import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { HubConnection } from "@aspnet/signalr";
import { UsersApiService } from '../api/users-api.service';
import { ChatTypeEnum } from '../enums/chat-type.enum';
import { ChatModel } from '../models/chat.model';
import { PushChatModel } from '../models/push-chat.model';
import { UserProfileModel } from '../models/user-profile.model';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Injectable()
export class ChatService {
  private chatList: ChatModel[] = [];
  public msgs: Array<ChatModel> = []; // это с сервера
  public connection: HubConnection;
  public base64data: SafeUrl;
  private lastImgTime: number = 0;

  constructor(public userService: UsersApiService,
    private sanitizer: DomSanitizer) { }

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
    this.connection.start();

    this.connection.on("BroadCastMessage", data => {
      let chatModel: ChatModel = new ChatModel(data);

      if (chatModel.message.length) {
        this.msgs.push(chatModel);
      }
    });

    this.connection.on("SysMessages", res => {
      switch (res.type) {
        case ChatTypeEnum.user:
          this.userService.changeUser(new UserProfileModel(res.data));
          break;
      }
    });

    this.connection.on("BroadCastImage", image => {
      console.log(image);
      if (this.lastImgTime < +image.time) {
        this.lastImgTime = +image.time;
        //debugger;
        this.base64data = this.sanitizer.bypassSecurityTrustUrl('data:image/jpeg;base64,' + image.message);
      }
      //var blob = new Blob([image], { type: "image/png" });
      //var reader = new FileReader();
      //reader.readAsDataURL(blob);
      //var that = this;
      //reader.onloadend = function () {
      //  that.base64data = that.sanitizer.bypassSecurityTrustUrl(reader.result + '');
      //}

    });
  }

  async send(text: string) {
    //if (this.connection.state == 0) {
    //  await this.connectionWebSocket();
    //}

    const msg = new PushChatModel(text);
    this.connection.invoke("PushMessage", msg);
  }
}

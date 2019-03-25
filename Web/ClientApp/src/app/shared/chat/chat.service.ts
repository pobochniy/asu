import { Injectable } from '@angular/core';
import { ChatModel } from '../models/chat.model';

@Injectable()
export class ChatService {
  private chatList: ChatModel[] = [];

  constructor() { }

  public sendMessage(model: ChatModel) {
    this.chatList.push(model);
  }
  
  public get getMessageList(): ChatModel[] {
    return this.chatList;
  }

}

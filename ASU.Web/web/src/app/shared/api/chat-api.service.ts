import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { ChatModel } from "../models/chat.model";
import { PushChatModel } from "../models/push-chat.model";
import { BaseApiService } from "./base-api.service";

@Injectable()
export class ChatApiService extends BaseApiService {
  constructor(http: HttpClient) {
    super('Chat', http)
  }

  public async send(model: PushChatModel) {
    return this.post<ChatModel>('Send', model).toPromise();
  }
}

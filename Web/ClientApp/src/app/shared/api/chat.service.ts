import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UserModel } from '../models/user.model';
import { BaseApiService } from "./base-api.service";
import { ChatModel } from "../models/chat.model";

@Injectable()
export class ChatService extends BaseApiService {
  constructor(public http: HttpClient) {
    super('Chat', http)
  }

  public async push(model: ChatModel) {
    return this.post<void>('Push', model).toPromise();
  }
  
}

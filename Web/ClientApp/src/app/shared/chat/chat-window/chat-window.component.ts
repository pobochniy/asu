import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { ChatModel } from '../../models/chat.model';
import { from } from "rxjs/observable/from";
import { ChatService } from "../chat.service";
import { PushChatModel } from "../../models/push-chat.model";
import { ChatApiService } from '../../api/chat-api.service';

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit, AfterViewInit {

  public text: string; // текстовове поле ввода

  constructor(
    public chatService: ChatService,
    public apiService: ChatApiService
  ) { }

  ngOnInit() {
    this.chatService.initConnection();
  }

  ngAfterViewInit() {
    this.chatService.connectionWebSocket();
  }
    
  async send() {
    debugger
    const msg = new PushChatModel(this.text);
    //await this.apiService.send(msg);

    this.chatService.send(this.text);
    this.text = '';

    //this.skrollBottom();
  }

  async addTo(to: string) {
    debugger

    if (!this.text) {
      this.text = "";
    }

    this.text += " to " + to + " ";
  }

  async addPrivat(privat: string) {
    debugger

    if (!this.text) {
      this.text = "";
    }

    this.text += " private " + privat + " ";
  }

  //skrollBottom() {
  //  // scrollContainer

  //  let objDiv = document.getElementById('scrollContainer');
  //  if (!objDiv) return;

  //  setTimeout(() => {
  //    objDiv.scrollTop = objDiv.scrollHeight;
  //  }, 50);
  //}

  //onEnter(e: any) {
  //  debugger;
  //  if (!e.shiftKey || !e.ctrlKey) {
  //    e.preventDefault()
  //    this.send();
  //  }
  //}

}

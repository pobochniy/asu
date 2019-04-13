import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { ChatService } from '../../api/chat.service';
import { ChatModel } from '../../models/chat.model';
import * as signalR from "@aspnet/signalr";
import { HubConnection } from "@aspnet/signalr";
import { from } from "rxjs/observable/from";

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.css']
})
export class ChatWindowComponent implements OnInit, AfterViewInit {
  private connection: HubConnection;

  public msgs: Array<string> = []; // это с сервера
  public msg: string; // это отсюда

  constructor(
    private chatService: ChatService
  ) { }

  ngOnInit() {

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("/chat")
      .build();    
  }

  ngAfterViewInit() {
    this.connectionWebSocket();
  }

  connectionWebSocket() {
    this.connection.start();

    this.connection.on("BroadCastMessage", data => {
      console.log(data);
      debugger
      if (data.length) {
        this.msgs.push(data);
      }
    });
  }


  send() {
    this.connection.invoke("PushMessage", this.msg)
      .then(() => {
        this.msg = '';
      })
    //this.skrollBottom();
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

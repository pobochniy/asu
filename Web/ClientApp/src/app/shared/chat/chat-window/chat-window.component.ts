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
  //public message: string = '';
  //private _hubConnection: HubConnection;
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

    //console.log(this.chatSe;rvice)
  }

  ngAfterViewInit() {
    this.connectionWebSocket();

    //this.initAudio();
    //this.chatService.getList()
    //  .subscribe(
    //  x => {
    //    this.msgs = x;
    //    this.connectionWebSocket();
    //  },
    //  err => {
    //    console.log(err);
    //  });
  }

  connectionWebSocket() {
    
    this.connection.on("BroadCastMessage", data => {
      console.log(data);
      debugger
      if (data.length) {

        from(data).subscribe((x: string) => {
          this.msgs.push(x);
        });
        //setTimeout(this.toBottom, 50);
        //this.play();
      }
    });
  }

  //get messageList(): ChatModel[] {
  //  return this.chatService.getMessageList;
  //}

  send() {
    //let model = new ChatModel();
    //model.Text = this.message;
    //model.Id = 15;
    //model.Name = 'Alex Cherniy';

    //this.chatService.push(model);
    debugger
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

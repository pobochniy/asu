import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { UsersApiService } from '../api/users-api.service';
import { UserProfileModel } from '../models/user-profile.model';

@Component({
  selector: 'chat-user-name',
  templateUrl: './chat-user-name.component.html',
  styleUrls: ['./chat-user-name.component.css']
})
export class ChatUserNameComponent implements OnChanges {

  @Input('userId') userId!: string;
  public user!: UserProfileModel;

  @Output() addPrivatTo = new EventEmitter<{userName: string, isPrivat: boolean}>();
  addPrivatToChild(userName: string, isPrivat: boolean) {
    debugger
    this.addPrivatTo.emit({ userName, isPrivat });
  }

  constructor(public users: UsersApiService) { }

  async ngOnInit() {
  }

  async ngOnChanges(changes: SimpleChanges) {
    if (changes['userId'] && changes['userId'].currentValue) {
      this.user = await this.users.getUser(this.userId);
    }
  }

}


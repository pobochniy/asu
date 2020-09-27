import { Component, Input, OnInit } from '@angular/core';
import { UsersApiService } from '../api/users-api.service';
import { UserProfileModel } from '../models/user-profile.model';

@Component({
  selector: 'shared-user-name',
  templateUrl: './user-name.component.html',
  styleUrls: ['./user-name.component.css']
})
export class UserNameComponent implements OnInit {

  @Input('userId') userId: string;
  public user: UserProfileModel;

  constructor(public users: UsersApiService) { }

  async ngOnInit() {
    this.user = await this.users.getUser(this.userId);
  }

}

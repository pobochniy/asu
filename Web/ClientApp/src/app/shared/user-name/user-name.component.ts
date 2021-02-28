import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { UsersApiService } from '../api/users-api.service';
import { UserProfileModel } from '../models/user-profile.model';

@Component({
  selector: 'shared-user-name',
  templateUrl: './user-name.component.html',
  styleUrls: ['./user-name.component.css']
})
export class UserNameComponent implements OnChanges {

  @Input('userId') userId: string;
  public user: UserProfileModel;

  constructor(public users: UsersApiService) { }

  async ngOnInit() {
  }

  async ngOnChanges(changes: SimpleChanges) {
    if (changes['userId'] && changes['userId'].currentValue) {
      this.user = await this.users.getUser(this.userId);
    }
  }
}

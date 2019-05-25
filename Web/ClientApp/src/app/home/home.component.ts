import { Component } from '@angular/core';
import { UserService } from '../shared/core/user.service';
import { AuthApiService } from '../shared/api/auth-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [AuthApiService, UserService]
})
export class HomeComponent {
  constructor(public user: UserService, private authServ: AuthApiService) { }

  async logOut() {
    this.user.User = null;
    await this.authServ.logOut();
    //this.router.navigateByUrl('/');
  }
}

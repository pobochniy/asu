import { Component } from '@angular/core';
import { UserService } from '../shared/core/user.service';
import { AuthApiService } from '../shared/api/auth-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [AuthApiService]
})
export class HomeComponent {
  constructor(public service: UserService, private authServ: AuthApiService) {
  }

  async logOut() {
    this.service.User = undefined;
    await this.authServ.logOut();
    //this.router.navigateByUrl('/');
  }
}

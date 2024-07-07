import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthApiService } from '../../shared/api/auth-api.service';
import { UserService } from '../../shared/core/user.service';
import { loginFormModel } from '../../shared/form-models/login-form.model';
import { ChatService } from '../../shared/chat/chat.service';

@Component({
  selector: 'login-auth',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthApiService]
})
export class LoginComponent {
  public loginForm = loginFormModel;

  constructor(private service: AuthApiService
    , private router: Router
    , private userService: UserService
    , private chatService: ChatService) { }

  async onSubmit() {
    try {
      if (this.loginForm.valid) {
        let usr = await this.service.login(this.loginForm);
        this.userService.User = usr;
        this.chatService.connectionWebSocket();
        this.router.navigateByUrl('/');
      }
    }
    catch (Exception) {
      alert("не подходит");
    }
  }
}

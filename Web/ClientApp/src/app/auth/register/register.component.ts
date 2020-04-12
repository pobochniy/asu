import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../shared/core/user.service';
import { registerFormModel } from '../../shared/form-models/register-form.model';
import { AuthApiService } from '../../shared/api/auth-api.service';
import { ChatService } from '../../shared/chat/chat.service';

@Component({
  selector: 'login-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AuthApiService,]
})
export class RegisterComponent {

  public registerForm = registerFormModel;

  constructor(private service: AuthApiService
    , private router: Router
    , private userService: UserService
    , private chatService: ChatService) { }

  async onSubmit() {
    for (let item in this.registerForm.controls) {
      this.registerForm.controls[item].markAsDirty();
    }

    try {
      if (this.registerForm.valid) {
        let usr = await this.service.register(this.registerForm);
        this.userService.User = usr;
        this.chatService.connectionWebSocket();
        this.router.navigateByUrl('/');
      }
    }
    catch{
      alert('Возникли непредвиденные ошибки. Попробуйте ввести другие значения или сообщите программисту');
    }
  }
}

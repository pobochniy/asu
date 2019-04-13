import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/api/auth.service';
import { UserService } from '../../shared/core/user.service';
import { loginFormModel } from '../../shared/form-models/login-form.model';

@Component({
  selector: 'login-auth',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthService, UserService]
})
export class LoginComponent {
  public loginForm = loginFormModel;

  constructor(private service: AuthService
    , private router: Router
    , private userService: UserService) { }

  async onSubmit() {
    try {
      if (this.loginForm.valid) {
        let usr = await this.service.login(this.loginForm);
        this.userService.User = usr;
        this.router.navigateByUrl('/chat');
      }
    }
    catch {
      alert("не подходит");
    }
  }
}

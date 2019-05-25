import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthApiService } from '../../shared/api/auth-api.service';
import { UserService } from '../../shared/core/user.service';
import { loginFormModel } from '../../shared/form-models/login-form.model';

@Component({
  selector: 'login-auth',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthApiService, UserService]
})
export class LoginComponent {
  public loginForm = loginFormModel;

  constructor(private service: AuthApiService
    , private router: Router
    , private userService: UserService) { }

  async onSubmit() {
    try {
      if (this.loginForm.valid) {
        let usr = await this.service.login(this.loginForm);
        this.userService.User = usr;
        this.router.navigateByUrl('/');
      }
    }
    catch (Exception) {
      alert("не подходит");
    }
  }
}

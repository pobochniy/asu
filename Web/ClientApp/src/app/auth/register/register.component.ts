import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../shared/api/auth.service';
import { UserService } from '../../shared/core/user.service';
import { registerFormModel } from '../../shared/form-models/register-form.model';

@Component({
  selector: 'login-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [AuthService, UserService]
})
export class RegisterComponent {

  public registerForm = registerFormModel;

  constructor(private service: AuthService
    , private router: Router
    , private userService: UserService) { }

  async onSubmit() {
    for (let item in this.registerForm.controls) {
      this.registerForm.controls[item].markAsDirty();
    }

    console.log(this.registerForm.valid);
  }
}

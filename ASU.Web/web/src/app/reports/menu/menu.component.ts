import {Component} from '@angular/core';
import {UserRoleEnum} from "../../shared/enums/user-role.enum";
import {UserService} from "../../shared/core/user.service";

@Component({
  selector: 'reports-menu',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {

  public roles = UserRoleEnum;
  protected readonly UserRoleEnum = UserRoleEnum;

  constructor(public userService: UserService) {
  }

}

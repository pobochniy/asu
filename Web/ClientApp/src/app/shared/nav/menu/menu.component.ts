import { Component, OnInit } from '@angular/core';
import { UserService } from '../../core/user.service';
import { UserRoleEnum } from '../../enums/user-role.enum';
import { EventEmitterService } from '../event-emitter.service';

@Component({
  selector: 'shared-nav-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class NavMenuComponent implements OnInit {
  constructor(private eventEmitterService: EventEmitterService,
    private userService: UserService
  ) { }

  public roles = UserRoleEnum;

  ngOnInit(): void {
    if (this.eventEmitterService.subsMenu == undefined) {
      this.eventEmitterService.subsMenu = this.eventEmitterService
        .invokeMenuToggleMenuFunction.subscribe(() => {
          this.toggleMenu();
        });
    }
  }

  isExpanded = false;

  toggleMenu() {
    this.isExpanded = !this.isExpanded;
  }

  hasRole(roleId: number): boolean {
    return this.userService.hasRole(roleId);
  }
}

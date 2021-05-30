import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../shared/core/user.service';
import { UserRoleEnum } from '../shared/enums/user-role.enum';

@Injectable({
  providedIn: 'root'
})
export class RoleManagementGuard implements CanActivate {
  private roles = UserRoleEnum;

  constructor(public userSrvice: UserService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.userSrvice.hasRole(this.roles.roleManagement);
  }
  
}

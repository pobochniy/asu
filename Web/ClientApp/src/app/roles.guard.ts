import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from './shared/core/user.service';
import { UserRoleEnum } from './shared/enums/user-role.enum';

@Injectable({
  providedIn: 'root'
})
export class RolesGuard implements CanActivate {

  constructor(public userSrvice: UserService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const roles = route.data.allowedRoles as Array<UserRoleEnum>;
    var res = false;

    roles.forEach(role => {
      if (this.userSrvice.hasRole(role)) {
        res = true;
      }
        
    });

    return res;
  }
  
}

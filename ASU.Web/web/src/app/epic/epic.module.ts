import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {provideRouter, RouterModule, Routes} from '@angular/router';
import {NgxSelectModule} from 'ngx-select-ex';
import {EditComponent} from './edit/edit.component';
import {SharedModule} from '../shared/shared.module';
import {DetailsComponent} from './details/details.component';
import {ListComponent} from './list/list.component';
import {RolesGuard} from "../roles.guard";
import {UserRoleEnum} from "../shared/enums/user-role.enum";

const routes: Routes = [{
  path: 'epic', children: [
    { path: '', redirectTo: 'list', pathMatch: 'full', data: { allowedRoles: [UserRoleEnum.epicRead, UserRoleEnum.epicCrud] } },
    { path: 'list', component: ListComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicRead, UserRoleEnum.epicCrud] } },
    { path: 'edit/:id', component: EditComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicCrud] } },
    { path: 'details/:id', component: DetailsComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicRead, UserRoleEnum.epicCrud] } }
  ]
}];

@NgModule({
  imports: [
    SharedModule,
    RouterModule,
    NgxSelectModule,
    FormsModule
  ],
  declarations: [ListComponent, EditComponent, DetailsComponent],
  providers: [provideRouter(routes)]
})
export class EpicModule { }

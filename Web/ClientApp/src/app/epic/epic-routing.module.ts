import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditComponent } from '../epic/edit/edit.component';
import { RolesGuard } from '../roles.guard';
import { UserRoleEnum } from '../shared/enums/user-role.enum';
import { DetailsComponent } from './details/details.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [{
  path: 'epic', children: [
    { path: '', redirectTo: 'list', pathMatch: 'full', canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicRead, UserRoleEnum.epicCrud] } },
    { path: 'list', component: ListComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicRead, UserRoleEnum.epicCrud] } },
    { path: 'edit/:id', component: EditComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicCrud] } },
    { path: 'details/:id', component: DetailsComponent, canActivate: [RolesGuard], data: { allowedRoles: [UserRoleEnum.epicRead, UserRoleEnum.epicCrud] } }
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)]
})
export class EpicRoutingModule { }

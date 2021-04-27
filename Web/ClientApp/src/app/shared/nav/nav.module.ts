import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './menu/menu.component';
import { NavTabsComponent } from './tabs/tabs.component';
import { RouterModule } from '@angular/router';
import { TopNavComponent } from './top-nav/top-nav.component';
import { EventEmitterService } from './event-emitter.service';

@NgModule({
  declarations: [
    NavMenuComponent,
    NavTabsComponent,
    TopNavComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavMenuComponent,
    NavTabsComponent,
    TopNavComponent
  ],
  providers: [
    EventEmitterService
  ]
})
export class NavModule { }

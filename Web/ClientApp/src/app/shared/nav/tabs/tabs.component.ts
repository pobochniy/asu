import { Component, OnInit } from '@angular/core';
import { Event, NavigationEnd, Router } from '@angular/router';
import { TabsModel } from './tabs.model';

@Component({
  selector: 'shared-nav-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.css']
})
export class NavTabsComponent implements OnInit {

  tabs: TabsModel[] = [];

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.router.events
      .subscribe((event: Event) => {
        if (event instanceof NavigationEnd) {
          const newTab = new TabsModel(event);
          this.tabs.map(x => x.isActive = false);
          if (newTab.isMain) {
            if (this.tabs.length && this.tabs[0].isMain) {
              this.tabs[0] = newTab;
            }
            else this.tabs.unshift(newTab);
          }
          else {
            if (!this.tabs.find(x => x.url == newTab.url)) {
              this.tabs.push(newTab);
            }
          }
        }
      });
  }

  close(event: MouseEvent, toRemove: number) {
    this.tabs = this.tabs.filter(x => x.id !== toRemove);
    this.goTo(0);

    event.preventDefault();
    event.stopImmediatePropagation();
  }

  goTo(tabId: number) {
    const tab = this.tabs.filter(x => x.id == tabId)[0];
    if (!tab.isActive) {
      this.router.navigate([tab.url]);
    }

    //event.preventDefault();
    //event.stopImmediatePropagation();
  }
}

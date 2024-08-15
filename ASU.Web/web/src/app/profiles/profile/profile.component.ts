import {Component, OnInit, ViewChild} from '@angular/core';
import {UsersApiService} from "../../shared/api/users-api.service";
import {AlertsService} from "../../shared/alerts/alerts.service";
import {UserService} from "../../shared/core/user.service";
import {UserProfileModel} from "../../shared/models/user-profile.model";
import {HourlyPayModel} from "../../shared/models/hourly-pay.model";
import {HourlyPayApiService} from "../../shared/api/hourly-pay-api.service";
import {HourlyPayPopupComponent} from "../hourly-pay-popup/hourly-pay-popup.component";
import {ActivatedRoute, Router} from "@angular/router";
import {UserRoleEnum} from "../../shared/enums/user-role.enum";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {

  @ViewChild(HourlyPayPopupComponent) hourlyPayPopup!: HourlyPayPopupComponent;

  public profiles: UserProfileModel[] = [];
  public currentUser: UserProfileModel | undefined;
  public hourlyPays: HourlyPayModel[] | undefined;
  public roles = UserRoleEnum;

  constructor(private route: ActivatedRoute,
              private router: Router,
              public alerts: AlertsService,
              public userService: UserService,
              private profilesService: UsersApiService,
              private hourlyPayApi: HourlyPayApiService) {
  }

  dateAsString(date: Date): string {
    return (date + '').substring(0, 10);
  }

  async ngOnInit() {

    const id = this.route.snapshot.paramMap.get('userId') || '';

    this.profiles = await this.profilesService.GetProfiles() || [];
    this.currentUser = this.profiles.filter(x => id !== '' ? id : x.id == this.userService.User?.id).at(0);

    this.hourlyPays = await this.hourlyPayApi.GetList() || [];
  }

  createHourlyPay() {
    this.hourlyPayPopup.show().subscribe(async (x: any) => {
      this.hourlyPays = undefined;
      this.hourlyPays = await this.hourlyPayApi.GetList() || [];
    });
  }
}

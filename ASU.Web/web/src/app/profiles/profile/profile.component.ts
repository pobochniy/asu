import {Component, OnInit, ViewChild} from '@angular/core';
import {UsersApiService} from "../../shared/api/users-api.service";
import {UserService} from "../../shared/core/user.service";
import {UserProfileModel} from "../../shared/models/user-profile.model";
import {HourlyPayModel} from "../../shared/models/hourly-pay.model";
import {HourlyPayApiService} from "../../shared/api/hourly-pay-api.service";
import {HourlyPayPopupComponent} from "../hourly-pay-popup/hourly-pay-popup.component";
import {ActivatedRoute} from "@angular/router";
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
              public userService: UserService,
              private profilesService: UsersApiService,
              private hourlyPayApi: HourlyPayApiService) {
  }

  dateAsString(date: Date): string {
    return (date + '').substring(0, 10);
  }

  async ngOnInit() {
    const that = this;
    this.route
      .params
      .subscribe(async (evt) => {
        const id = that.route.snapshot.paramMap.get('userId') || '';
        that.profiles = await that.profilesService.GetProfiles() || [];
        that.currentUser = that.profiles
          .filter(x => x.id == (id !== '' ? id : that.userService.User?.id))
          .at(0);

        if (that.userService.hasRole(that.roles.hourlyPayRead)) {
          that.hourlyPays = await that.hourlyPayApi.GetList(id) || [];
        }
      })
  }

  createHourlyPay() {
    this.hourlyPayPopup.show().subscribe(async (x: any) => {
      this.hourlyPays = undefined;
      const id = this.route.snapshot.paramMap.get('userId') || '';
      this.hourlyPays = await this.hourlyPayApi.GetList(id) || [];
    });
  }
}

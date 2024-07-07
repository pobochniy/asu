import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { sprintFormModel } from '../../shared/form-models/sprint-form.model';
import { DashboardModel } from '../../shared/models/dashboard.model';
import { SprintApiService } from '../../shared/api/sprint-api.service';
import { UserService } from '../../shared/core/user.service';
import { UserRoleEnum } from '../../shared/enums/user-role.enum';

@Component({
  selector: 'sprint-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  providers: [SprintApiService]
})
export class EditComponent implements OnInit {

  public model?: DashboardModel;
  public sprintForm = sprintFormModel;

  public roles = UserRoleEnum;

  constructor(private service: SprintApiService
    , private router: Router
    , private route: ActivatedRoute
    , private cdRef: ChangeDetectorRef
    , public userService: UserService
  ) { }

  async ngOnInit() {

    const id = +(this.route.snapshot.paramMap.get('id') || 0);

    const sprint = await this.service.Details(id);

    this.cdRef.detectChanges();

    this.sprintForm.setValue({
      id: sprint.id,
      startDate: sprint.startDate ? sprint.startDate?.substr(0, 10) : new Date(),
      finishDate: sprint.finishDate ? sprint.finishDate?.substr(0, 10) : new Date(),
      isEnded: sprint.isEnded
    });

  }

  async onSubmit() {
    Object.keys(this.sprintForm.controls).forEach(key => {
      this.sprintForm.get(key)?.markAsDirty();
    });

    try {
      if (this.sprintForm.valid) {
        if (this.sprintForm.value['id'] || 0 > 0) {
          await this.service.Update(this.sprintForm);
        }
        else {
          await this.service.Create(this.sprintForm);
        }

        this.router.navigateByUrl('/sprint/list');
      }
    }
    catch (e: any) {
      console.log(e);
      alert(e.Message);
    }
  }

}

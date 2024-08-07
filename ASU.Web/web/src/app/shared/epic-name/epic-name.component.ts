import { Component, Input, OnInit } from '@angular/core';
import { EpicApiService } from '../api/epic-api.service';
import { EpicModel } from '../models/epic.model';

@Component({
  selector: 'epic-name',
  templateUrl: './epic-name.component.html',
  styleUrls: ['./epic-name.component.css'],
  providers: [EpicApiService]
})
export class EpicNameComponent implements OnInit {

  @Input('epicId') epicId?: number;

  public epic?: EpicModel;

  constructor(private epicService: EpicApiService) {
    this.epic = new EpicModel();
  }

  async ngOnInit(): Promise<void> {
    if(!this.epicId) {
      this.epic = undefined;
    } else {
      this.epic = await this.epicService.Details(this.epicId);
    }
  }
}

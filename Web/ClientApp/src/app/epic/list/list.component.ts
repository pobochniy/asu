import { Component, OnInit } from '@angular/core';
import { EpicApiService } from '../../shared/api/epic-api.service';
import { EpicModel } from '../../shared/models/epic.model';
import { Router } from '@angular/router';

@Component({
  selector: 'list-epic',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
  providers: [EpicApiService]
})
export class ListComponent implements OnInit {

  public dataSource: EpicModel[];

  constructor(private service: EpicApiService, private router: Router) { }

  async ngOnInit() {
    this.dataSource = await this.service.GetList();

  }

  async Delete(id: number) {

    await this.service.Delete(id);

    this.dataSource = await this.service.GetList();
  }
}

import { Component, OnInit, Input } from '@angular/core';
import { SizeEnum } from '../enums/size.enum';

@Component({
  selector: 'app-fa-icon',
  templateUrl: './fa-icon.component.html',
  styleUrls: ['./fa-icon.component.css']
})
export class FaIconComponent implements OnInit {

  @Input('src') src: string;
  @Input('size') size: SizeEnum = SizeEnum.M;
  @Input('color') color: string = 'black';

  constructor() { }

  ngOnInit(): void {
  }

  public get sizePx(): string {
    let res = 10;
    switch (this.size) {
      case (SizeEnum.XS): res = 10; break;
      case (SizeEnum.S): res = 15; break;
      case (SizeEnum.M): res = 20; break;
      case (SizeEnum.L): res = 35; break;
      case (SizeEnum.XL): res = 30; break;
    }

    return res + 'px';
  }
}

import { Component, Input, TemplateRef, ViewContainerRef, Directive, AfterViewInit } from '@angular/core';
import { registerFormModel } from '../../shared/form-models/register-form.model';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'form-validation',
  templateUrl: './form-validation.component.html',
})
export class FormValidationComponent implements AfterViewInit {
  @Input() model: FormControl;
  @Input() fieldName: string;
  
  constructor() {
    
  }

  ngAfterViewInit(): void {
    console.log(this.model);
  }
}

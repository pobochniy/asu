import {AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from "@angular/forms";

/* Модель спринта */
export let sprintFormModel = new FormGroup({

  /* */
  id: new FormControl(null, [Validators.required]),

  /* Дата начала */
  startDate: new FormControl(null, [Validators.required]),

  /* Дата окончания */
  finishDate: new FormControl(null, [Validators.required]),

  /* */
  isEnded: new FormControl(null, null),
}, { validators: checkDates });

function checkDates(): ValidatorFn {
  return (control:AbstractControl) : ValidationErrors | null => {
    let startDate = control.value.startDate;
    let finishDate = control.value.finishDate;

    return startDate < finishDate ? null : { DateLessThan: true }
  }
}


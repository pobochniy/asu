import { FormControl, FormGroup, Validators } from "@angular/forms";

/* Модель спринта */
export let sprintFormModel = new FormGroup({

  /* */
  'id': new FormControl(null, [Validators.required]),

  /* Дата начала */
  'startDate': new FormControl(null, [Validators.required]),

  /* Дата окончания */
  'finishDate': new FormControl(null, [Validators.required]),

  /* */
  'isEnded': new FormControl(null, null),
}, { validators: checkDates });

function checkDates(group: FormGroup) {
  let startDate = group.controls.startDate.value;
  let finishDate = group.controls.finishDate.value;

  return startDate < finishDate ? null : { DateLessThan: true }
}

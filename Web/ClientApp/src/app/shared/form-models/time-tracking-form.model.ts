import { FormControl, FormGroup, Validators } from "@angular/forms";

/* Модель списания времени */
export let timeTrackingFormModel = new FormGroup({

  'id' : new FormControl(null, [Validators.required]),

  /** День на который списывать время */
  'date': new FormControl(null, [Validators.required]),

  /** Время "с" */
  'from': new FormControl(null, [Validators.required]),

  /** Время "по" */
  'to': new FormControl(null, [Validators.required]),

  /** Описание работы */
  'comment': new FormControl(null, [Validators.required]),

  /** Пользователь, потративший время */
  'userId': new FormControl(null, [Validators.required]),

  /** Задача, на которую потрачено время */
  'issueId': new FormControl(null, [Validators.required]),

  /** Эпик, на который потрачено время */
  'epicId': new FormControl(null, [Validators.required]),
}, { validators: checkTime });

function checkTime(group: FormGroup) {
  let startDate = group.controls.from.value;
  let finishDate = group.controls.to.value;

  return startDate < finishDate ? null : { DateLessThan: true }
}



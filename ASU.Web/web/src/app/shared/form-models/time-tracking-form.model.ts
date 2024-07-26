import {
  AbstractControl,
  FormControl,
  FormGroup,
  UntypedFormControl,
  ValidationErrors,
  ValidatorFn,
  Validators
} from "@angular/forms";

/* Модель списания времени */
export let timeTrackingFormModel = new FormGroup({

  id : new FormControl<number|undefined>(undefined),

  /** День на который списывать время */
  Date: new UntypedFormControl(null, [Validators.required]),

  /** Время "с" */
  from: new UntypedFormControl(null, [Validators.required]),

  /** Время "по" */
  to: new UntypedFormControl(null, [Validators.required]),

  /** Описание работы */
  Comment: new FormControl<string>(''),

  /** Пользователь, потративший время */
  userId: new UntypedFormControl({value: undefined}),

  /** Задача, на которую потрачено время */
  IssueId: new UntypedFormControl({value: undefined}),

  /** Эпик, на который потрачено время */
  EpicId: new UntypedFormControl({value: undefined}),

  /** Эпик, на который потрачено время */
  issueEpicName: new FormControl<string>(''),
}, { validators: checkTime });

function checkTime(): ValidatorFn {
  return (control:AbstractControl) : ValidationErrors | null => {
    let startDate = control.value.from;
    let finishDate = control.value.to;

    return startDate < finishDate ? null : { DateLessThan: true }
  }
}


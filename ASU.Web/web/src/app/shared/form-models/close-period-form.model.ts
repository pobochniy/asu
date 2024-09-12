import {
  FormGroup,
  UntypedFormControl,
  Validators
} from "@angular/forms";

/* Модель списания времени */
export let closePeriodFormModel = new FormGroup({
  /** Время "с" */
  from: new UntypedFormControl(null, [Validators.required]),

  /** Время "по" */
  to: new UntypedFormControl(null, [Validators.required]),
});

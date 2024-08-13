import {
  FormControl,
  FormGroup,
  UntypedFormControl,
  Validators
} from "@angular/forms";

/* Модель часовой оплаты пользователя */
export let hourlyPayFormModel = new FormGroup({

  /** Идентификатор пользователя */
  userId: new UntypedFormControl({value: undefined}),

  /** День на который списывать время */
  startedDate: new UntypedFormControl(null, [Validators.required]),

  /** Описание работы */
  cash: new FormControl<number>(0, [Validators.required]),
});


import { FormControl, FormGroup, Validators } from "@angular/forms";

/** Модель на странице входа */
export let registerFormModel = new FormGroup({
  /** UserName */
  'username': new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Пароль */
  'password': new FormControl(null, [Validators.required, Validators.minLength(6)]),

  /** Пароль */
  'passwordConfirm': new FormControl(null),

  /** Телефон */
  'phone': new FormControl(null),

  /** Email */
  'email': new FormControl(null, [Validators.required, Validators.email])
});

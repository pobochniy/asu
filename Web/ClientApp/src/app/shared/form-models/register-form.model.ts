import { FormControl, FormGroup, Validators } from "@angular/forms";

/** Модель на странице входа */
export let registerFormModel = new FormGroup({
  /** UserName */
  'username': new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Пароль */
  'password': new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Пароль */
  'passwordConfirm': new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Телефон */
  'phone': new FormControl(null),

  /** Email */
  'email': new FormControl(null)
}, { validators: checkPasswords });

function checkPasswords(group: FormGroup) {
  let pass = group.controls.password.value;
  let confirmPass = group.controls.passwordConfirm.value;

  return pass === confirmPass ? null : { PassNotSame: true }
}

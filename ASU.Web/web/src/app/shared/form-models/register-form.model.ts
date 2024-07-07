import {AbstractControl, FormControl, FormGroup, ValidationErrors, Validators, ValidatorFn } from "@angular/forms";

/** Модель на странице входа */
export let registerFormModel = new FormGroup({
  /** UserName */
  username: new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Пароль */
  password: new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Пароль */
  passwordConfirm: new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Телефон */
  phone: new FormControl(null),

  /** Email */
  email: new FormControl(null)
}, { validators: checkPasswords });

function checkPasswords(): ValidatorFn {
  return (control:AbstractControl) : ValidationErrors | null => {
    let pass = control.value.password;
    let confirmPass = control.value.passwordConfirm;

    return pass === confirmPass ? null : { PassNotSame: true }
  }
}

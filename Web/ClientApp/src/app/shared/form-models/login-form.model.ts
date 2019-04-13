import { FormControl, FormGroup, Validators } from "@angular/forms";

/** Модель на странице входа */
export let loginFormModel = new FormGroup({
  /** UserName, Email или Phone */
  'login': new FormControl(null, [Validators.required, Validators.minLength(3)]),

  /** Пароль */
  'password': new FormControl(null, [Validators.required, Validators.minLength(3)])
});

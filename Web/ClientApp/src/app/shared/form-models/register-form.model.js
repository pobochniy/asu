"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var forms_1 = require("@angular/forms");
/** Модель на странице входа */
exports.registerFormModel = new forms_1.FormGroup({
    /** UserName */
    'username': new forms_1.FormControl(null, [forms_1.Validators.required, forms_1.Validators.minLength(3)]),
    /** Пароль */
    'password': new forms_1.FormControl(null, [forms_1.Validators.required, forms_1.Validators.minLength(6)]),
    /** Пароль */
    'passwordConfirm': new forms_1.FormControl(null),
    /** Телефон */
    'phone': new forms_1.FormControl(null),
    /** Email */
    'email': new forms_1.FormControl(null, [forms_1.Validators.required, forms_1.Validators.email])
});
//# sourceMappingURL=register-form.model.js.map
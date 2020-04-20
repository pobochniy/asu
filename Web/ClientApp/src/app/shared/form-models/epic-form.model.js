"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var forms_1 = require("@angular/forms");
exports.epicFormModel = new forms_1.FormGroup({
    'id': new forms_1.FormControl(null, [forms_1.Validators.required]),
    'reporter': new forms_1.FormControl(null, [forms_1.Validators.required]),
    'priorityEnum': new forms_1.FormControl(null, [forms_1.Validators.required]),
    'name': new forms_1.FormControl(null, [forms_1.Validators.required]),
    'description': new forms_1.FormControl(null, [forms_1.Validators.required]),
    'dueDate': new forms_1.FormControl(null, [forms_1.Validators.required])
});
//# sourceMappingURL=epic-form.model.js.map
import { FormGroup, FormControl, Validators } from "@angular/forms";

export let epicFormModel = new FormGroup({

  'id': new FormControl(null, [Validators.required]),

  'reporter': new FormControl(null, [Validators.required]),

  'priorityEnum': new FormControl(null, [Validators.required]),

  'name': new FormControl(null, [Validators.required]),

  'description': new FormControl(null, [Validators.required]),

  'dueDate': new FormControl(null, [Validators.required])

})

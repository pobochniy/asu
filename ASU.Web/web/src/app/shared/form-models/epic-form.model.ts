import { FormGroup, FormControl, Validators } from "@angular/forms";

export let epicFormModel = new FormGroup({

  id: new FormControl(0, [Validators.required]),

  assignee: new FormControl(null, null),

  reporter: new FormControl(null, [Validators.required]),

  priority: new FormControl(null, [Validators.required]),

  name: new FormControl(null, [Validators.required]),

  description: new FormControl(null, [Validators.required]),

  dueDate: new FormControl(null, [Validators.required])

})

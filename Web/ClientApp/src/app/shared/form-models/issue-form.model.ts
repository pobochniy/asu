import { FormControl, FormGroup, Validators } from "@angular/forms";

/** Модель создания события */
export let issueFormModel = new FormGroup({

  /** Исполнитель */
  'assignee': new FormControl(null, [Validators.required]),

  /** Инициатор */
  'reporter': new FormControl(null, [Validators.required]),

  /** Сводка */
  'summary': new FormControl(null, [Validators.required]),

  /** Описание */
  'description': new FormControl(null, [Validators.required]),



});

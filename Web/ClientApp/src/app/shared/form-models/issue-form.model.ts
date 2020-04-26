import { FormControl, FormGroup, Validators } from "@angular/forms";

/** Модель создания события */
export let issueFormModel = new FormGroup({

  'id': new FormControl(null, null),

  /** Исполнитель */
  'assignee': new FormControl(null, null),

  /** Инициатор */
  'reporter': new FormControl(null, [Validators.required]),

  /** Сводка */
  'summary': new FormControl(null, [Validators.required]),

  /** Описание */
  'description': new FormControl(null, null),

  /** Тип */
  'type': new FormControl(null, [Validators.required]),

  /** Статус */
  'status': new FormControl(0, [Validators.required]),

  /** Приоритет */
  'priority': new FormControl(1, [Validators.required]),

  /** Предполагаемое время инициатора */
  'assigneeEstimatedTime': new FormControl(null, null),

  /**Предполагаемое время инициатора */
  'reporterEstimatedTime': new FormControl(null, null),

  /** Дата создания события */
  'dueDate': new FormControl(null, null),

  /** Ссылки на эпики */
  'epicLink': new FormControl(null, null)

});

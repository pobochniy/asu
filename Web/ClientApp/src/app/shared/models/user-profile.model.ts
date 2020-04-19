/** Пользователь */
export class UserProfileModel {
  /** GUID */
  public id: string;

  /** Логин */
  public userName: string;

  /** Эмейл */
  public email?: string;

  /** Телефон */
  public phone?: string;
}

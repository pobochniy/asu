/** Пользователь */
export class UserProfileModel {
  /** GUID */
  public id: string;

  /** Логин */
  public login: string;

  /** Эмейл */
  public email?: string;

  /** Телефон */
  public phone?: string;

  public userName: string;
}

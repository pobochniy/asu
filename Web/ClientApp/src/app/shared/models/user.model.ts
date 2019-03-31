/** Пользователь */
export class UserModel {

  /** Логин */
  public userName: string;

  /** Эмейл */
  public email?: string;

  /** Телефон */
  public phone?: string;

  /** Список ролей */
  public roles: string[];
}

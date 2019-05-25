/** Пользователь */
export class UserModel {

  /** Логин */
  public login: string;

  /** Эмейл */
  public email?: string;

  /** Телефон */
  public phone?: string;

  /** Список ролей */
  public roles: string[];
}

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

  constructor(obj: any = {}) {
    this.id = obj.id;
    this.email = obj.email;
    this.phone = obj.phone;
    this.userName = obj.userName;
  }

  get shortName(): string {
    return this.userName || this.email || this.phone!;
  }

}

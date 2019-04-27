export class PushChatModel {
  public message: string;
  public to?: Array<string>;
  public privat?: Array<string>;

  constructor(text: string) {
    this.to = this.getToArray(text);
    this.privat = this.getPrivatArray(text);
    this.message = text.trim();
  }

  private getToArray(text: string): Array<string> | undefined {
    debugger

    let start = text.indexOf("to [");
    if (start === -1) return undefined;

    let end = text.indexOf("]");
    let names = text.substring(start + 4, end - start);

    let res = names.split(",");

    res = res.map(x => {
      return x.trim();
    });

    //Написать тесты
    //Переделать на регулярки
       
    return res;
  }

  private getPrivatArray(text: string): Array<string> | undefined {

    return undefined;
  }
}

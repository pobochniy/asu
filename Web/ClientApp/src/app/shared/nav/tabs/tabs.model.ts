export class TabsModel {
  public id: number;
  public url: string;
  public isActive: boolean = true;

  constructor(data: any) {
    this.url = data.url;
    this.id = this.isMain ? 0 : data.id;
  }

  public get isMain(): boolean {
    return this.mainTabs.indexOf(this.url) > -1;
  }

  private mainTabs = [
    '/',
    '/issue/list',
    '/epic/list',
    '/rolemanagement'
  ];
}

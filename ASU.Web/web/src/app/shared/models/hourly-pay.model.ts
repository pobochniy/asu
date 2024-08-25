export class HourlyPayModel {
  constructor(
    public id: number,
    public userId: string,
    public startedDate: Date,
    public cash: number,
    public userIdCreated: string,
    public create: Date
  ) {
  }
}

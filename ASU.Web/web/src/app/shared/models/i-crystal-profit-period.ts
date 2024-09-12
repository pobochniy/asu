export interface ICrystalProfitPeriod {
  id: string;
  from: string;
  to: string;
  created: string;
  userCreated: string;
  payments: ICrystalPayments[];
}

export interface ICrystalPayments {
  id: string;
  userId: string;
  cash: number;
}

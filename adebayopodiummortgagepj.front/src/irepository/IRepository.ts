export interface IProduct {
  id: number;
  interestRate: string;
  baseLoanToValue: number;
  interestType: string;
  lender: ILender;
}

export interface ILender {
  id: number;
  name: string;
}

export interface ICustomer {
  id: string;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  email: string;
}

export interface IMortgage {
  id: number;
  depositAmount: number;
  propertyValue: number;
  customer: ICustomer;
}

export interface IManagerResponse<T> {
  data: T;
  message: string;
  isSuccess: boolean;
}

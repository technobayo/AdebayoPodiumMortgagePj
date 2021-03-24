import { ICustomer, IManagerResponse } from "@/irepository/IRepository";
import axios from "axios";

export class CustomerManager {
  BASE_URL = process.env.VUE_APP_BASE_URL;
  public async registerCustomer(
    customer: ICustomer
  ): Promise<IManagerResponse<ICustomer>> {
    const response = await axios.post(`${this.BASE_URL}/customer`, customer);
    //console.log(response.data);
    return response.data;
  }
}

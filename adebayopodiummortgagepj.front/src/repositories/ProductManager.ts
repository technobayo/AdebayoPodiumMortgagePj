import {
  IManagerResponse,
  IMortgage,
  IProduct
} from "@/irepository/IRepository";
import axios from "axios";

export class ProductManager {
  BASE_URL = process.env.VUE_APP_BASE_URL;
  public async getAllProducts(): Promise<IProduct[]> {
    const products = await axios.get(`${this.BASE_URL}/product`);
    //console.log(products.data);
    return products.data;
  }

  public async createCustomerProducts(
    mortgage: IMortgage
  ): Promise<IManagerResponse<IProduct[]>> {
    const products = await axios.post(`${this.BASE_URL}/product`, mortgage);
    //console.log(products.data);
    return products.data;
  }
}

<template>
  <div>
    <table class="table">
      <tbody>
        <tr>
          <td>
            <label for="firstName">First Name</label>
          </td>
          <td>
            <input type="string" id="firstName" v-model="customer.firstName" />
          </td>
        </tr>
        <tr>
          <td>
            <label for="lastName">Last Name</label>
          </td>
          <td>
            <input type="string" id="lastName" v-model="customer.lastName" />
          </td>
        </tr>
        <tr>
          <td>
            <label for="dateOfBirth">Date of Birth</label>
          </td>
          <td>
            <datepicker
              name="birthdate"
              v-model="customer.dateOfBirth"
            ></datepicker>
          </td>
        </tr>
        <tr>
          <td>
            <label for="email">Email</label>
          </td>
          <td>
            <input type="string" id="email" v-model="customer.email" />
          </td>
        </tr>
        <tr>
          <td></td>
          <td>
            <button id="btnSubmit" @click="submit">Submit</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { ICustomer, IManagerResponse } from "../irepository/IRepository";
import { CustomerManager } from "../repositories/CustomerManager";
import Datepicker from "vuejs-datepicker";

const customerManager = new CustomerManager();

@Component({
  name: "Register",
  components: { Datepicker }
})
export default class Register extends Vue {
  async submit() {
    this.response = await customerManager.registerCustomer(this.customer);
    if (this.response.isSuccess) {
      alert(`Your Id is ${this.response.data.id}`);
    } else {
      alert(`Error: ${this.response.message}`);
    }
  }

  customer: ICustomer = {
    id: "",
    firstName: "",
    lastName: "",
    dateOfBirth: new Date(),
    email: ""
  };

  response: IManagerResponse<ICustomer> = {
    data: this.customer,
    message: "",
    isSuccess: false
  };
}
</script>

<style lang="scss" scoped>
@import "@/styles/style.scss";
</style>

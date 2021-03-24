<template>
  <div>
    <h1>Mortgage Request</h1>
    <h3>Enter details below</h3>
    <table class="table">
      <tbody>
        <tr>
          <td><label for="userId">User Id</label></td>
          <td>
            <input type="string" id="userId" v-model="mortgage.customer.id" />
          </td>
        </tr>
        <tr>
          <td><label for="propertyValue">Property Value</label></td>
          <td>
            <input
              type="number"
              id="propertyValue"
              v-model="mortgage.propertyValue"
            />
          </td>
        </tr>
        <tr>
          <td><label for="depositAmount">Deposit Amount</label></td>
          <td>
            <input
              type="number"
              id="depositAmount"
              v-model="mortgage.depositAmount"
            />
          </td>
        </tr>
        <tr>
          <td></td>
          <td>
            <button id="btnSubmit" @click="submit">
              Submit
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IMortgage } from "../irepository/IRepository";

@Component({
  name: "MortgageRequest",
  components: {}
})
export default class MortgageRequest extends Vue {
  mortgage: IMortgage = {
    id: 0,
    depositAmount: 0,
    propertyValue: 0,
    customer: {
      id: "",
      firstName: "",
      lastName: "",
      dateOfBirth: new Date(),
      email: ""
    }
  };

  submit() {
    this.$emit("submit:click", this.mortgage);
  }
}
</script>

<style lang="scss" scoped>
@import "@/styles/style.scss";
</style>

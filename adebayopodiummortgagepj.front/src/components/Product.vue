<template>
  <div>
    <hr />
    {{ this.message }}
    <p></p>
    <table class="table">
      <thead>
        <tr>
          <th>Lender</th>
          <th>InterestRate</th>
          <th>InterestType</th>
          <th>LoanToValue</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in product" :key="item.id">
          <td>{{ item.lender.name }}</td>
          <td>{{ item.interestRate }}</td>
          <td>{{ item.interestType }}</td>
          <td><{{ item.baseLoanToValue }}%</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import { IProduct } from "../irepository/IRepository";

@Component({
  name: "Product",
  components: {}
})
export default class Product extends Vue {
  @Prop() product!: IProduct[];
  @Prop() message!: string;
}
</script>

<style lang="scss" scoped>
.table {
  width: 50%;
  margin-left: auto;
  margin-right: auto;
}

tr {
  padding: 1.3rem;
}
</style>

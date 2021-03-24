<template>
  <div class="home">
    <prompt
      v-bind:message="this.response"
      @close="close"
      v-show="this.isPromptVisible"
    >
    </prompt>
    <p></p>
    <mortgage-request @submit:click="submit"></mortgage-request>
    <p></p>
    <product
      v-show="this.managerResponse.isSuccess"
      v-bind:product="this.product"
      v-bind:message="this.message"
    >
    </product>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Product from "../components/Product.vue";
import Prompt from "../components/Prompt.vue";
import MortgageRequest from "../components/MortgageRequest.vue";
import {
  IManagerResponse,
  IMortgage,
  IProduct
} from "../irepository/IRepository";
import { ProductManager } from "../repositories/ProductManager";

const productManager = new ProductManager();

@Component({
  components: {
    Product,
    Prompt,
    MortgageRequest
  }
})
export default class Home extends Vue {
  response: string = "";
  isPromptVisible: boolean = false;
  product: IProduct[] = [];
  message: string = "";

  managerResponse: IManagerResponse<IProduct[]> = {
    data: [],
    message: "",
    isSuccess: false
  };

  close() {
    this.isPromptVisible = false;
  }

  async submit(mortgage: IMortgage) {
    this.managerResponse = await productManager.createCustomerProducts(
      mortgage
    );
    if (!this.managerResponse.isSuccess) {
      this.response = this.managerResponse.message;
      this.isPromptVisible = true;
    }
    this.product = this.managerResponse.data;
    this.message = this.managerResponse.message;
  }
}
</script>

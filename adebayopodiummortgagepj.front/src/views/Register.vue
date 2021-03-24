<template>
  <div class="about">
    <h1>New Customer Registraion</h1>
    <h3>Please register below</h3>
    <register></register>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import Register from "../components/Register.vue";

@Component({
  name: "About",
  components: { Register }
})
export default class About extends Vue {}
</script>

<style lang="scss" scoped></style>

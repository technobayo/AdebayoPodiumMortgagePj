<template>
  <div class="container">
    <div>
      <label>{{ message }}</label>

      <p></p>

      <button @click="close">close</button>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

@Component({
  name: "Prompt",
  components: {}
})
export default class Prompt extends Vue {
  @Prop({ required: false, type: String }) message?: string;

  close() {
    this.$emit("close");
  }
}
</script>

<style lang="scss" scoped>
.container {
  width: 100%;
  height: 70px;
  background-color: antiquewhite;
  padding: 0.3rem;
  margin: 0.2rem;
}

label {
  color: red;
}

button {
  cursor: pointer;
}
</style>

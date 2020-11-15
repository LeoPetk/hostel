import { ref } from "vue";

const useTest = () => {
  const testField = ref(32);
  const bla = ref("testing hooks");

  return [testField, bla];
};

export default useTest;

const useValidation = (properties: string[]) => {
  const validations: boolean[] = [];

  properties.forEach((value) => {
    if (value == "") validations.push(false);
    else validations.push(true);
  });

  return validations;
};

export default useValidation;

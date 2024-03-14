import { _isNumberValue } from '@angular/cdk/coercion';

export const ToFormData = {
  createFormData(
    object: Object | any,
    form?: FormData,
    namespace?: string
  ): FormData {
    const formData = form || new FormData();
    for (const property in object) {
      if (!object.hasOwnProperty(property) || !object[property]) {
        continue;
      }
      let formKey = '';

      // for control generate by running number
      if (_isNumberValue(property)) {
        formKey = namespace ? `${namespace}[${property}]` : property;
      } else {
        formKey = namespace ? `${namespace}.${property}` : property;
      }

      if (
        typeof object[property] === 'object' &&
        !(object[property] instanceof File) &&
        isNaN(object[property])
      ) {
        let i = 0;
        for (const file of object[property].files) {
          formData.append(formKey, file);
          i++;
        }
      } else {
        formData.append(formKey, object[property]);
      }
    }
    return formData;
  },
};

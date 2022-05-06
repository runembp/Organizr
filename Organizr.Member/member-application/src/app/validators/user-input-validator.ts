import { AbstractControl, ValidatorFn, ValidationErrors } from "@angular/forms";

export class Validation {

  static match(controlName: string, checkControlName: string): ValidatorFn {
    return (controls: AbstractControl) => {
      const control = controls.get(controlName);
      const checkControl = controls.get(checkControlName);
      if (checkControl?.errors && !checkControl.errors['matching']) {
        return null;
      }
      if (control?.value !== checkControl?.value) {
        controls.get(checkControlName)?.setErrors({ matching: true });
        return { matching: true };
      } else {
        return null;
      }
    };
  }

  static noWhiteSpace(check: string): ValidatorFn {
    return (controls: AbstractControl) => {
      const control = controls.get(check);

      let bla = control?.value;
      console.log(bla.trim().length);

      if ((control?.value as string).indexOf(' ') >= 0 && (control?.value as string).trim().length === 0) {
        controls.get(check)?.setErrors({ doh: true });
        //console.log(control?.value);
        return { doh: true };
      }
      return null;

    }
  }
}
import { AbstractControl, ValidatorFn } from "@angular/forms";

export class Validation {

  static match(controlName: string, checkControlName: string): ValidatorFn {
    return (controls: AbstractControl) => {
      const control = controls.get(controlName);
      const checkControl = controls.get(checkControlName);
   
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

      if ((control?.value as string).indexOf(' ') >= 0 && (control?.value as string).trim().length === 0) {
        controls.get(check)?.setErrors({ containsOnlyWhiteSpaces: true });
        return { containsOnlyWhiteSpaces: true };
      }
      return null;
    }
  }
}
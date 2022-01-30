import { AbstractControl } from "@angular/forms";

export function UserNameValidator(control:AbstractControl):{[key:string]:any } | null 
{
    let isValid = true; 
    if (control.value != "abcd")
        isValid = false;
    return isValid ? null : { "myvalidation": {valid: false, value: control.value} };
}   
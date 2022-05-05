import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../api-client/api-client.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../User';
import { Validation } from '../validators/user-input-validator';
import { AbstractControl } from "@angular/forms";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})

export class SignUpComponent implements OnInit {

  genders = new Map([
    ['Mand', 0],
    ['Kvinde', 1],
    ['Udefineret', 2]
  ]);

  createUserForm: FormGroup;
  submitted = false;

  constructor(private apiClient: ApiClientService) { }

  ngOnInit(): void {
    this.createUserForm = new FormGroup({
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      phoneNumber: new FormControl(null, Validators.required),
      gender: new FormControl(null, Validators.required),
      address: new FormControl(null, Validators.required),
      email: new FormControl(null, Validators.required),

      password: new FormControl(null, Validators.required),
      password2: new FormControl(null, Validators.required),
    }, {
      validators: [Validation.match('password', 'password2')]
    });
  };

  get f(): { [key: string]: AbstractControl } {
    return this.createUserForm.controls;
  }

  user: User;

  onSubmit() {
    this.user = {
      firstName: this.createUserForm.get('firstName')?.value,
      lastName: this.createUserForm.get('lastName')?.value,
      email: this.createUserForm.get('email')?.value,
      phoneNumber: this.createUserForm.get('phoneNumber')?.value,
      address: this.createUserForm.get('address')?.value,
      password: this.createUserForm.get('password')?.value,
      gender: Number(this.createUserForm.get('gender')?.value)
    }

    this.apiClient.createOrganizrUser(this.user).subscribe();
    this.createUserForm.reset();
  };

}
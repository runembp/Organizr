import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiClientService } from '../api/api-client.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { GenderEnum } from '../Gender.enum';
import { User } from '../User';
import { UsersComponent } from '../users/users.component';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public genders = Object.values(GenderEnum);

  createUserForm: FormGroup;

  constructor(private apiClient: ApiClientService,
    private formBuilder: FormBuilder) { 

     
    }

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
    });
  }

  onSubmit(){
    this.createUserForm.reset();
    const user: User = {
      firstName: this.createUserForm.get('firstName')?.value,
      lastName: this.createUserForm.get('lastName')?.value,
      email: this.createUserForm.get('email')?.value,
      phoneNumber: this.createUserForm.get('phoneNumber')?.value,
      address: this.createUserForm.get('address')?.value
    }  
    this.apiClient.createOrganizrUser(user);
  };


}

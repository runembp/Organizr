import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../../services/api-client/api-client.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Validation } from '../../validators/user-input-validator';
import { AbstractControl } from "@angular/forms";
import { NotificationType } from 'src/app/notification.message';
import { NotificationServiceService } from 'src/app/services/notification-message/notification-service.service';
import { Router } from '@angular/router';


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

  constructor(private apiClient: ApiClientService, private notificationService: NotificationServiceService, private router: Router) { }

  ngOnInit(): void {

    this.createUserForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      phoneNumber: new FormControl('', [Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/), Validators.maxLength(8), Validators.minLength(8)]),
      gender: new FormControl('', Validators.required),
      address: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),

      password: new FormControl(null, [Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/)]),
      password2: new FormControl(null, Validators.required),
    }, {
      validators: [Validation.match('password', 'password2'), Validation.noWhiteSpace('firstName'),  Validation.noWhiteSpace('lastName')]
    });
  };

  get f(): { [key: string]: AbstractControl } {
    return this.createUserForm.controls;
  }

  user: any;
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

    this.apiClient.createOrganizrUser(this.user).subscribe(response => {
      if (response.succeeded) {
        this.notificationService.sendMessage({
          message: "Du profil er blevet oprettet - du kan nu logge ind.",
          type: NotificationType.success
        });

        this.router.navigateByUrl('/login');
      }
      this.createUserForm.reset();
    });
    
  };
}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  constructor() { }

  resetPasswordForm: FormGroup;

  ngOnInit(): void {
    this.resetPasswordForm = new FormGroup({
      email: new FormControl('', Validators.required)
    });
  }

  send(): void {

  }
}

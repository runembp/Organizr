import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiClientService } from '../../services/api-client/api-client.service';
import { Router } from '@angular/router';
import { TokenStorageService } from '../../services/token-storage/token-storage.service';
import { DataSharingService } from '../../services/shared/data-sharing.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loginUser: any;

  constructor(private apiClient: ApiClientService, private router: Router, private tokenStorage: TokenStorageService, private dataSharing: DataSharingService) { }

  ngOnInit(): void {

    this.loginForm = new FormGroup({
      email: new FormControl(null, [Validators.required]),
      password: new FormControl(null, [Validators.required]),
      rememberMe: new FormControl(false)
    });
  }

  onSubmit(): void {

    this.loginUser = {
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value,
      rememberMe: this.loginForm.get('rememberMe')?.value
    };

    this.login(this.loginUser);
  }

  login(user: any): void {

    this.apiClient.login(user).subscribe(response => {
      if (response.succeeded === true) {

        const userData = {
          token: response.token,
          email: response.email,
          id: response.id
        };

        this.tokenStorage.saveUser(JSON.stringify(userData));

        this.dataSharing.isUserLoggedIn.next(true);
        this.dataSharing.loggedInUser.next(this.tokenStorage.getUser().email);

        return this.router.navigateByUrl('/')
      };
    });

  }

}
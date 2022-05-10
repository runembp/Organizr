import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { LoginComponent } from './components/login/login.component';
import { AppNavbarComponent } from './components/app-navbar/app-navbar.component';
import { DataSharingService } from './services/data-sharing/data-sharing.service';


@NgModule({
  declarations: [
    AppComponent,
    AboutUsComponent,
    SignUpComponent,
    ContactUsComponent,
    LoginComponent,
    AppNavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    GoogleMapsModule
  ],
  providers: [DataSharingService],
  bootstrap: [AppComponent]
})
export class AppModule { }

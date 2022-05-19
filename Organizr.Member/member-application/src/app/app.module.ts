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
import { DataSharingService } from './services/shared/data-sharing.service';
import { ConfigurationConstantsService } from './services/shared/configuration-constants.service';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ContactUsFormComponent } from './components/contact-us-form/contact-us-form.component';
import { GroupsComponent } from './components/groups/groups.component';
import { AllGroupsComponent } from './components/all-groups/all-groups.component';
import { MyGroupsComponent } from './components/my-groups/my-groups.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { GroupComponent } from './components/group/group.component';
import { UserComponent } from './components/user/user.component';
import { MemberProfileComponent } from './components/member-profile/member-profile.component';
import { PublicNewspostsComponent } from './components/public-newsposts/public-newsposts.component';
import { DatePipe } from '@angular/common'

@NgModule({
  declarations: [
    AppComponent,
    AboutUsComponent,
    SignUpComponent,
    ContactUsComponent,
    LoginComponent,
    AppNavbarComponent,
    ContactUsFormComponent,
    ResetPasswordComponent,
    GroupsComponent,
    AllGroupsComponent,
    MyGroupsComponent,
    GroupComponent,
    UserComponent,
    MemberProfileComponent,
    PublicNewspostsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    GoogleMapsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [DataSharingService, ConfigurationConstantsService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }

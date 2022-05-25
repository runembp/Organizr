import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { LoginComponent } from './components/login/login.component';
import { ContactUsFormComponent } from './components/contact-us-form/contact-us-form.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { GroupsComponent } from './components/groups/groups.component';
import { GroupComponent } from './components/group/group.component';
import { UserComponent } from './components/user/user.component';
import { MemberProfileComponent } from './components/member-profile/member-profile.component';
import { AuthGuardService } from './services/authentication/auth-guard.service';
import { PublicNewspostsComponent } from './components/public-newsposts/public-newsposts.component';
import { CreateNewspostComponent } from './components/create-newspost/create-newspost.component';

const routes: Routes = [
  { path: 'news', component: PublicNewspostsComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'contact-us-form', component: ContactUsFormComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  {
    canActivate: [AuthGuardService],
    path: 'user',
    component: UserComponent,
    children: [
      {
        path: '',
        outlet: 'sidebar',
        component: MemberProfileComponent,
        canActivateChild: [AuthGuardService]
      },
      {
        path: 'overview',
        outlet: 'sidebar',
        component: GroupsComponent,
        canActivateChild: [AuthGuardService]
      },
      {
        path: 'profile',
        outlet: 'sidebar',
        component: MemberProfileComponent,
        canActivateChild: [AuthGuardService]
      },
      {
        path: 'group/:id',
        outlet: 'sidebar',
        component: GroupComponent,
        canActivateChild: [AuthGuardService],     
      },

      {
        path: 'create-newspost',
        outlet: 'sidebar',
        component: CreateNewspostComponent,
        canActivateChild: [AuthGuardService],
      }
      


    ]
  },

  { path: '', redirectTo: '/news', pathMatch: 'full' },
  //{ path: '**', redirectTo: '/', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

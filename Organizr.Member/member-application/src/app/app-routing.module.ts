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

const routes: Routes = [
  { path: 'sign-up', component: SignUpComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'contact-us-form', component: ContactUsFormComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  {
    path: 'user',
    component: UserComponent,
    children: [
      {
        path: '',
        outlet: 'sidebar',
        component: GroupComponent
      },
      {
        path: 'overview',
        outlet: 'sidebar',
        component: GroupsComponent
      }
    ]
  },


  { path: '', redirectTo: '/login', pathMatch: 'full' },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

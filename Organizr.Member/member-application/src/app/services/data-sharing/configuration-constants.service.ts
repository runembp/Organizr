import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class ConfigurationConstantsService {

  public organizationAddress: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public organizationPhoneNumber: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public organizationEmailAddress: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public predeterminedGroupToAssignNewMembersTo: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateCommentsOnNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateAdministratorMemberAbilityToCommentOnNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateBasicMemberAbilityToCommentOnNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateAbilityForAllMembersToCreateNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public frontpageTopTextBox: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public loginForgottenPassword: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public aboutUsPage: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public contactPageTopTextBox: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public contactPageLeftTextBox: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public createMembershipTopText: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  public memberApplicationCss: BehaviorSubject<any> = new BehaviorSubject<any>(null);

}
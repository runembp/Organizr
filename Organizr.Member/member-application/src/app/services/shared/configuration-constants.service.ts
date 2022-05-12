import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class ConfigurationConstantsService {

  public organizationAddress: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public organizationPhoneNumber: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public organizationEmailAddress: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public predeterminedGroupToAssignNewMembersTo: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  public activateCommentsOnNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateAdministratorMemberAbilityToCommentOnNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateBasicMemberAbilityToCommentOnNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public activateAbilityForAllMembersToCreateNews: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  public frontpageTopTextBox: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public loginForgottenPassword: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public aboutUsPage: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public contactPageTopTextBox: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public contactPageLeftTextBox: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public createMembershipTopText: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  public memberApplicationCss: BehaviorSubject<any> = new BehaviorSubject<any>(null);

}
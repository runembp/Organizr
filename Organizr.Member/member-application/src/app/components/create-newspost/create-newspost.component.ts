import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MembersApiClientService } from 'src/app/services/api-client/members/members-api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';

@Component({
  selector: 'app-create-newspost',
  templateUrl: './create-newspost.component.html',
  styleUrls: ['./create-newspost.component.css']
})
export class CreateNewspostComponent implements OnInit {

  constructor(private tokenStorage: TokenStorageService, private memberApiClient: MembersApiClientService) { }

  myGroups: any[] = [];
  memberships: any[] = [];

  newNewsPostForm: FormGroup;
  submitted = false;

  ngOnInit(): void {

    const loggedInUser = this.tokenStorage.getUser().id;

    this.memberApiClient.getMembersGroups(loggedInUser).subscribe(member => {
      this.memberships = member.memberships;
      this.myGroups = this.memberships.map(x => x);
    });

    this.newNewsPostForm = new FormGroup({
      group: new FormControl('', Validators.required),
      title: new FormControl('', Validators.required),
      content: new FormControl('', Validators.required),
      isPublic: new FormControl('')
    });

  }

  onSubmit(): void {
    const newspost = {
      group: this.newNewsPostForm.get('group')?.value,
      title: this.newNewsPostForm.get('title')?.value,
      content: this.newNewsPostForm.get('content')?.value,
      isPublic: this.newNewsPostForm.get('isPublic')?.value
    };

    console.log(newspost);
  }

}

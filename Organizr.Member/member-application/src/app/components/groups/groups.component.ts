import { Component, OnInit } from '@angular/core';
import { MembersApiClientService } from 'src/app/services/api-client/members/members-api-client.service';
import { MembergroupsApiClientService } from 'src/app/services/api-client/membergroups/membergroups-api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';


@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

  constructor(private tokenStorage: TokenStorageService, private memberApiClient: MembersApiClientService,
    private membergroupsApiClient: MembergroupsApiClientService) {
  }

  loggedInUser: any;
  allGroups: any[] = [];
  myGroups: any[] = [];
  memberships: any[] = [];

  ngOnInit(): void {

    this.loggedInUser = this.tokenStorage.getUser().id;

    this.membergroupsApiClient.getAllOpenGroupsWhereMemberHasNoMembership(this.loggedInUser).subscribe(groups => {
      this.allGroups = groups;
    });

    this.memberApiClient.getMembersGroups(this.loggedInUser).subscribe(member => {

      this.memberships = member.memberships;
      this.myGroups = this.memberships.map(x => x);

    });

  }
}
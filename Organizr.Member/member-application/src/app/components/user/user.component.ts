import { Component, OnInit } from '@angular/core';
import { MembersApiClientService } from 'src/app/services/api-client/members/members-api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private apiClient: MembersApiClientService, private tokenStorage: TokenStorageService, private route: ActivatedRoute, private router: Router) { }

  isUserLoggedIn: boolean;
  myGroups: any[] = [];
  loggedInUser: any;
  memberships: any[] = [];

  ngOnInit(): void {
    this.loggedInUser = this.tokenStorage.getUser().id;

    this.apiClient.getMembersGroups(this.loggedInUser).subscribe(member => {
      this.memberships = member.memberships;
      this.myGroups = this.memberships.map(x => x);
     
    });
  }

  navigate(path: string) {
    console.log(this.route)
    console.log(path)
    this.router.navigate([{ outlets: { sidebar: path } }],
      { relativeTo: this.route });
  }

  navigateBla(path: string, id: number) {
    this.router.navigate([{ outlets: { sidebar: [ path, id ] }}], { relativeTo: this.route });
  }


}

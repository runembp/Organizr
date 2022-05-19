import { Component, OnInit } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';
import { TokenStorageService } from 'src/app/services/token-storage/token-storage.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private apiClient: ApiClientService, private tokenStorage: TokenStorageService, private route: ActivatedRoute, private router: Router) { }

  isUserLoggedIn: boolean;
  myGroups: any[];
  loggedInUser: any;

  ngOnInit(): void {
    this.loggedInUser = this.tokenStorage.getUser().id;

    this.apiClient.getMembersGroups(this.loggedInUser).subscribe(value => {
      this.myGroups = value.groups;
    });
  }

  navigate(path: string) {
    this.router.navigate([{ outlets: { sidebar: path } }],
      { relativeTo: this.route });
  }



}

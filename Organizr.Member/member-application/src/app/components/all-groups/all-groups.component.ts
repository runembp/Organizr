import { Component, OnInit, Input } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';

@Component({
  selector: 'app-all-groups',
  templateUrl: './all-groups.component.html',
  styleUrls: ['./all-groups.component.css']
})
export class AllGroupsComponent implements OnInit {

  constructor(private apiClient: ApiClientService) { }

  @Input() groups: any[];
  @Input() userId: any;
  
  ngOnInit(): void {
    
  }

  joinGroup(groupId: number, memberId: number): void {
    this.apiClient.addMemberToGroup(groupId, memberId).subscribe(response => {
      if (response.succeeded) {
        // vis toast
      }
      
    }, err => console.log(err.error));
  }
}

import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ApiClientService } from 'src/app/services/api-client/api-client.service';

@Component({
  selector: 'app-my-groups',
  templateUrl: './my-groups.component.html',
  styleUrls: ['./my-groups.component.css']
})
export class MyGroupsComponent implements OnInit {

  constructor() { }

  @Input() userId: any;
  @Input() groups: any[];

  ngOnInit(): void {
    
  }

  leaveGroup(groupId: number, memberId: number): void {

  }

}

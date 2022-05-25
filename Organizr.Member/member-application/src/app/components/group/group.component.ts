import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewspostsApiClientService } from 'src/app/services/api-client/newsposts/newsposts-api-client.service';
import { DatePipe } from '@angular/common';
import { ConfigurationConstantsService } from 'src/app/services/shared/configuration-constants.service';
import { RouterStateSnapshot } from '@angular/router';


@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {

  id: number;
  newsposts: any[];
  canMemberCreateNews: boolean;

  constructor(private route: ActivatedRoute, private apiClient: NewspostsApiClientService,
    public datepipe: DatePipe, private configService: ConfigurationConstantsService,
    private router: Router) { }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.apiClient.getAllNewsPostsByGroupId(this.id).subscribe(newsposts => {
      this.newsposts = newsposts.map(newspost => newspost);
      this.newsposts.map(n => {
        n.createdAt = this.convertDate(n.createdAt);
      });
    });

    this.configService.activateAbilityForAllMembersToCreateNews.subscribe(value => this.canMemberCreateNews = value);
  }

  convertDate(date: any): string | null {
    let dateConverted = this.datepipe.transform(date, 'dd-MM-yyyy');
    return dateConverted;
  }

  navigate(path: string) {
    this.router.navigate([{ outlets: { sidebar: [ path ] }}], { relativeTo: this.route.parent });
  }
 
}

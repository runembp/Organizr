import { Component, OnInit } from '@angular/core';
import { NewspostsApiClientService } from 'src/app/services/api-client/newsposts/newsposts-api-client.service';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-public-newsposts',
  templateUrl: './public-newsposts.component.html',
  styleUrls: ['./public-newsposts.component.css']
})
export class PublicNewspostsComponent implements OnInit {

  constructor(private apiClient: NewspostsApiClientService, public datepipe: DatePipe) { }

  newsposts: any[] = [];

  ngOnInit(): void {
    this.apiClient.getAllNewsPosts().subscribe(newsposts => {
      this.newsposts = newsposts.sort((a, b) => new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime());
      
      this.newsposts.map(n => {
        n.createdAt = this.convertDate(n.createdAt);
      });

    });
  }

  convertDate(date: any): string | null {
    let dateConverted = this.datepipe.transform(date, 'dd-MM-yyyy');
    return dateConverted;
  }

}

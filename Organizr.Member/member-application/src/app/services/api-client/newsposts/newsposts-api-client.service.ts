import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NotificationServiceService } from '../../notification-message/notification-service.service';

@Injectable({
  providedIn: 'root'
})
export class NewspostsApiClientService {

  private apiUrl = environment.baseUrl;

  constructor(private http: HttpClient, private notificationService: NotificationServiceService) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }),
  };

  getAllNewsPosts(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'api/newsposts');
  }
}

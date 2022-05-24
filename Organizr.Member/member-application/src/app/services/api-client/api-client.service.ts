import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NotificationServiceService } from '../notification-message/notification-service.service';
import { NotificationType } from 'src/app/notification.message';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  private apiUrl = environment.baseUrl;

  constructor(private http: HttpClient, private notificationService: NotificationServiceService) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }),
  };

  // Config
  getAllConfigurations(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'api/configurations/');
  }
  

  // Login
  login(user: any): Observable<any> {

    return this.http.post<any>(
      this.apiUrl + 'api/login',
      JSON.stringify(user),
      this.httpOptions)
      .pipe(catchError(err => {
        return throwError(() => {
          this.notificationService.sendMessage({
            message: err.error.error,
            type: NotificationType.error
          });
        });
      }));
  }

}

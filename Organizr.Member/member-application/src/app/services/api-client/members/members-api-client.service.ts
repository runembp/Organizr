import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NotificationServiceService } from '../../notification-message/notification-service.service';
import { NotificationType } from 'src/app/notification.message';

@Injectable({
  providedIn: 'root'
})
export class MembersApiClientService {
  private apiUrl = environment.baseUrl;
  constructor(private http: HttpClient, private notificationService: NotificationServiceService) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }),
  };

  createMember(user: any): Observable<any> {
    return this.http
      .post<any>(
        this.apiUrl + 'api/members',
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

  getMembersGroups(memberId: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + `api/members/${memberId}/memberships/groups`)
  }

  getMemberById(memberId: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + `api/members/${memberId}`);
  }

  deleteMemberById(memberId: number): Observable<any> {
    return this.http.delete<any>(
      this.apiUrl + `api/members/${memberId}`,
      this.httpOptions
    ).pipe(
      catchError(err => {
        return throwError(() => {
          this.notificationService.sendMessage({
            message: err.error.error,
            type: NotificationType.error
          });
        });
      })
    )
  }

}
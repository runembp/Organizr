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
export class MembergroupsApiClientService {
  private apiUrl = environment.baseUrl;
  constructor(private http: HttpClient, private notificationService: NotificationServiceService) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }),
  };

  getAllOpenGroupsWhereMemberHasNoMembership(memberId: number): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + `api/groups/no-membership/${memberId}?open=true`);
  }

  removedMemberFromGroup(membershipId: number): Observable<any> {
    return this.http.delete(
      this.apiUrl + `api/memberships/members/${membershipId}`,
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

  addMemberToGroup(membership: any): Observable<any> {
    return this.http.post(
      this.apiUrl + `api/memberships`,
      JSON.stringify(membership),
      this.httpOptions)
      .pipe(
        catchError(err => {
          return throwError(() => {
            this.notificationService.sendMessage({
              message: err.error.error,
              type: NotificationType.error
            });
          });
        })
      );
  }
}
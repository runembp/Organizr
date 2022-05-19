import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NotificationServiceService } from '../notification-message/notification-service.service';
import { NotificationType } from 'src/app/notification.message';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  private apiUrl = environment.baseUrl;

  constructor(private http: HttpClient, private notificationService: NotificationServiceService, private router: Router) { }

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

  // Member
  createOrganizrUser(user: any): Observable<any> {
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
    return this.http.get<any>(this.apiUrl + `api/members/${memberId}/groups`)
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

  // Groups
  getAllGroups(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'api/groups');
  }

  removedMemberFromGroup(groupId: number, memberId: number): Observable<any> {
    return this.http.delete(
      this.apiUrl + `api/groups/${groupId}/members/${memberId}`,
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

  addMemberToGroup(groupId: number, memberId: number): Observable<any> {
    return this.http.patch(
      this.apiUrl + `api/groups/${groupId}/members/${memberId}`,
      '',
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
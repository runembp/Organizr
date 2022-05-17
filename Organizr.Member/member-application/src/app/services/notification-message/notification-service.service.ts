import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { NotificationMessage, NotificationType } from 'src/app/notification.message';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationServiceService {

  private notificationSubject: Subject<NotificationMessage> = new Subject<NotificationMessage>();

  sendMessage(message: NotificationMessage) {
      this.notificationSubject.next(message);
  }
  

  constructor(private toastr: ToastrService) { 
    this.notificationSubject.subscribe(message => {
      switch(message.type) {
        case NotificationType.success:
          this.toastr.success(message.message);
          break;
        case NotificationType.error:
          this.toastr.error(message.message);
          break;
        case NotificationType.warning:
          this.toastr.warning(message.message);
          break;
        case NotificationType.info:
          this.toastr.info(message.message);
          break;
        default:
          case NotificationType.info:
          this.toastr.info(message.message);
          break;
      }
    });
  }
}

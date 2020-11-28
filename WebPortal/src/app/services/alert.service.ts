import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private toastr: ToastrService) {
  }

  ModalNotification(title:string, text:string, type:SweetAlertIcon) {
    if(type == 'question'){
      return Swal.fire({
        title: title,
        text: text,
        icon: type,
        showCancelButton: true,
        focusConfirm: false,
        cancelButtonText: 'No, no borrar',
        confirmButtonText: 'Si, estoy seguro!'
      });  
    }
    return Swal.fire(title, text, type);
  }

  ToasterNotification(title:string, text:string, type:string){    
    switch(type){
      case "success":
        this.toastr.success(text, title);
      break;
      case "info":
        this.toastr.info(text, title);
      break;
      case "warning":
        this.toastr.warning(text, title);
      break;
      case "error":
        this.toastr.error(text, title);
      break;
    }    
  }
}

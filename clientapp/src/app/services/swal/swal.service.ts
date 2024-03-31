import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class SwalService {
  constructor(private router: Router) { }

  fireSwal(title: string, text: string, icon: SweetAlertIcon, route: string = ''): void {
    Swal.fire({
      title: title,
      text: text,
      icon: icon,
      color: 'white',
      background: '#424242',
      confirmButtonColor: '#ff9800'
    }).then(res => {
      if (route && (res.isConfirmed || res.isDismissed)) {
        this.router.navigate([route]);
      }
    });
  }
}

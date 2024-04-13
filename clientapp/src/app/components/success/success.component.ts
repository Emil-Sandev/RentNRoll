import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrl: './success.component.css',
})
export class SuccessComponent {
  constructor(private router: Router) {}

  redirectToMyRentals(): any {
    this.router.navigate(['/my-rentals']);
  }
}

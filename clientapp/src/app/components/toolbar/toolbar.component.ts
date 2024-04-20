import { Component, OnInit } from '@angular/core';
import { SidebarService } from '../../services/sidebar/sidebar.service';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.css'
})
export class ToolbarComponent implements OnInit {
  isAdmin: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private sidebarService: SidebarService, private authService: AuthenticationService, private router: Router) { }

  ngOnInit(): void {
    // initial value if there is something in local storage
    this.authService.isAdmin().subscribe({
      next: (data: boolean) => {
        this.isAdmin.next(data);
      },
    });

    this.authService.isAdminEmitter.subscribe((data: boolean) => {
      this.isAdmin.next(data);
    });
  }

  goToUsers() {
    this.router.navigate(['/admin/users']);
  }

  goToCars() {
    this.router.navigate(['/admin/cars']);
  }

  goToRentals() {
    this.router.navigate(['/admin/rentals']);
  }

  toggleSidebar() {
    this.sidebarService.toggleSidebar();
  }
}

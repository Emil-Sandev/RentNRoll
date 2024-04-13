import { Component, OnInit } from '@angular/core';
import { SidebarService } from '../../services/sidebar/sidebar.service';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.css'
})
export class ToolbarComponent implements OnInit {
  isAdmin: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private sidebarService: SidebarService, private authService: AuthenticationService) { }

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

  toggleSidebar() {
    this.sidebarService.toggleSidebar();
  }
}

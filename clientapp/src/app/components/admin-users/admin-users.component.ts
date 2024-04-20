import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { UsersAdminDTO } from '../../models/user.model';
import { PageEvent } from '@angular/material/paginator';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrl: './admin-users.component.css'
})
export class AdminUsersComponent implements OnInit {
  pageIndex: number = 0;
  usersAdminDTO: UsersAdminDTO = {} as UsersAdminDTO;

  displayedColumns: string[] = ['firstName', 'lastName', 'userName', 'email', 'phone', 'egn', 'actions'];

  constructor(private userService: UserService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(data => this.usersAdminDTO = data);
  }

  handlePageEvent(event: PageEvent): void {
    this.pageIndex++;
    this.refreshUsers();
  }

  deleteUser(id: string) {
    this.dialog.open(DeleteDialogComponent, {
      width: '1200px',
      height: '600px',
      data: { type: 'user', id: id },
    });
  }

  refreshUsers() {
    this.userService.getUsers(this.pageIndex).subscribe(data => this.usersAdminDTO = data);
  }
}

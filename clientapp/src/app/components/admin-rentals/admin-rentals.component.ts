import { Component, OnInit } from '@angular/core';
import { RentalService } from '../../services/rental/rental.service';
import { RentalsAdminDTO } from '../../models/rental.model';
import { PageEvent } from '@angular/material/paginator';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-admin-rentals',
  templateUrl: './admin-rentals.component.html',
  styleUrl: './admin-rentals.component.css'
})
export class AdminRentalsComponent implements OnInit {
  pageIndex: number = 0;
  rentalsAdminDTO: RentalsAdminDTO = {} as RentalsAdminDTO;

  displayedColumns: string[] = ['customer', 'customerEmail', 'phone', 'egn', 'model', 'brand', 'category', 'rentalDate', 'returnDate', 'totalPrice', 'actions'];

  constructor(private rentalService: RentalService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.rentalService.getRentals().subscribe(data => this.rentalsAdminDTO = data);
  }

  handlePageEvent(event: PageEvent): void {
    this.pageIndex++;
    this.refreshRentals();
  }

  deleteRental(model: string) {
    this.dialog.open(DeleteDialogComponent, {
      width: '1200px',
      height: '600px',
      data: { type: 'rental', id: model },
    });
  }

  refreshRentals(): void {
    this.rentalService.getRentals(this.pageIndex).subscribe(data => this.rentalsAdminDTO = data);
  }
}

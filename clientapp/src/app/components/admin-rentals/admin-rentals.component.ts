import { Component, OnInit } from '@angular/core';
import { RentalService } from '../../services/rental/rental.service';
import { RentalsAdminDTO } from '../../models/rental.model';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-admin-rentals',
  templateUrl: './admin-rentals.component.html',
  styleUrl: './admin-rentals.component.css'
})
export class AdminRentalsComponent implements OnInit {
  pageIndex: number = 0;
  rentalsAdminDTO: RentalsAdminDTO = {} as RentalsAdminDTO;

  displayedColumns: string[] = ['customer', 'customerEmail', 'phone', 'egn', 'model', 'brand', 'category', 'rentalDate', 'returnDate', 'totalPrice', 'actions'];

  constructor(private rentalService: RentalService) { }

  ngOnInit(): void {
    this.rentalService.getRentals().subscribe(data => this.rentalsAdminDTO = data);
  }

  handlePageEvent(event: PageEvent): void {
    this.pageIndex++;
    this.refreshRentals();
  }

  refreshRentals(): void {
    this.rentalService.getRentals(this.pageIndex).subscribe(data => this.rentalsAdminDTO = data);
  }
}

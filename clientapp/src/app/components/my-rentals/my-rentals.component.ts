import { Component, OnInit } from '@angular/core';
import { RentalService } from '../../services/rental/rental.service';
import { RentalDetailsUserDTO } from '../../models/rental.model';

@Component({
  selector: 'app-my-rentals',
  templateUrl: './my-rentals.component.html',
  styleUrl: './my-rentals.component.css'
})
export class MyRentalsComponent implements OnInit {
  rentals: RentalDetailsUserDTO[] = [];
  displayedColumns: string[] = ['model', 'brand', 'category', 'rentalDate', 'returnDate', 'totalPrice'];

  constructor(private rentalService: RentalService) { }

  ngOnInit(): void {
    this.rentalService.getUserRentals().subscribe(data => {
      this.rentals = data;
      console.log(this.rentals);
    });
  }
}

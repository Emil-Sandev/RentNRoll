import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CarService } from '../../services/car/car.service';
import { RentalService } from '../../services/rental/rental.service';

@Component({
  selector: 'app-delete-car-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.css'
})
export class DeleteDialogComponent {
  constructor(public dialogRef: MatDialogRef<DeleteDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any, private carService: CarService, private rentalService: RentalService) { }

  deleteItem() {
    const deleteFunctions = {
      car: this.carService.deleteCar(this.data.id).subscribe({
        complete: () => this.dialogRef.close()
      }),
      rental: this.rentalService.deleteRental(this.data.id).subscribe({
        complete: () => this.dialogRef.close()
      }),
    };

    // @ts-ignore
    deleteFunctions[this.data.type]();
  }
}

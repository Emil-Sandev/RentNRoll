import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CarService } from '../../services/car/car.service';

@Component({
  selector: 'app-delete-car-dialog',
  templateUrl: './delete-car-dialog.component.html',
  styleUrl: './delete-car-dialog.component.css'
})
export class DeleteCarDialogComponent {
  constructor(public dialogRef: MatDialogRef<DeleteCarDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any, private carService: CarService) { }

  deleteCar() {
    this.carService.deleteCar(this.data.carId).subscribe();
    this.dialogRef.close();
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { BrandService } from '../../services/brand/brand.service';
import { CategoryService } from '../../services/category/category.service';
import { CarService } from '../../services/car/car.service';

@Component({
  selector: 'app-add-car-dialog',
  templateUrl: './add-car-dialog.component.html',
  styleUrl: './add-car-dialog.component.css'
})
export class AddCarDialogComponent implements OnInit {
  addCarForm: FormGroup = this.formBuilder.group({
    category: ['', Validators.required],
    brand: ['', Validators.required],
    model: ['', Validators.required],
    year: ['', Validators.required],
    licensePlate: ['', Validators.required],
    pricePerDay: ['', Validators.required],
    seats: ['', Validators.required],
    description: ['', Validators.required],
  });

  image: File = {} as File;

  brands: string[] = [];
  categories: string[] = [];

  constructor(public dialogRef: MatDialogRef<AddCarDialogComponent>, private formBuilder: FormBuilder, private brandService: BrandService, private categoryService: CategoryService, private carService: CarService) { }

  ngOnInit(): void {
    this.brandService.getBrands().subscribe(data => this.brands = data);
    this.categoryService.getCategories().subscribe(data => this.categories = data);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.image = file;
    }
  }

  addCar(): void {
    this.carService.createCar(this.addCarForm.value, this.image).subscribe();
    this.dialogRef.close();
  }
}

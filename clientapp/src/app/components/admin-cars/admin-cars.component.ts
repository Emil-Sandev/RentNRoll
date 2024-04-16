import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AdminCarDTO, AdminCarsDTO, CarQueryModel } from '../../models/car.model';
import { BrandService } from '../../services/brand/brand.service';
import { CategoryService } from '../../services/category/category.service';
import { CarService } from '../../services/car/car.service';
import { MatSliderDragEvent } from '@angular/material/slider';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-admin-cars',
  templateUrl: './admin-cars.component.html',
  styleUrl: './admin-cars.component.css'
})
export class AdminCarsComponent implements OnInit {
  // brands
  brands: string[] = [];
  @ViewChild('brandInputAdmin') brandInput: ElementRef<HTMLInputElement> = {} as ElementRef;
  brand = new FormControl('');
  filteredBrands: string[] = [];

  // categories
  categories: string[] = [];
  @ViewChild('categoryInputAdmin') categoryInput: ElementRef<HTMLInputElement> = {} as ElementRef;
  category = new FormControl('');
  filteredCategories: string[] = [];

  pageIndex: number = 0;
  queryModel: CarQueryModel = { currentPage: 1, carsPerPage: 5 } as CarQueryModel;
  adminCarsDTO: AdminCarsDTO = {} as AdminCarsDTO;

  displayedColumns: string[] = ['model', 'brand', 'category', 'year', 'seats', 'pricePerDay', 'description'];

  constructor(private brandService: BrandService, private categoryService: CategoryService, private carService: CarService) { }

  ngOnInit(): void {
    this.brandService.getBrands().subscribe(data => {
      this.brands = data;
      this.filteredBrands = this.brands.slice();
    });

    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
      this.filteredCategories = this.categories.slice();
    });

    // initial car load
    this.refreshCars();

    this.brand.valueChanges.subscribe(value => {
      value = value ?? '';
      this.queryModel.brand = value;
      this.refreshCars();
    });

    this.category.valueChanges.subscribe(value => {
      value = value ?? '';
      this.queryModel.category = value;
      this.refreshCars();
    });
  }

  filterBrands() {
    const filterValue = this.brandInput.nativeElement.value.toLowerCase();
    this.filteredBrands = this.brands.filter(b => b.toLowerCase().startsWith(filterValue));
  }

  filterCategories() {
    const filterValue = this.categoryInput.nativeElement.value.toLowerCase();
    this.filteredCategories = this.categories.filter(c => c.toLowerCase().startsWith(filterValue));
  }

  updateMinPrice(event: MatSliderDragEvent) {
    this.queryModel.minPrice = event.value;
    this.refreshCars();
  }

  updateMaxPrice(event: MatSliderDragEvent) {
    this.queryModel.maxPrice = event.value;
    this.refreshCars();
  }

  handlePageEvent(event: PageEvent) {
    this.queryModel.currentPage = event.pageIndex + 1;
    this.refreshCars();
  }

  refreshCars() {
    this.carService.getAdminCars(this.queryModel).subscribe(data => {
      this.adminCarsDTO = data;
    });
  }
}

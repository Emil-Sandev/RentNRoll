import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { BrandService } from '../../services/brand/brand.service';
import { CategoryService } from '../../services/category/category.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrl: './cars.component.css'
})
export class CarsComponent implements OnInit {
  brands: string[] = [];
  categories: string[] = [];

  constructor(private brandService: BrandService, private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.brandService.getBrands().subscribe(data => this.brands = data);
    this.categoryService.getCategories().subscribe(data => this.categories = data);
  }
}

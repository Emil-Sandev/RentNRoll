import { Component, OnInit } from '@angular/core';
import { CarDetailsDTO } from '../../models/car.model';
import { CarService } from '../../services/car/car.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { StripeService } from '../../services/stripe/stripe.service';
import { StripePaymentDTO, StripeResponse } from '../../models/stripe.model';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrl: './car-details.component.css'
})
export class CarDetailsComponent implements OnInit {
  id: number = 0;
  carDetails: CarDetailsDTO = {} as CarDetailsDTO;
  currentDate: Date = new Date();
  tomorrow: Date = new Date(this.currentDate);

  range = new FormGroup({
    start: new FormControl<Date | null>(this.currentDate),
    end: new FormControl<Date | null>(this.tomorrow)
  });
  totalPrice: number = 0;

  constructor(private carService: CarService, private route: ActivatedRoute, private stripeService: StripeService) {
    this.tomorrow.setDate(this.tomorrow.getDate() + 1);
  }

  ngOnInit(): void {
    this.route.params.subscribe(p => this.id = p['id']);

    this.carService.getCarDetails(this.id).subscribe(data => {
      this.carDetails = data;
      this.totalPrice = this.carDetails.pricePerDay * 2;
    });

    this.range.valueChanges.subscribe(() => {
      this.calculatePrice();
    });
  }

  calculatePrice(): void {
    const startDate = this.range.get('start')?.value;
    const endDate = this.range.get('end')?.value;

    if (!endDate) {
      this.totalPrice = this.carDetails.pricePerDay;
      return;
    }

    if (startDate && endDate) {
      const start = new Date(startDate);
      const end = new Date(endDate);
      const diffTime = end.getTime() - start.getTime();
      const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)) + 1;
      this.totalPrice = diffDays * this.carDetails.pricePerDay;
    }
  }

  goToCheckout() {
    const stripePaymentDto: StripePaymentDTO = {
      model: this.carDetails.model,
      imageUrl: this.carDetails.imageUrl,
      totalPrice: this.totalPrice,
      rentalDate: this.currentDate,
      returnDate: this.tomorrow
    };

    this.stripeService.createCheckout(stripePaymentDto).subscribe((data: StripeResponse) => {
      window.location.href = data.url;
    });
  }
}

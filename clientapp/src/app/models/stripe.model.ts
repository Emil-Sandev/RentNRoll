export interface StripePaymentDTO {
    model:      string;
    imageUrl:   string;
    totalPrice: number;
    rentalDate: Date;
    returnDate: Date;
}

export interface StripeResponse {
    url: string;
}
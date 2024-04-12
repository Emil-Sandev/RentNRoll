export interface StripePaymentDTO {
    model:      string;
    imageUrl:  string;
    totalPrice: number;
}

export interface StripeResponse {
    url: string;
}

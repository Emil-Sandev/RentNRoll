export interface RentalDetailsUserDTO {
    model:      string;
    brand:      string;
    category:   string;
    rentalDate: string;
    returnDate: string;
    totalPrice: number;
}

export interface RentalsAdminDTO {
    totalCount: number;
    rentals:    RentalAdminDTO[];
}

export interface RentalAdminDTO {
    customer:      string;
    customerEmail: string;
    phone:         string;
    egn:           string;
    model:         string;
    brand:         string;
    category:      string;
    rentalDate:    string;
    returnDate:    string;
    totalPrice:    number;
}


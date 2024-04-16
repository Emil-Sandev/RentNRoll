export interface CarQueryModel {
    brand:       string | null;
    category:    string | null;
    minPrice:    number;
    maxPrice:    number;
    currentPage: number;
    carsPerPage: number;
}

export interface FilteredAndPagedCarDTO {
    totalCount: number;
    cars:       CarDTO[];
}

export interface CarDTO {
    id:          number;
    model:       string;
    imageUrl:    string;
    description: string;
}

export interface CarDetailsDTO {
    id:          number;
    model:       string;
    year:        number;
    pricePerDay: number;
    brand:       string;
    category:    string;
    description: string;
    imageUrl:    string;
    seats:       number;
}

export interface AdminCarsDTO {
    totalCount: number;
    cars:       AdminCarDTO[];
}

export interface AdminCarDTO {
    id:          number;
    model:       string;
    year:        number;
    pricePerDay: number;
    brand:       string;
    category:    string;
    description: string;
    imageUrl:    string;
    seats:       number;
}

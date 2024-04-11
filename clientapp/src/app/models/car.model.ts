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

export interface UsersAdminDTO {
    totalCount: number;
    users:      UserDTO[];
}

export interface UserDTO {
    id:        string;
    firstName: string;
    lastName:  string;
    userName:  string;
    email:     string;
    phone:     string;
    egn:       string;
}

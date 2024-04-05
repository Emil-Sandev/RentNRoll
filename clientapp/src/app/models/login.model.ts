export interface LoginResponse {
    jwtToken:     string;
    expiration:   string;
    refreshToken: string;
}

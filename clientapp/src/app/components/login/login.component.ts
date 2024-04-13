import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SwalService } from '../../services/swal/swal.service';
import { LoginResponse } from '../../models/login.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  hide: boolean = true;
  loginForm = this.fb.group({
    username: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(30)]],
    password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50), Validators.pattern(/^(?=.*[A-Z])(?=.*\d)(?=.*\W).+$/)]],
  });

  constructor(private fb: FormBuilder, private authService: AuthenticationService, private swalService: SwalService, private router: Router) { }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    this.authService.login(this.loginForm.value).subscribe({
      next: (loginResponse: LoginResponse) => {
        localStorage.setItem('token', loginResponse.jwtToken);
        localStorage.setItem('expires', loginResponse.expiration);
        localStorage.setItem('refreshToken', loginResponse.refreshToken);
        this.authService.isAdmin().subscribe(data => {
          console.log(data);
          this.authService.isAdminEmitter.emit(data);
        });
        this.router.navigate(['']);
      },
      error: (error: HttpErrorResponse) => {
        this.swalService.fireSwal('Error!', error.error, 'error')
      }
    });
  }

  // shorter access to form controls
  get f() { return this.loginForm.controls; }
}

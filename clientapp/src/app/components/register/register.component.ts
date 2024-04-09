import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { SwalService } from '../../services/swal/swal.service';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  hide: boolean = true;
  registerForm = this.fb.group({
    firstName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20), Validators.pattern(/^[A-Z][a-z]+$/)]],
    lastName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20), Validators.pattern(/^[A-Z][a-z]+$/)]],
    username: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(30)]],
    password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(50), Validators.pattern(/^(?=.*[A-Z])(?=.*\d)(?=.*\W).+$/)]],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required, Validators.pattern(/^(?:0|\+359)8[7-9]\d{7}$/)]],
    egn: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
  });

  constructor(private fb: FormBuilder, private authService: AuthenticationService, private swalService: SwalService) { }

  onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    this.authService.register(this.registerForm.value).subscribe({
      next: data => {
        this.swalService.fireSwal('Successful registration!', 'You can now log into your account.', 'success', '/login');
      },
      error: (error: HttpErrorResponse) => {
        if (error.status === 409) {
          this.swalService.fireSwal('Error!', error.error, 'error');
        }
      }
    });
  }

  // shorter access to form controls
  get f() { return this.registerForm.controls; }
}

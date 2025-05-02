import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: false,
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent implements OnInit {
  signUpForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      phoneNumber: ['', Validators.required]
    });
  }

  onSignUp() {
    if (this.signUpForm.valid) {
      const signUpData = this.signUpForm.value;

      this.authService.signup(signUpData).subscribe({
        next: (res) => {
          console.log('Kayıt başarılı:', res);
          this.router.navigate(['/login']);
        },
        error: (err) => {
          console.error('Kayıt hatası:', err);
        }
      });
    }
  }
}

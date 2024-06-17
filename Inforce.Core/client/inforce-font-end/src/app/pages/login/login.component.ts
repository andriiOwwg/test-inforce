import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { LabelInputComponent } from '../../components/label-input/label-input.component';
import { AuthService } from '../../services/auth.service';
import { ButtonComponent } from '../../components/button/button.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    RouterLink,
    LabelInputComponent,
    ButtonComponent,
  ],
})
export class LoginComponent {
  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
  });

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    const email = this.loginForm.get('email')?.value ?? '';
    const password = this.loginForm.get('password')?.value ?? '';

    if (this.authService.login(email, password)) {
      this.router.navigate(['/short-table']);
    } else {
      alert('Login failed');
    }
  }

  handleSubmit() {
    this.login();
  }
}

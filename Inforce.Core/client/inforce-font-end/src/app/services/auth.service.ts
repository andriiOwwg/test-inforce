import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, config } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private UserURL = 'http://localhost:5097/User';
  constructor(private http: HttpClient) {}

  register(username: string, email: string, password: string): boolean {
    const body = { username, email, password };
    const response = this.http
      .post(`${this.UserURL}/Register`, body)
      .subscribe({
        // next: (response) => {
        //   localStorage.setItem('token', 'response.token');
        // },
        error: (error) => {
          console.error('Registration failed', error);
        },
        complete: () => {
          console.log('Registration request completed');
        },
      });
    console.log(body, 'in register');
    console.log(response, 'in register');
    return true;
  }

  login(email: string, password: string): boolean {
    const body = { email, password };
    const response = this.http.post(`${this.UserURL}/login`, body).subscribe({
      next: (response) => {
        localStorage.setItem('token', 'response.token');
      },
      error: (error) => {
        console.error('Login failed', error);
      },
      complete: () => {
        console.log('Login request completed');
      },
    });
    console.log(response, 'in login');
    return true;
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
}

import { Component } from '@angular/core';
import { ButtonComponent } from '../../components/button/button.component';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-short-table',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './short-table.component.html',
})
export class ShortTableComponent {
  constructor(private authService: AuthService, private router: Router) {}

  handleClick() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

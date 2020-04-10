import { Component } from '@angular/core';
import { User, Role, Token } from '@core/models';
import { Router } from '@angular/router';
import { AuthService } from '@core/services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentUser: User;
  currentAuth: Token;
  title = 'TiLiWeb';

  constructor(
    private router: Router,
    private authService: AuthService
  ) {
    this.authService.currentAuth.subscribe(x => this.currentAuth = x);
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['/login'])
  }
}

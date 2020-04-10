import { Component, OnInit } from '@angular/core';
import { User, Token } from '@core/models';
import { UserService, AuthService } from '@core/services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading = false;
  currentAuth: Token;
  userFromApi: User;

  constructor(
    private userService: UserService,
    private authService: AuthService
  ) {
    this.currentAuth = this.authService.currentAuthValue;
  }

  ngOnInit(): void {
    this.loading = true;
    this.userService.getById(this.currentAuth.id).pipe(first()).subscribe(user => {
      this.loading = false;
      this.userFromApi = user;
    });
  }

}

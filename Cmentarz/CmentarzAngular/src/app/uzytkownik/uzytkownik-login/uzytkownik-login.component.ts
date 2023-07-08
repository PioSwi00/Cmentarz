import { Component, ViewEncapsulation } from '@angular/core';
import { Uzytkownik } from 'src/app/models/uzytkownik';
import { UzytkownikService } from 'src/app/service/uzytkownik.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-uzytkownik-login',
  templateUrl: './uzytkownik-login.component.html',
  styleUrls: ['./uzytkownik-login.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UzytkownikLoginComponent {
  uzytkownik: Uzytkownik = {
    login: '',
    haslo: ''
  };

  constructor(
    private uzytkownikService: UzytkownikService,
    private router: Router,
    private authService: AuthService
  ) { }

  zaloguj(): void {
    this.uzytkownikService.zaloguj(this.uzytkownik).subscribe(
      (response) => {
        this.authService.setLoggedIn(true);
        this.router.navigate(['/panel']);
      },
      (error) => {
        console.log('Błąd logowania:', error);
      }
    );
  }

  logInfo(): void {
    console.log('Wartość zmiennej isLoggedIn:', this.authService.isLoggedIn$);
  }
}

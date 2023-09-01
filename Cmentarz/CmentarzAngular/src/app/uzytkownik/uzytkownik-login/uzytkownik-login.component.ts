import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Uzytkownik } from 'src/app/models/uzytkownik';
import { UzytkownikService } from 'src/app/service/uzytkownik.service';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/service/token.service'; // Dodaj TokenService

@Component({
  selector: 'app-uzytkownik-login',
  templateUrl: './uzytkownik-login.component.html',
  styleUrls: ['./uzytkownik-login.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UzytkownikLoginComponent {
  uzytkownik: Uzytkownik = {
    token: '',
    login: '',
    haslo: ''
  };
  loginError: boolean = false;

  constructor(
    private uzytkownikService: UzytkownikService,
    private router: Router,
    private tokenService: TokenService
  ) { }

  zaloguj(): void {
    this.uzytkownikService.zaloguj(this.uzytkownik).subscribe(
      (response) => {
        // Zapisz token w Local Storage
        this.tokenService.setToken(response.token);
        // Przekieruj użytkownika na odpowiedni widok
        this.router.navigate(['/panel']);
      },
      (error) => {
        console.log('Błąd logowania:', error);
        this.loginError = true; 
      }
    );
  }

  logInfo(): void {
    console.log('Wartość tokenu:', this.tokenService.getToken());
  }
}

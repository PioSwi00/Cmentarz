import { Component,ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Uzytkownik } from '../../models/uzytkownik';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RegisterComponent {
  uzytkownik: Uzytkownik = {
    token: '',
    login: '',
    haslo: ''
  };
  errorMessage: string = '';

  constructor(private http: HttpClient, private router: Router) {}

  register(): void {
    if (this.uzytkownik.login && this.uzytkownik.haslo && this.uzytkownik.haslo.length >= 8) {

      this.uzytkownik.token = '';

      this.http.post('https://localhost:7116/api/UzytkownikApi/DodajUzytkownika', this.uzytkownik)
        .subscribe(
          () => {
            this.router.navigate(['/login']);
          },
          (error: any) => {
            this.errorMessage = error.error;
          }
        );
    }
  }
}

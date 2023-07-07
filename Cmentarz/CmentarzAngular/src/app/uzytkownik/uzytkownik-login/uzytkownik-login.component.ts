import { Component } from '@angular/core';
import { Uzytkownik } from 'src/app/models/uzytkownik';
import { UzytkownikService } from 'src/app/service/uzytkownik.service';
@Component({
  selector: 'app-uzytkownik-login',
  templateUrl: './uzytkownik-login.component.html',
  styleUrls: ['./uzytkownik-login.component.css']
})
export class UzytkownikLoginComponent {
  uzytkownik: Uzytkownik = {
    login: '',
    haslo: ''
  };

  constructor(private uzytkownikService: UzytkownikService) { }

  zaloguj(): void {
    this.uzytkownikService.zaloguj(this.uzytkownik).subscribe(
      () => {
        // Przekierowanie do innej strony lub wykonanie innych akcji po pomyślnym zalogowaniu
      },
      (error) => {
        // Obsługa błędu logowania
      }
    );
  }
}

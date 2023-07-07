import { Component, OnInit } from '@angular/core';
import { WlascicielService } from '../service/wlasciciel.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-uzytkownik',
  templateUrl: './uzytkownik.component.html',
  styleUrls: ['./uzytkownik.component.css']
})
export class UzytkownikComponent implements OnInit {
  zalogowany: boolean = false;

  constructor(
    private wlascicielService: WlascicielService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    console.log('Wartość isLoggedIn w ngOnInit:', this.authService.isLoggedIn$);

    this.authService.isLoggedIn$.subscribe((isLoggedIn: boolean) => {
      this.zalogowany = isLoggedIn;
      console.log('Aktualna wartość isLoggedIn:', this.zalogowany);

      if (this.zalogowany) {
        this.wlascicielService.getWlasciciele().subscribe(
          (response) => {
            console.log('Odpowiedź z danymi właścicieli:', response);
          },
          (error) => {
            console.log('Błąd pobierania właścicieli:', error);
          }
        );
      }
    });
  }
}

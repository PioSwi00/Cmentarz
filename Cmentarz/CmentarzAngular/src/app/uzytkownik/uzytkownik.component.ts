import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { WlascicielService } from '../service/wlasciciel.service';
import { AuthService } from '../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-uzytkownik',
  templateUrl: './uzytkownik.component.html',
  styleUrls: ['./uzytkownik.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class UzytkownikComponent implements OnInit {
  zalogowany: boolean = false;

  constructor(
    private wlascicielService: WlascicielService,
    private authService: AuthService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.zalogowany = this.authService.getLoggedIn();

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

    this.authService.isLoggedIn$.subscribe((isLoggedIn: boolean) => {
      this.zalogowany = isLoggedIn;

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
  wyloguj(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}

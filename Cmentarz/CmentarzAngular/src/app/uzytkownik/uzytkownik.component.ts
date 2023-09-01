import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { WlascicielService } from '../service/wlasciciel.service';
import { TokenService } from '../service/token.service'; // Zaktualizowany import na TokenService
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
    private tokenService: TokenService,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (!this.tokenService.hasToken()) {
      this.router.navigate(['/login']);
    }
    this.zalogowany = true;
    this.wlascicielService.getWlasciciele().subscribe(
      (response) => {
        console.log('Odpowiedź z danymi właścicieli:', response);
      },
      (error) => {
        console.log('Błąd pobierania właścicieli:', error);
      }
    );
  }

  wyloguj(): void {
    this.tokenService.removeToken();
    this.router.navigate(['/login']);
  }
}

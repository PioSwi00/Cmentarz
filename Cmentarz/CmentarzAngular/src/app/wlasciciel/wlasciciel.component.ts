import { Component, OnInit } from '@angular/core';
import { WlascicielService } from '../service/wlasciciel.service';
import { AuthService } from 'src/app/service/auth.service';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-wlasciciel',
  templateUrl: './wlasciciel.component.html',
  styleUrls: ['./wlasciciel.component.css']
})
export class WlascicielComponent implements OnInit {
  wlasciciele: any[] = [];
  isLoading: boolean = true;

  constructor(public wlascicielService: WlascicielService, public authService: AuthService) { }

  ngOnInit(): void {
    this.authService.isLoggedIn$.subscribe(isLoggedIn => {
      if (isLoggedIn) {
        this.getWlasciciele();
      } else {
        console.log('Użytkownik nie jest zalogowany. Brak dostępu do danych.');
        this.isLoading = false;
      }
    });
  }

  getWlasciciele(): void {
    this.wlascicielService.getWlasciciele().pipe(
      delay(0)
    ).subscribe(
      (response) => {
        this.wlasciciele = response;
        this.isLoading = false;
      },
      (error) => {
        console.log('Błąd pobierania właścicieli:', error);
        this.isLoading = false;
      }
    );
  }
}

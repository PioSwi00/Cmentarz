import { Component, OnInit } from '@angular/core';
import { WlascicielService } from '../service/wlasciciel.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-wlasciciel',
  templateUrl: './wlasciciel.component.html',
  styleUrls: ['./wlasciciel.component.css']
})
export class WlascicielComponent implements OnInit {
  wlasciciele: any[] = [];
  isLoading: boolean = true;
  isLoggedIn: boolean = false;

  constructor(
    public wlascicielService: WlascicielService,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    console.log('Wartość isLoggedIn w ngOnInit:', this.isLoggedIn);

    this.authService.isLoggedIn$.subscribe((isLoggedIn: boolean) => {
      this.isLoggedIn = isLoggedIn;
      console.log('Aktualna wartość isLoggedIn:', this.isLoggedIn);

      if (this.isLoggedIn) {
        this.getWlasciciele();
      } else {
        console.log('Użytkownik nie jest zalogowany. Brak dostępu do danych.');
        this.isLoading = false;
      }
    });
  }

  getWlasciciele(): void {
    console.log('Pobieranie właścicieli...');
    this.wlascicielService.getWlasciciele().subscribe(
      (response) => {
        this.wlasciciele = response;
        this.isLoading = false;
        console.log('Właściciele pobrani:', this.wlasciciele);
      },
      (error) => {
        console.log('Błąd pobierania właścicieli:', error);
        this.isLoading = false;
      }
    );
  }
}

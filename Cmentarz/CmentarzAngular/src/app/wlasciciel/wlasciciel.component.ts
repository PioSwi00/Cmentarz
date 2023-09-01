import { Component, OnInit } from '@angular/core';
import { WlascicielService } from '../service/wlasciciel.service';
import { AuthService } from '../service/auth.service';
import { TokenService } from '../service/token.service';

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
    private tokenService: TokenService,
    public authService: AuthService
  ) { }

  ngOnInit(): void {
    if (!this.tokenService.hasToken()) {
      console.log('Użytkownik nie jest zalogowany. Brak dostępu do danych.');
      this.isLoading = false;
    }
    else{
      this.getWlasciciele();
    }
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

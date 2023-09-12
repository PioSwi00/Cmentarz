import { Component, ViewEncapsulation } from '@angular/core';
import { GrobowiecService } from 'src/app/service/grobowiec.service';
import { Grobowiec } from 'src/app/models/grobowiec';
import { UzytkownikService } from 'src/app/service/uzytkownik.service';
import { TokenService } from 'src/app/service/token.service';
import { Router } from '@angular/router';
import { WlascicielService } from 'src/app/service/wlasciciel.service';

@Component({
  selector: 'app-kup-grobowiec',
  templateUrl: './kup-grobowiec.component.html',
  styleUrls: ['./kup-grobowiec.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class KupGrobowiecComponent {
  selectedGrobowiec: Grobowiec | null = null;
  grobowce: Grobowiec[] = [];
  selectedBank: string | null = null;
  isBankSelected: boolean = false;
  banks: { name: string, logoUrl: string }[] = [];

  constructor(
    private grobowiecService: GrobowiecService, 
    private uzytkownikService: UzytkownikService, 
    private tokenService: TokenService,
    private router: Router,
    private wlascicielService: WlascicielService,
  ) {
    this.pobierzWolneGrobowce();
    this.inicjalizujBanki();
  }

  inicjalizujBanki() {
    this.banks = [
      { name: 'PKO', logoUrl: 'assets/pko.png' },
      { name: 'ING', logoUrl: 'assets/ing.jpg' },
      { name: 'BLIK', logoUrl: 'assets/blik.jpeg' },
      { name: 'mBank', logoUrl: 'assets/mbank.png' },
    ];
  }

  pobierzWolneGrobowce() {
    const token = this.tokenService.getToken();
    if (token) {
      const userIdObservable = this.uzytkownikService.getUserIdFromToken(token);

      userIdObservable.subscribe(
        (userId) => {
          if (userId !== null) {
            this.wlascicielService.getWlascicielById(userId).subscribe(
              (wlasciciel) => {
                if (wlasciciel !== null) {
                  this.grobowiecService.pobierzWolneGroby().subscribe(
                    (grobowce) => {
                      this.grobowce = grobowce;
                      console.log(grobowce);
                    },
                    (error) => {
                      console.error('Błąd pobierania dostępnych grobowców:', error);
                    }
                  );
                } else {
                  console.log('Musisz stać się właścicielem, aby kupić grobowiec.');
                  this.router.navigate(['/dodajWlasciciela']);
                }
              },
              (error) => {
                console.error('Błąd podczas sprawdzania czy użytkownik jest właścicielem:', error);
              }
            );
          }
        },
        (error) => {
          console.error('Błąd podczas pobierania identyfikatora użytkownika z tokenu:', error);
        }
      );
    }
  }

  selectGrobowiec(grobowiec: Grobowiec) {
    this.selectedGrobowiec = grobowiec;
  }

  selectBank(bank: string) {
    this.selectedBank = bank;
    this.isBankSelected = true;
  }

  kupGrobowiec() {
    if (this.selectedGrobowiec != null) {
      if (this.isBankSelected) {
        const token = this.tokenService.getToken();
        if (token) {
          const userIdObservable = this.uzytkownikService.getUserIdFromToken(token);
  
          userIdObservable.subscribe(
            (userId) => {
              if (userId !== null && this.selectedGrobowiec?.idGrobowiec != null) {
                this.uzytkownikService.kupGrobowiec(userId, this.selectedGrobowiec.idGrobowiec).subscribe(
                  () => {
                    console.log('Kupiono grobowiec:', this.selectedGrobowiec);
  
                    this.grobowce = this.grobowce.filter(
                      (grobowiec) => grobowiec.idGrobowiec !== this.selectedGrobowiec?.idGrobowiec
                    );
  
                    this.selectedGrobowiec = null;
                    this.selectedBank = null;
                    this.isBankSelected = false;
                  },
                  (error) => {
                    console.error('Błąd podczas zakupu grobowca:', error);
                  }
                );
              }
            },
            (error) => {
              console.error('Błąd podczas pobierania identyfikatora użytkownika z tokenu:', error);
            }
          );
        }
      } else {
        alert('Proszę wybrać metodę płatności (bank) przed zakupem.');
      }
    } else {
      console.error('Wybierz grobowiec przed zakupem.');
    }
  }
}

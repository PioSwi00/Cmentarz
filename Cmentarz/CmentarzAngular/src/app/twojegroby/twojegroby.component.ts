import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';
import { WlascicielService } from '../service/wlasciciel.service';
import { AuthService } from '../service/auth.service';
import { TokenService } from '../service/token.service';
import { UzytkownikService } from '../service/uzytkownik.service';

@Component({
  selector: 'app-twojegroby',
  templateUrl: './twojegroby.component.html',
  styleUrls: ['./twojegroby.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class TwojegrobyComponent implements OnInit {
  grobowce: Grobowiec[] = [];
  userId: number | null = null;
  expandedGrobowiecId: number | null = null;
  expandedZmarliGrobowiecId: number | null = null;

  constructor(
    private grobowiecService: GrobowiecService,
    private authService: AuthService,
    private tokenService: TokenService,
    private uzytkownikService: UzytkownikService,
    private wlascicielService: WlascicielService
  ) { }

  ngOnInit(): void {
    const token = this.tokenService.getToken();
    if (token) {
      const userIdObservable = this.uzytkownikService.getUserIdFromToken(token);

      userIdObservable.subscribe(
        (userId) => {
          if (userId !== null) {
            // Sprawdź, czy użytkownik jest właścicielem
            this.wlascicielService.getWlascicielById(userId).subscribe(
              (wlasciciel) => {
                if (wlasciciel !== null) {
                  // Użytkownik jest właścicielem, pobiera dostępne grobowce
                  this.grobowiecService.getGrobowceByIdWlasciciela(userId).subscribe(
                    (grobowce) => {
                      this.grobowce = grobowce;
                      console.log(grobowce);

                      // Pobierz odwiedzających dla każdego grobu
                      this.grobowce.forEach((grobowiec) => {
                        this.grobowiecService.getOdwiedzajacyFromGrobowiec(grobowiec.idGrobowiec).subscribe(
                          (odwiedzajacy) => {
                            grobowiec.ListaOdwiedzajacy = odwiedzajacy;
                          },
                          (error) => {
                            console.error(`Błąd pobierania odwiedzających grobowca ${grobowiec.idGrobowiec}:`, error);
                          }
                        );
                      });
                    },
                    (error) => {
                      console.error('Błąd pobierania dostępnych grobowców:', error);
                    }
                  );
                } else {
                  console.log('Pusto masz.');
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
          // Handle error
        }
      );
    }
  }
  toggleContent(grobowiecId: number) {
    if (this.expandedGrobowiecId === grobowiecId) {
      this.expandedGrobowiecId = null;
    } else {
      this.expandedGrobowiecId = grobowiecId;
    }
  }
  toggleZmarliContent(grobowiecId: number) {
    if (this.expandedZmarliGrobowiecId === grobowiecId) {
      this.expandedZmarliGrobowiecId = null;
    } else {
      this.expandedZmarliGrobowiecId = grobowiecId;

      // Wywołaj funkcję do pobrania zmarłych z grobu
      this.grobowiecService.getZmarliFromGrobowiec(grobowiecId).subscribe(
        (zmarli) => {
          // Przypisz zmarłych do odpowiedniego grobowca
          const grobowiec = this.grobowce.find((g) => g.idGrobowiec === grobowiecId);
          if (grobowiec) {
            grobowiec.Zmarli = zmarli;
          }
        },
        (error) => {
          console.error(`Błąd pobierania zmarłych dla grobowca ${grobowiecId}:`, error);
        }
      );
    }
  }
}
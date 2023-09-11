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
export class TwojegrobyComponent implements OnInit{
  grobowce: Grobowiec[] = [];
  userId: number | null = null;

  constructor(
    private grobowiecService: GrobowiecService,
    private authService: AuthService,
    private tokenService: TokenService,
    private uzytkownikService: UzytkownikService,
    private wlascicielService: WlascicielService
  ) {}

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

}
import { Component,ViewEncapsulation } from '@angular/core';
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

  constructor(
    private grobowiecService: GrobowiecService, 
    private uzytkownikService: UzytkownikService, 
    private tokenService: TokenService,
    private router: Router,
    private wlascicielService: WlascicielService,
    ) {
    this.pobierzWolneGrobowce();
  }

pobierzWolneGrobowce() {
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
                // Użytkownik jest właścicielem, więc pobierz dostępne grobowce do zakupu
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
                // Użytkownik nie jest właścicielem, wyświetl odpowiedni komunikat
                console.log('Musisz stać się właścicielem, aby kupić grobowiec.');
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


  selectGrobowiec(grobowiec: Grobowiec) {
    this.selectedGrobowiec = grobowiec;
  }

  kupGrobowiec() {
    if (this.selectedGrobowiec != null) {
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

                  // Reset the selected grobowiec
                  this.selectedGrobowiec = null;
                },
                (error) => {
                  console.error('Błąd podczas zakupu grobowca:', error);
                  // Handle purchase error
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
    } else {
      // Handle cases where the grobowiec is not selected or the user is not logged in
    }
  }
}

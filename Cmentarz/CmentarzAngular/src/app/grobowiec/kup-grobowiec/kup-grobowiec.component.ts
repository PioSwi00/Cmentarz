import { Component } from '@angular/core';
import { GrobowiecService } from 'src/app/service/grobowiec.service';
import { Grobowiec } from 'src/app/models/grobowiec';
import { UzytkownikService } from 'src/app/service/uzytkownik.service';
import { TokenService } from 'src/app/service/token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-kup-grobowiec',
  templateUrl: './kup-grobowiec.component.html',
  styleUrls: ['./kup-grobowiec.component.css']
})
export class KupGrobowiecComponent {
  selectedGrobowiec: Grobowiec | null = null;
  grobowce: Grobowiec[] = [];

  constructor(
    private grobowiecService: GrobowiecService, 
    private uzytkownikService : UzytkownikService, 
    private tokenService: TokenService,
    private router: Router,
    ) {
    this.pobierzWolneGrobowce();
  }

  pobierzWolneGrobowce() {
    this.grobowiecService.pobierzWolneGroby().subscribe(
      (grobowce) => {
        this.grobowce = grobowce;
        console.log(grobowce);
      },
      (error) => {
        console.error('Błąd pobierania dostępnych grobowców:', error);
      }
    );
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

                  // After purchasing, you may want to update the UI or perform other actions
                  // For example, remove the purchased grobowiec from the list
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

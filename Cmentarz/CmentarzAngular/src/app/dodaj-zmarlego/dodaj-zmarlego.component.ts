import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ZmarlyService } from '../service/zmarly.service';
import { AuthService } from '../service/auth.service';
import { GrobowiecService } from '../service/grobowiec.service';
import { Grobowiec } from '../models/grobowiec';

@Component({
  selector: 'app-dodaj-zmarlego',
  templateUrl: './dodaj-zmarlego.component.html',
  styleUrls: ['./dodaj-zmarlego.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DodajZmarlegoComponent implements OnInit {
  zmarlyForm: FormGroup;
  isLoggedIn = false;
  dostepneGrobowce: Grobowiec[] = [];
  wybranyGrobowiec?: Grobowiec;

  constructor(
    private fb: FormBuilder,
    private zmarlyService: ZmarlyService,
    private authService: AuthService,
    private grobowiecService: GrobowiecService
  ) {
    this.zmarlyForm = this.fb.group({
      imie: ['', [Validators.required]],
      nazwisko: ['', [Validators.required]],
      dataUrodzenia: ['', [Validators.required]],
      dataSmierci: ['', [Validators.required]],
      idGrobowiec: ['', [Validators.required]]
    });      
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.getLoggedIn(); // Sprawdzenie czy użytkownik jest zalogowany
    this.authService.isLoggedIn$.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn; // Aktualizacja statusu zalogowania
    });
  
    this.grobowiecService.pobierzWolneGroby().subscribe(
      (grobowce) => {
        this.dostepneGrobowce = grobowce;
        if (grobowce.length > 0) {
          this.wybranyGrobowiec = grobowce[0]; // Wybierz pierwszy grobowiec jako domyślny
  
          // Ustaw wartości lokalizacji i ceny grobowca w formularzu
          this.zmarlyForm.get('grobowiec')?.patchValue({
            lokalizacja: this.wybranyGrobowiec.lokalizacja,
            cena: this.wybranyGrobowiec.cena
          });
        }
      },
      (error) => {
        console.error('Wystąpił błąd podczas pobierania dostępnych grobowców.', error);
      }
    );
  }  

  dodajZmarlego() {
    if (this.zmarlyForm.valid && this.isLoggedIn && this.wybranyGrobowiec) {
      const zmarlyData = {
        imie: this.zmarlyForm.value.imie,
        nazwisko: this.zmarlyForm.value.nazwisko,
        dataUrodzenia: this.zmarlyForm.value.dataUrodzenia,
        dataSmierci: this.zmarlyForm.value.dataSmierci,
        GrobowiecID: this.wybranyGrobowiec?.idGrobowiec,
        Grobowiec: {
          IdWlasciciel: this.wybranyGrobowiec?.idWlasciciel,
          Lokalizacja: this.wybranyGrobowiec?.lokalizacja,
          Cena: this.wybranyGrobowiec?.cena,
          CzyZajety: false
        }
      };
  
      this.zmarlyService.dodajZmarlego(zmarlyData).subscribe(
        () => {
          console.log('Zmarły został dodany.');
          // Możesz wykonać dodatkowe akcje po pomyślnym dodaniu zmarłego, np. wyświetlić komunikat sukcesu
        },
        (error) => {
          console.error('Wystąpił błąd podczas dodawania zmarłego.', error.error);
          console.log('Błędy walidacji:', error.error.errors);
          // Możesz obsłużyć błąd, wyświetlić komunikat lub podjąć odpowiednie działania w przypadku niepowodzenia
        }
      );
    } else {
      // Formularz jest niepoprawny, użytkownik nie jest zalogowany lub nie wybrano grobowca, wyświetl odpowiednie komunikaty błędów
      this.zmarlyForm.markAllAsTouched();
    }
  }
  

  onGrobowiecChange(event: Event) {
    const grobowiecId = Number((event.target as HTMLSelectElement).value);
    this.wybranyGrobowiec = this.dostepneGrobowce.find((grobowiec) => grobowiec.idGrobowiec === grobowiecId);
  }
}

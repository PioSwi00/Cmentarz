import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ZmarlyService } from '../service/zmarly.service';
import { TokenService } from '../service/token.service'; // Zaktualizowano import na TokenService
import { GrobowiecService } from '../service/grobowiec.service';
import { Grobowiec } from '../models/grobowiec';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dodaj-zmarlego',
  templateUrl: './dodaj-zmarlego.component.html',
  styleUrls: ['./dodaj-zmarlego.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DodajZmarlegoComponent implements OnInit {
  zmarlyForm: FormGroup;
  dostepneGrobowce: Grobowiec[] = [];
  wybranyGrobowiec?: Grobowiec;
  isLoggedIn: boolean = false;

  constructor(
    private fb: FormBuilder,
    private zmarlyService: ZmarlyService,
    private tokenService: TokenService,
    private grobowiecService: GrobowiecService,
    private router: Router,
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
    if (!this.tokenService.hasToken()) {
      this.isLoggedIn = false;
      this.router.navigate(['/login']);
    }
    this.isLoggedIn = true;
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
    if (this.zmarlyForm.valid && this.tokenService.hasToken() && this.wybranyGrobowiec) {
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
        },
        (error) => {
          console.error('Wystąpił błąd podczas dodawania zmarłego.', error.error);
          console.log('Błędy walidacji:', error.error.errors);
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

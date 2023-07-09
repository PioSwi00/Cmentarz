import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ZmarlyService } from '../service/zmarly.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-dodaj-zmarlego',
  templateUrl: './dodaj-zmarlego.component.html',
  styleUrls: ['./dodaj-zmarlego.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DodajZmarlegoComponent implements OnInit {
  zmarlyForm: FormGroup;
  isLoggedIn = false;

  constructor(
    private fb: FormBuilder,
    private zmarlyService: ZmarlyService,
    private authService: AuthService
  ) {
    this.zmarlyForm = this.fb.group({
      imie: ['', [Validators.required]],
      nazwisko: ['', [Validators.required]],
      dataUrodzenia: ['', [Validators.required]],
      dataSmierci: ['', [Validators.required]],
      grobowiecID: ['', [Validators.required]],
      grobowiec: this.fb.group({
        idWlasciciel: ['', [Validators.required]],
        lokalizacja: ['', [Validators.required]],
        cena: ['', [Validators.required, Validators.min(0)]],
        czyZajety: [false]
      })
    });
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.getLoggedIn(); // Sprawdzenie czy użytkownik jest zalogowany
    this.authService.isLoggedIn$.subscribe((loggedIn) => {
      this.isLoggedIn = loggedIn; // Aktualizacja statusu zalogowania
    });
  }

  dodajZmarlego() {
    if (this.zmarlyForm.valid && this.isLoggedIn) {
      const zmarlyData = this.zmarlyForm.value;
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
      // Formularz jest niepoprawny lub użytkownik nie jest zalogowany, wyświetl odpowiednie komunikaty błędów
      this.zmarlyForm.markAllAsTouched();
    }
  }
}

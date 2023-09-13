import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OdwiedzajacyService } from '../service/odwiedzajacy.service';
import { Odwiedzajacy } from '../models/odwiedzajacy';
import { UzytkownikService } from '../service/uzytkownik.service';
import { TokenService } from '../service/token.service';

@Component({
  selector: 'app-dodaj-odwiedzajacy',
  templateUrl: './dodaj-odwiedzajacy.component.html',
  styleUrls: ['./dodaj-odwiedzajacy.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DodajOdwiedzajacyComponent implements OnInit {
  odwiedzajacyForm: FormGroup;
  idGrobowca: number = 0;
  constructor(
    private fb: FormBuilder,
    private odwiedzajacyService: OdwiedzajacyService,
    private uzytkownikService: UzytkownikService,
    private grobowiecService: GrobowiecService,
    private tokenService: TokenService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.odwiedzajacyForm = this.fb.group({
      idOdwiedzajacy: [{value: '', disabled: true}, [Validators.required]],
      imie: ['', [Validators.required]],
      nazwisko: ['', [Validators.required]],
      czyZapalilZnicz: [true, [Validators.required]],
    });
  }

  ngOnInit() {
    this.idGrobowca = this.route.snapshot.params['idGrobowca'];
    const token = this.tokenService.getToken();
    if (token) {
      this.uzytkownikService.getUserIdFromToken(token).subscribe(
        (userId) => {
          if (userId !== null) {
            this.odwiedzajacyForm.get('idOdwiedzajacy')?.patchValue(userId);
          }
        }
      );
    }
  }
  
  dodajOdwiedzajacy() {
    console.log("Metoda dodajOdwiedzajacy() została wywołana.");
    if (this.odwiedzajacyForm.valid) {
      const odwiedzajacyData: Odwiedzajacy = {
        idOdwiedzajacy: this.odwiedzajacyForm.get('idOdwiedzajacy')?.value,
        imie: this.odwiedzajacyForm.get('imie')?.value,
        nazwisko: this.odwiedzajacyForm.get('nazwisko')?.value,
        czyZapalilZnicz: this.odwiedzajacyForm.get('czyZapalilZnicz')?.value,
      };
  
      this.odwiedzajacyService.dodajOdwiedzajacy(odwiedzajacyData).subscribe(
        () => {
          console.log('OdwiedzajacyDodany został dodany.');
  
          const idOdwiedzajacego = odwiedzajacyData.idOdwiedzajacy;
          console.log("idOdwiedzajacego" + idOdwiedzajacego);
          this.grobowiecService.dodajOdwiedzajacegoDoGrobowca(this.idGrobowca, idOdwiedzajacego).subscribe(
            () => {
              console.log('Odwiedzający '+{idOdwiedzajacego} +' został dodany do grobowca '+this.idGrobowca);
              this.router.navigate(['']);
            },
            (error) => {
              console.error('Wystąpił błąd podczas dodawania odwiedzającego do grobowca.', error?.error);
            }
          );
  
        },
        (error) => {
          console.error('Wystąpił błąd podczas dodawania odwiedzającego.', error?.error);
          console.log('Błędy walidacji:', error?.error?.errors);
        }
      );
    } else {
      this.odwiedzajacyForm.markAllAsTouched();
    }
  }
}
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WlascicielService } from '../service/wlasciciel.service';
import { Router } from '@angular/router';
import { TokenService } from '../service/token.service';
import { UzytkownikService } from '../service/uzytkownik.service';
import { Wlasciciel } from '../models/wlasciciel';

@Component({
  selector: 'app-dodaj-wlasciciela',
  templateUrl: './dodaj-wlasciciela.component.html',
  styleUrls: ['./dodaj-wlasciciela.component.css']
})
export class DodajWlascicielaComponent implements OnInit {
  wlascicielForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private wlascicielService: WlascicielService,
    private uzytkownikService: UzytkownikService,
    private tokenService: TokenService,
    private router: Router
  ) {
    this.wlascicielForm = this.fb.group({
      idWlasciciel: [{value: '', disabled: true}, [Validators.required]],
      imie: ['', [Validators.required]],
      nazwisko: ['', [Validators.required]],
      adres: ['', [Validators.required]],
      ilGrobowcow: [0, [Validators.min(0)]]
    });
  }

  ngOnInit() {
    const token = this.tokenService.getToken();
    if (token) {
      this.uzytkownikService.getUserIdFromToken(token).subscribe(
        (userId) => {
          if (userId !== null) {
            this.wlascicielForm.get('idWlasciciel')?.patchValue(userId);
          }
        }
      );
    }
  }

  dodajWlasciciela() {
    if (this.wlascicielForm.valid) {
      const wlascicielData: Wlasciciel = {
        idWlasciciel: this.wlascicielForm.get('idWlasciciel')?.value,
        imie: this.wlascicielForm.get('imie')?.value,
        nazwisko: this.wlascicielForm.get('nazwisko')?.value,
        adres: this.wlascicielForm.get('adres')?.value,
        ilGrobowcow: 0,
        grobowce: []
      };
  
      this.wlascicielService.dodajWlasciciela(wlascicielData).subscribe(
        () => {
          console.log('Właściciel został dodany.');
          this.router.navigate(['/kupgrobowiec']);
        },
        (error) => {
          console.error('Wystąpił błąd podczas dodawania właściciela.', error?.error);
          console.log('Błędy walidacji:', error?.error?.errors);
        }
      );
    } else {
      this.wlascicielForm.markAllAsTouched();
    }
  }
  
}

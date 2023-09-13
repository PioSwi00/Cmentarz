import { Component, ViewEncapsulation } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { TokenService } from '../service/token.service';

@Component({
  selector: 'app-zajete-grobowce',
  templateUrl: './zajete-grobowce.component.html',
  styleUrls: ['./zajete-grobowce.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ZajeteGrobowceComponent {
  zajeteGroby: Grobowiec[] = [];

  constructor(private grobowiecService: GrobowiecService,
    private router: Router,
    private route: ActivatedRoute,
    private tokenService: TokenService) { }

  ngOnInit(): void {
    const token = this.tokenService.getToken();
    if (token) {
    this.pobierzZajeteGroby();
  }
  else {
    alert('Zaloguj się, aby uzyskać dostęp do tej strony.');
    this.router.navigate(['/login']);
  }
  }
  

  pobierzZajeteGroby() {
    this.grobowiecService.pobierzZajeteGroby().subscribe(
      (response) => {
        this.zajeteGroby = response;
      },
      (error) => {
        console.error('Wystąpił błąd podczas pobierania zajętych grobów.', error);
      }
    );
  }
  odwiedzGrobow(grobowiecId: number) {
    this.router.navigate(['/dodajOdwiedzajacy', grobowiecId]);
  }
  
}

import { Component } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-zajete-grobowce',
  templateUrl: './zajete-grobowce.component.html',
  styleUrls: ['./zajete-grobowce.component.css']
})
export class ZajeteGrobowceComponent {
  zajeteGroby: Grobowiec[] = [];
  lokalizacja: string ="";

  constructor(private grobowiecService: GrobowiecService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.lokalizacja = params['lokalizacja'];
      this.pobierzZajeteGroby();
    });
  }

  pobierzZajeteGroby() {
    this.grobowiecService.pobierzZajeteGroby().subscribe(
      (response) => {
        this.zajeteGroby = this.filtrujGrobyPoLokalizacji(response);
      },
      (error) => {
        console.error('Wystąpił błąd podczas pobierania zajętych grobów.', error);
      }
    );
  }

  filtrujGrobyPoLokalizacji(groby: Grobowiec[]) {
    return groby.filter(grob => grob.lokalizacja === this.lokalizacja);
  }

  odwiedzGrobow(grobowiecId: number) {
    this.router.navigate(['/dodajOdwiedzajacy', grobowiecId]);
  }
}

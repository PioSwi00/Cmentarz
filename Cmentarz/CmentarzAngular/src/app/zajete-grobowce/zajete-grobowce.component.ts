import { Component } from '@angular/core';
import { Grobowiec } from '../models/grobowiec';
import { GrobowiecService } from '../service/grobowiec.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-zajete-grobowce',
  templateUrl: './zajete-grobowce.component.html',
  styleUrls: ['./zajete-grobowce.component.css']
})
export class ZajeteGrobowceComponent {
  zajeteGroby: Grobowiec[] = [];

  constructor(private grobowiecService: GrobowiecService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.pobierzZajeteGroby();
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

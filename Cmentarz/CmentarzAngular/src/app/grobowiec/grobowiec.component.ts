import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GrobowiecService } from '../service/grobowiec.service';
import { Grobowiec } from '../models/grobowiec';


@Component({
  selector: 'app-grobowiec',
  templateUrl: './grobowiec.component.html',
  styleUrls: ['./grobowiec.component.css']
})
export class GrobowiecComponent implements OnInit {
  grobowiec: Grobowiec | null = null;

  constructor(
    private route: ActivatedRoute,
    private grobowiecService: GrobowiecService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.getGrobowiec(+id);
    }
  }

  getGrobowiec(id: number): void {
    this.grobowiecService.getGrobowiecById(id).subscribe(
      (grobowiec: Grobowiec) => {
        console.log(grobowiec); // Wyświetl odpowiedź w konsoli
        this.grobowiec = grobowiec;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
  
}

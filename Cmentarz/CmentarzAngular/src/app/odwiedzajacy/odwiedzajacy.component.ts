import { Component } from '@angular/core';

import { OdwiedzajacyService } from '../service/odwiedzajacy.service';
import { WyszukajOsobyResponse } from '../models/wyszukajosoby-response';

@Component({
  selector: 'app-odwiedzajacy',
  templateUrl: './odwiedzajacy.component.html',
  styleUrls: ['./odwiedzajacy.component.css']
})
export class OdwiedzajacyComponent {
  wyszukani: WyszukajOsobyResponse[] = [];

  wyszukajOdwiedzajacych(){
  }

  constructor(private odwiedzajacyService: OdwiedzajacyService){
    odwiedzajacyService.get().subscribe({
      next: (res) => {
        this.wyszukani = res;
      }
    })
  }
}

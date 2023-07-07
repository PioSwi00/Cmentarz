import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WlascicielService {
  private wlascicieleUrl = 'https://localhost:7116/api/WlascicielApi';

  constructor(private http: HttpClient) { }

  getWlasciciele(): Observable<any[]> {
    return this.http.get<any[]>(this.wlascicieleUrl);
  }
}

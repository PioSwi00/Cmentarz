import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Wlasciciel } from '../models/wlasciciel';

@Injectable({
  providedIn: 'root'
})
export class WlascicielService {
  private apiUrl = 'https://localhost:7116/api/WlascicielApi';

  constructor(private http: HttpClient) { }

  getWlasciciele(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getWlascicielById(id: number): Observable<Wlasciciel> {
    const url = `${this.apiUrl}/GetWlascicielById/${id}`;
    return this.http.get<Wlasciciel>(url);
  
  }

  dodajWlasciciela(wlasciciel: Wlasciciel): Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/DodajWlasciela`, wlasciciel);
  }
}

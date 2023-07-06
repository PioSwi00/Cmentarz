import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Grobowiec } from '../models/grobowiec';


@Injectable({
  providedIn: 'root'
})
export class GrobowiecService {
  private apiUrl = 'https://localhost:7116/api/GrobowiecApi'; // Zmień adres API na właściwy

  constructor(private http: HttpClient) { }

  getGrobowiecById(id: number): Observable<Grobowiec> {
    const url = `${this.apiUrl}/GrobowceFilteredById/${id}`;
    return this.http.get<Grobowiec>(url);
  }
}

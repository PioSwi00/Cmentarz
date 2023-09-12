import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Grobowiec } from '../models/grobowiec';
import { Odwiedzajacy } from '../models/odwiedzajacy';
import { Zmarly } from '../models/zmarly';



@Injectable({
  providedIn: 'root'
})
export class GrobowiecService {
  private apiUrl = 'https://localhost:7116/api/GrobowiecApi';

  constructor(private http: HttpClient) { }

  getGrobowiecById(id: number): Observable<Grobowiec> {
    const url = `${this.apiUrl}/GrobowceFilteredById/${id}`;
    return this.http.get<Grobowiec>(url);

  }

  wyszukajGroby(parametry: any): Observable<Grobowiec[]> {
    const params = new HttpParams({ fromObject: parametry });
    const url = `${this.apiUrl}/WyszukajGroby`;
    return this.http.get<Grobowiec[]>(url, { params });
  }

  pobierzWolneGroby(): Observable<Grobowiec[]> {
    const url = `${this.apiUrl}/PobierzWolneGroby`;
    return this.http.get<Grobowiec[]>(url);
  }

  getGrobowceByIdWlasciciela(id: number): Observable<Grobowiec[]> {
    const url = `${this.apiUrl}/PobierzGrobowceWlasciciela/${id}`;
    return this.http.get<Grobowiec[]>(url);

  }
  getOdwiedzajacyFromGrobowiec(id: number): Observable<Odwiedzajacy[]> {
    const url = `${this.apiUrl}/OdwiedzajacyGrobowiec/${id}`;
    return this.http.get<Odwiedzajacy[]>(url);
  }
  getZmarliFromGrobowiec(id: number): Observable<Zmarly[]> {
    const url = `${this.apiUrl}/zmarli/${id}`;
    return this.http.get<Zmarly[]>(url);
  }

}

import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { WyszukajOsobyResponse } from "../models/wyszukajosoby-response";
import { Odwiedzajacy } from "../models/odwiedzajacy";


@Injectable({
    providedIn: 'root'
})

export class OdwiedzajacyService{
    private readonly url: string = 'https://localhost:7116/api/WyszukajOdwiedzajacych';
    private apiUrl = 'https://localhost:7116/api/OdwiedzajacyApi';
    constructor(private httpClient: HttpClient) { }

    get(): Observable<WyszukajOsobyResponse[]> {
        return this.httpClient.get<WyszukajOsobyResponse[]>(this.url);
    }

    getWlascicielById(id: number | null): Observable<Odwiedzajacy | null> {
        const url = `${this.apiUrl}/GetOdwiedzajacyById/${id}`;
        return this.httpClient.get<Odwiedzajacy>(url)
      }
      
      dodajOdwiedzajacy(odwiedzajacy: Odwiedzajacy): Observable<any>{
        return this.httpClient.post<any>(`${this.apiUrl}/DodajOdwiedzajacego`, odwiedzajacy);
      }
}
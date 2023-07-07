import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Zmarly } from '../models/zmarly';


@Injectable({
  providedIn: 'root'
})
export class ZmarlyService {
  private apiEndpoint ="https://localhost:7116/api/ZmarliApi/GetAll";
  constructor(private http: HttpClient) { }

  pobierzWszystkichZmarlych(): Observable<Zmarly[]> {
    return this.http.get<Zmarly[]>(this.apiEndpoint);
  }
}

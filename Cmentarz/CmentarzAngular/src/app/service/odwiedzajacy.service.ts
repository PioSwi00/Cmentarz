import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { WyszukajOsobyResponse } from "../models/wyszukajosoby-response";


@Injectable({
    providedIn: 'root'
})

export class OdwiedzajacyService{
    private readonly url: string = 'https://localhost:7116/api/WyszukajOdwiedzajacych';
    constructor(private httpClient: HttpClient) { }

    get(): Observable<WyszukajOsobyResponse[]> {
        return this.httpClient.get<WyszukajOsobyResponse[]>(this.url);
    }
}
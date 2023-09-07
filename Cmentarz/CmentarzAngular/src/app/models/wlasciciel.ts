import { Grobowiec } from "./grobowiec";

export interface Wlasciciel {
    idWlasciciel: number;
    imie: string;
    nazwisko: string;
    adres: string;
    ilGrobowcow: number;
    grobowce: Grobowiec[];
}
  
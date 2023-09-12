import { Odwiedzajacy } from "./odwiedzajacy";
import { Zmarly } from "./zmarly";

export interface Grobowiec {
    idGrobowiec: number;
    lokalizacja:string;
    idWlasciciel:number;
    czyZajety:boolean;
    cena:number;
    sektor:string;
    ListaOdwiedzajacy?: Odwiedzajacy[];
    Zmarli?: Zmarly[];
  }
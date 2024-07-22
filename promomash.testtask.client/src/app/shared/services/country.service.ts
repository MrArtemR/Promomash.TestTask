import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class CountryService {
  constructor(private http: HttpClient) { }

  public getCountries(): Observable<PagingCollection> {
    return this.http.get<PagingCollection>('/weatherforecast/countries');
  }

  public getProvinces(countryId: number): Observable<Province[]> {
    return this.http.get<Province[]>(`/weatherforecast/countries/${countryId}/provinces`);
  }
}

export interface Country {
  id: number,
  name: string
}

export interface PagingCollection {
  entities: Country[],
  offset: number,
  totalCount: number,
}

export interface Province {
  id: number,
  name: string
}

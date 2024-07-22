import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) { }

  public addUser(userParams: IUserParams): Observable<number> {
    return this.http.post<number>('/weatherforecast/users', userParams);
  }
}

export interface IUserParams {
  login: string
  password: string
  countryId: number
  provinceId: number
}

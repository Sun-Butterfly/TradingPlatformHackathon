import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

export interface LogInResponse {
  token: string
}

export interface LogInRequest{
  email: string,
  password: string
}

export interface ErrorModel{
  message: string
}

@Injectable({providedIn: "root"})
export class HttpService {

  constructor(private http: HttpClient) {
  }

  baseurl: string = "http://localhost:5141"

  logIn(logInRequest: LogInRequest): Observable<LogInResponse> {
    const url: string = `${this.baseurl}/Auth/LogIn`
    return this.http.post<LogInResponse>(url, logInRequest)
  }

}
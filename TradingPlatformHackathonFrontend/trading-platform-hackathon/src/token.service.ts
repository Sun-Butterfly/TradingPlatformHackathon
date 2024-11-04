import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() {
  }

  setToken(token: string) {
    localStorage.setItem("authToken", token);
  }

  getToken(): string | null {
    return localStorage.getItem("authToken");
  }

  logOut(){
    localStorage.removeItem("authToken");
  }

  isAuthorized() {
    return this.getToken() != null;

  }
}

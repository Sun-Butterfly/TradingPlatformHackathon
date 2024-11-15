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

  logOut() {
    localStorage.removeItem("authToken");
  }

  isAuthorized() {
    return this.getToken() != null;

  }

  getRole(): string {
    let token = this.getToken();
    if (token === null) {
      return "";
    }

    let data = token.split(".")[1];
    data = window.atob(data)
    let jwt = JSON.parse(data);
    let role = jwt["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    return role;
  }

  getId():number {
    let token = this.getToken();
    if(token === null){
      return -1;
    }

    let data = token.split(".")[1];
    data = window.atob(data)
    let jwt = JSON.parse(data);
    let id  = ~~jwt["Id"]
    return id;
  }
}

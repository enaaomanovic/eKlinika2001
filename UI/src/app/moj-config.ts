

import { Router } from "@angular/router";
// import { UnauthorizedInterceptor } from "./unauthorized.interceptor";
import { HttpHeaders } from "@angular/common/http";

export class MojConfig {
  static adresa_servera = "http://localhost:5266";
  static authTokenKey = 'auth_token';

  static router: Router;

  static postaviRouter(router: Router) {
    this.router = router;
  }

  static postaviKorisnika(username: string, password: string) {
    localStorage.setItem(this.authTokenKey, btoa(`${username}:${password}`));
  }

  static odlogujKorisnika() {
    localStorage.removeItem(this.authTokenKey);
  }

  static getAuthToken(): string | null {
    return localStorage.getItem(this.authTokenKey);
  }
 

  static http_opcije() {
    const authToken = this.getAuthToken();
    let headers = new HttpHeaders({
      "Content-Type": "application/json",
    });
    if (authToken) {
      headers = headers.set("Authorization", `Basic ${authToken}`);
    }
    return { headers: headers };
  }

  static handleUnauthorized() {
   
  }
}

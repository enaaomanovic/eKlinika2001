import { HttpHeaders } from "@angular/common/http";

export class MojConfig {
  static adresa_servera = "https://localhost:59904";
  static username: string = "";
  static password: string = "";

  static postaviKorisnika(username: string, password: string) {
    this.username = username;
    this.password = password;
  }
  
  static odlogujKorisnika() {
    this.username = "";
    this.password = "";
  }

  static http_opcije() {
    const token = btoa(`${this.username}:${this.password}`);
    const headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Authorization": "Basic " + token
    });
    return { headers: headers };
  }
}

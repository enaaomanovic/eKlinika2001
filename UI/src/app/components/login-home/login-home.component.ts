import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable, firstValueFrom } from 'rxjs';
import { MojConfig } from 'src/app/moj-config';

@Component({
  selector: 'app-login-home',
  templateUrl: './login-home.component.html',
  styleUrls: ['./login-home.component.css']
})
export class LoginHomeComponent implements OnInit {
  prijemPacijenta: any;
  pacijenti: any[] = [];
  ljekari: any[] = [];

  constructor(private http: HttpClient) { }

  async getPrijemPacijenta() {
    try {
      const response = await firstValueFrom(this.http.get(MojConfig.adresa_servera + "/PrijemPacijenta"));
      this.prijemPacijenta = response;
    } catch (error) {
      console.error('Greška pri dobijanju podataka:', error);
    }
  }

  async getPacijent(pacijentId: number): Promise<void> {
    try {
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Pacijent/" + pacijentId));
      this.pacijenti[pacijentId] = `${response.ime} ${response.prezime}`;
    } catch (error) {
      console.error('Greška pri dobijanju podataka o pacijentu:', error);
      this.pacijenti[pacijentId] = 'Nepoznato';
    }
  }

  async getLjekar(ljekarId: number): Promise<void> {
    try {
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Ljekar/" + ljekarId));
      this.ljekari[ljekarId] = `${response.ime} ${response.prezime} - ${response.sifra}  `;
    } catch (error) {
      console.error('Greška pri dobijanju podataka o ljekaru:', error);
      this.ljekari[ljekarId] = 'Nepoznato';
    }
  }

  async ngOnInit(): Promise<void> {
    await this.getPrijemPacijenta();
    for (let prijem of this.prijemPacijenta) {
      await this.getPacijent(prijem.pacijentId);
      await this.getLjekar(prijem.nadlezniLjekarId);
    }
  }
}


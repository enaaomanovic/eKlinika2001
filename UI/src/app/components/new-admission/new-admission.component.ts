import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

import { MojConfig } from 'src/app/moj-config';

import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-new-admission',
  templateUrl: './new-admission.component.html',
  styleUrls: ['./new-admission.component.css'],


})
export class NewAdmissionComponent implements OnInit {
  pacijenti: any[] = [];
  ljekari: any[] = [];

  myForm: FormGroup;
  minDateTime: string;

  constructor(private http: HttpClient, private fb: FormBuilder,private _snackBar: MatSnackBar) {
    this.myForm = this.fb.group({
      datumIVrijemePrijema: ['', Validators.required],
      pacijentId: ['', Validators.required],
      nadlezniLjekarId: ['', Validators.required],
      hitniPrijem: [false],


    });
    const currentDate = new Date();
    this.minDateTime = this.formatDateTime(currentDate);
  }

  formatDateTime(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); 
    const day = date.getDate().toString().padStart(2, '0');
    const hours = date.getHours().toString().padStart(2, '0');
    const minutes = date.getMinutes().toString().padStart(2, '0');
    return `${year}-${month}-${day}T${hours}:${minutes}`;
}
  openSnackBar(message: string, action: string) {
    console.log("Poruka bi trebala bit ispisana");
    this._snackBar.open(message, action, {
      duration: 2000, 
    });
  }
  btnDodaj(): void {
    if (!this.myForm.valid) {
        this.openSnackBar('Forma za unos nije zadovoljena!', 'Zatvori');
        return;
    }

    const datumIVrijemePrijemaControl = this.myForm.get('datumIVrijemePrijema');
    const pacijentIdControl = this.myForm.get('pacijentId');
    const nadlezniLjekarIdControl = this.myForm.get('nadlezniLjekarId');
    const hitniPrijemControl = this.myForm.get('hitniPrijem');

    if (datumIVrijemePrijemaControl && pacijentIdControl && nadlezniLjekarIdControl && hitniPrijemControl) {
        // Provjera vrijednosti hitniPrijem
        const hitniPrijemValue = hitniPrijemControl.value === true ? true : false;

        const saljemo = {
            datumIVrijemePrijema: datumIVrijemePrijemaControl.value,
            pacijentId: pacijentIdControl.value,
            nadlezniLjekarId: nadlezniLjekarIdControl.value,
            hitniPrijem: hitniPrijemValue,
        };

        const headers = MojConfig.http_opcije();

        this.http.post(MojConfig.adresa_servera + '/PrijemPacijenta', saljemo, headers).subscribe({
            next: (x: any) => {
                this.openSnackBar('Uspješno ste izvršili zahtjev!', 'Zatvori');
                console.log('Novi prijem uspješno dodat:', x);
                this.myForm.reset();
            },
            error: (x: any) => {
                console.error('Greška pri dodavanju novog prijema:', x);
            }
        });
    }
}


  ngOnInit(): void {
    this.ucitajLjekare(),
      this.ucitajPacijente()

  }


  title = 'angular-dropdownlist';
  public dropdownListFilterType: string = 'Contains';
  public dataFields: Object = { text: 'Name', value: 'Id' };
  public localData: Object[] = [];
  public sampleData: string[] = [];

  ucitajPacijente() {
    const headers = MojConfig.http_opcije();

    this.http.get<any[]>(MojConfig.adresa_servera + '/Pacijent',headers).subscribe(
      (response) => {
        this.localData = response.map(pacijent => ({ Name: `${pacijent.ime} ${pacijent.prezime}`, Id: pacijent.id }));
        console.log('Podaci o pacijentima:', this.localData);
      },
      (error) => {
        console.error('Greška pri dobijanju podataka o pacijentima:', error);
      }
    );
  }



  ucitajLjekare() {
    const headers = MojConfig.http_opcije();

    this.http.get<any[]>(MojConfig.adresa_servera + '/Ljekar?Titula=' + 0,headers).subscribe(
      (response) => {
        this.ljekari = response;
        console.log('Podaci o ljekarima:', this.ljekari);
      },
      (error) => {
        console.error('Greška pri dobijanju podataka o ljekarima:', error);
      }
    );
  }

}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

import { MojConfig } from 'src/app/moj-config';

import { Query, DataManager, ODataV4Adaptor } from '@syncfusion/ej2-data';
import { FilteringEventArgs } from '@syncfusion/ej2-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';

@Component({
  selector: 'app-new-admission',
  templateUrl: './new-admission.component.html',
  styleUrls: ['./new-admission.component.css'],


})
export class NewAdmissionComponent implements OnInit {
  pacijenti: any[] = [];
  ljekari: any[] = [];

  myForm: FormGroup;


  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.myForm = this.fb.group({
      datumIVrijemePrijema: ['', Validators.required],
      pacijentId: ['', Validators.required],
      nadlezniLjekarId: ['', Validators.required],
      hitniPrijem: [false],

    });
  }

  btnDodaj(): void {
    if (!this.myForm.valid) {
      return;
    }

    const datumIVrijemePrijemaControl = this.myForm.get('datumIVrijemePrijema');
    const ppacijentIdControl = this.myForm.get('pacijentId');
    const nadlezniLjekarIdControl = this.myForm.get('nadlezniLjekarId');
    const hitniPrijemControl = this.myForm.get('hitniPrijem');



    if (datumIVrijemePrijemaControl && ppacijentIdControl && nadlezniLjekarIdControl && hitniPrijemControl) {

      const saljemo = {
        datumIVrijemePrijema: datumIVrijemePrijemaControl.value,
        pacijentId: ppacijentIdControl.value,
        nadlezniLjekarId: nadlezniLjekarIdControl.value,
        hitniPrijem: hitniPrijemControl.value,

      };

      this.http.post(MojConfig.adresa_servera + '/PrijemPacijenta', saljemo).subscribe({
        next: (x: any) => {

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
    this.http.get<any[]>(MojConfig.adresa_servera + '/Pacijent').subscribe(
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
    this.http.get<any[]>(MojConfig.adresa_servera + '/Ljekar?Titula=' + 0).subscribe(
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

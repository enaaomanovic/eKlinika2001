import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MojConfig } from 'src/app/moj-config';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { map } from 'rxjs';

@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.css']

})

export class NewPatientComponent implements OnInit {

  prikazi: boolean = false;
  brisanje: boolean = false;
  uredjivanje: boolean = false;
  pacijent: any;
  pacijenti: any[] = [];
  myForm: FormGroup;
  patientToDeleteId: any;
  patientToEditId: any;

  constructor(private http: HttpClient, private fb: FormBuilder,private _snackBar: MatSnackBar) {

    this.myForm = this.fb.group({
      ime: ['', Validators.required],
      prezime: ['', Validators.required],
      datumRodjenja: ['', Validators.required],
      spol: ['', Validators.required],
      adresa: [''],
      brojTelefona: ['']
    });
  }

  ngOnInit(): void {
    this.ucitajPacijente();
  }

  openModal() {

    this.prikazi = true;
  }
  openSnackBar(message: string, action: string, position: 'left' | 'right' = 'left') {
    
    const config = new MatSnackBarConfig();
    config.duration = 2000;
    config.horizontalPosition = position === 'left' ? 'start' : 'end';
    config.verticalPosition = 'bottom';
    
    this._snackBar.open(message, action, config);
}
  closeModal() {
 
    this.prikazi = false;
  }

  openModalObrisi(pacijentId: any) {
    this.patientToDeleteId = pacijentId;
   
    this.brisanje = true;
  }

  closeModalObrisi() {

    this.brisanje = false;
  }

  openModalUredi(pacijentId: any) {
    this.patientToEditId = pacijentId;
    this.ucitajPacijenta(this.patientToEditId);

  
    this.uredjivanje = true;
  }

  closeModalUredi() {

    this.uredjivanje = false;
  }
  ucitajPacijente() {
    const headers = MojConfig.http_opcije();

    this.http.get<any[]>(MojConfig.adresa_servera + '/Pacijent',headers).subscribe(
      (response) => {
        this.pacijenti = response;
        console.log('Podaci o pacijentima:', this.pacijenti);
      },
      (error) => {
        console.error('Greška pri dobijanju podataka o pacijentima:', error);
      }
    );
  }


  

  ucitajPacijenta(pacijentId: any) {
    const headers = MojConfig.http_opcije();

    this.http.get<any>(MojConfig.adresa_servera + '/Pacijent/' + pacijentId,headers).subscribe(
      (response) => {

        this.myForm.patchValue({
          ime: response.ime,
          prezime: response.prezime,
          datumRodjenja: response.datumRodjenja,
          spol: response.spol,
          adresa: response.adresa,
          brojTelefona: response.brojTelefona
        });

        console.log('Podaci o pacijentu:', response);
      },
      (error) => {
        console.error('Greška pri dobijanju podataka o pacijentu:', error);
      }
    );
  }

  btnObrisi(): void {
   
    if (this.patientToDeleteId) {
    const headers = MojConfig.http_opcije();

      this.http.delete(MojConfig.adresa_servera + '/Pacijent/' + this.patientToDeleteId,headers).subscribe({
        next: (x: any) => {
          this.openSnackBar('Uspješno ste obrisali pacijenta!', 'Zatvori');

          this.ucitajPacijente();
          console.log('Pacijent uspješno obrisan:', x);

          this.ucitajPacijente();
          this.brisanje = false;
          this.myForm.reset();
        },
        error: (x: any) => {
          this.openSnackBar('Pacijent nije obrisan', 'Zatvori');

          console.error('Greška pri brisanju pacijenta:', x);


        }
      });
    }
  }

  btnUredi(): void {
    
    if (this.patientToEditId && this.myForm.valid) {
      const updatedPatientData = this.myForm.value;
      updatedPatientData.spol = parseInt(updatedPatientData.spol);
      const headers = MojConfig.http_opcije();

      this.http.put<any>(MojConfig.adresa_servera + '/Pacijent/' + this.patientToEditId, updatedPatientData,headers).subscribe({
        next: (response: any) => {
       
          this.openSnackBar('Uspješno ste ažurirali zahtjev!', 'Zatvori');

          console.log('Podaci o pacijentu su uspješno ažurirani:', response);


          this.ucitajPacijente();


          this.uredjivanje = false;


          this.myForm.reset();
        },
        error: (error: any) => {
          console.error('Greška pri ažuriranju podataka o pacijentu:', error);
          this.openSnackBar('Ažuriranje nije uspjelo!', 'Zatvori');
        }
      });
    } else {
  
      this.openSnackBar('Forma za unos nije zadovoljena!', 'Zatvori', 'left');

      console.error('Neispravni podaci za ažuriranje pacijenta ili nije odabran pacijent za uređivanje.');
    }
  }




  btnDodaj(): void {
    if (!this.myForm.valid) {
      this.openSnackBar('Forma za unos nije zadovoljena!', 'Zatvori', 'left');


      return;
 
    
    }

    const imeControl = this.myForm.get('ime');
    const prezimeControl = this.myForm.get('prezime');
    const datumRodjenjaControl = this.myForm.get('datumRodjenja');
    const spolControl = this.myForm.get('spol');
    const adresaControl = this.myForm.get('adresa');
    const brojTelefonaControl = this.myForm.get('brojTelefona');

    
    if (imeControl && prezimeControl && datumRodjenjaControl && spolControl && adresaControl && brojTelefonaControl) {

      const saljemo = {
        ime: imeControl.value,
        prezime: prezimeControl.value,
        datumRodjenja: datumRodjenjaControl.value,
        spol: parseInt(spolControl.value), 
        adresa: adresaControl.value,
        brojTelefona: brojTelefonaControl.value
      };
      const headers = MojConfig.http_opcije();

      this.http.post(MojConfig.adresa_servera + '/Pacijent', saljemo,headers).subscribe({
        next: (x: any) => {
          this.openSnackBar('Uspješno ste izvršili zahtjev!', 'Zatvori');
          console.log('Novi pacijent uspješno dodat:', x);

          this.ucitajPacijente(); 
          this.prikazi = false; 
          this.myForm.reset(); 
        },
        error: (x: any) => {
          this.openSnackBar('Pacijent nije dodas!', 'Zatvori');

          console.error('Greška pri dodavanju novog pacijenta:', x);


        }
      });
    }
  }



}

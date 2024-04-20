import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MojConfig } from 'src/app/moj-config';
import { MatSnackBar } from '@angular/material/snack-bar';

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
    console.log("Open modal method called");
    this.prikazi = true;
  }
  openSnackBar(message: string, action: string) {
    console.log("Poruka bi trebala bit ispisana");
    this._snackBar.open(message, action, {
      duration: 2000, 
    });
  }

  closeModal() {
    console.log("close modal method called");
    this.prikazi = false;
  }

  openModalObrisi(pacijentId: any) {
    this.patientToDeleteId = pacijentId;
    console.log(pacijentId);
    console.log("Open modal for brisanje method called");
    this.brisanje = true;
  }

  closeModalObrisi() {
    console.log("close modal for delete method called");
    this.brisanje = false;
  }

  openModalUredi(pacijentId: any) {
    this.patientToEditId = pacijentId;
    this.ucitajPacijenta(this.patientToEditId);

    console.log(pacijentId);
    console.log("Open modal for brisanje method called");
    this.uredjivanje = true;
  }

  closeModalUredi() {
    console.log("close modal for delete method called");
    this.uredjivanje = false;
  }
  ucitajPacijente() {
    this.http.get<any[]>(MojConfig.adresa_servera + '/Pacijent').subscribe(
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
    this.http.get<any>(MojConfig.adresa_servera + '/Pacijent/' + pacijentId).subscribe(
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
    console.log("brisanje pozvano");
    if (this.patientToDeleteId) {
      this.http.delete(MojConfig.adresa_servera + '/Pacijent/' + this.patientToDeleteId).subscribe({
        next: (x: any) => {
          this.ucitajPacijente();
          console.log('Pacijent uspješno obrisan:', x);

          this.ucitajPacijente();
          this.brisanje = false;
          this.myForm.reset();
        },
        error: (x: any) => {
          console.error('Greška pri brisanju pacijenta:', x);


        }
      });
    }
  }

  btnUredi(): void {
    console.log("Uređivanje pozvano");

    if (this.patientToEditId && this.myForm.valid) {
      const updatedPatientData = this.myForm.value;
      updatedPatientData.spol = parseInt(updatedPatientData.spol);

      this.http.put<any>(MojConfig.adresa_servera + '/Pacijent/' + this.patientToEditId, updatedPatientData).subscribe({
        next: (response: any) => {
          this.openSnackBar('Uspješno ste izvršili zahtjev!', 'Zatvori');

          console.log('Podaci o pacijentu su uspješno ažurirani:', response);


          this.ucitajPacijente();


          this.uredjivanje = false;


          this.myForm.reset();
        },
        error: (error: any) => {
          console.error('Greška pri ažuriranju podataka o pacijentu:', error);
        }
      });
    } else {
      console.error('Neispravni podaci za ažuriranje pacijenta ili nije odabran pacijent za uređivanje.');
    }
  }




  btnDodaj(): void {
    if (!this.myForm.valid) {
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
        spol: parseInt(spolControl.value), // Pretvaranje stringa u broj
        adresa: adresaControl.value,
        brojTelefona: brojTelefonaControl.value
      };

      this.http.post(MojConfig.adresa_servera + '/Pacijent', saljemo).subscribe({
        next: (x: any) => {
       
          console.log('Novi pacijent uspješno dodat:', x);

          this.ucitajPacijente(); // Ponovno učitavanje liste pacijenata nakon dodavanja novog
          this.prikazi = false; // Zatvaranje modalnog prozora nakon dodavanja
          this.myForm.reset(); // Resetovanje forme nakon dodavanja
        },
        error: (x: any) => {
          console.error('Greška pri dodavanju novog pacijenta:', x);


        }
      });
    }
  }



}

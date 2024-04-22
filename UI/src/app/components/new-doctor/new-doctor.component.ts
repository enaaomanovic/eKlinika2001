import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MojConfig } from 'src/app/moj-config';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Component({
  selector: 'app-new-doctor',
  templateUrl: './new-doctor.component.html',
  styleUrls: ['./new-doctor.component.css']
})
export class NewDoctorComponent implements OnInit {
  prikazi: boolean = false;
  brisanje: boolean = false;
  uredjivanje: boolean = false;
  ljekari: any[] = [];
  myForm: FormGroup;
  myFormForEdit: FormGroup;

  doctorToDeleteId: any;
  doctorToEditId: any;


  constructor(private http: HttpClient, private fb: FormBuilder,private _snackBar: MatSnackBar) {

    this.myForm = this.fb.group({
      ime: ['', Validators.required],
      prezime: ['', Validators.required],
      titula: ['', Validators.required],
      sifra: ['', Validators.required],
      username: ['', Validators.required],
      lozinka: ['', Validators.required]
    });

    this.myFormForEdit = this.fb.group({
      ime: ['', Validators.required],
      prezime: ['', Validators.required],
      titula: ['', Validators.required],
      sifra: ['', Validators.required],

    });

  }
  openSnackBar(message: string, action: string, position: 'left' | 'right' = 'left') {
    console.log("Poruka bi trebala bit ispisana");
    const config = new MatSnackBarConfig();
    config.duration = 2000;
    config.horizontalPosition = position === 'left' ? 'start' : 'end';
    config.verticalPosition = 'bottom';
    
    this._snackBar.open(message, action, config);
}

  ngOnInit(): void {
    this.ucitajLjekare();
  }

  openModal() {
    console.log("Open modal method called");
    this.prikazi = true;
  }

  closeModal() {
    console.log("close modal method called");
    this.prikazi = false;
  }

  openModalObrisi(ljekarId: any) {
    this.doctorToDeleteId = ljekarId;
    console.log(this.doctorToDeleteId);
    this.brisanje = true;

    console.log("Open modal for brisanje method called");
  }

  closeModalObrisi() {
    console.log("close modal for delete method called");
    this.brisanje = false;
  }

  openModalUredi(ljekarId: any) {
    this.doctorToEditId = ljekarId;
    this.ucitajLjekara(this.doctorToEditId);

    console.log(ljekarId);
    console.log("Open modal for brisanje method called");
    this.uredjivanje = true;
  }

  closeModalUredi() {
    console.log("close modal for delete method called");
    this.uredjivanje = false;
  }

  ucitajLjekara(ljekarId: any) {
    const headers = MojConfig.http_opcije();

    this.http.get<any>(MojConfig.adresa_servera + '/Ljekar/' + ljekarId,headers).subscribe(
      (response) => {

        this.myFormForEdit.patchValue({
          ime: response.ime,
          prezime: response.prezime,
          titula: response.titula,
          sifra: response.sifra,

        });

        console.log('Podaci o ljekaru:', response);
      },
      (error) => {
        console.error('Greška pri dobijanju podataka o ljekaru:', error);
      }
    );
  }
  btnUredi(): void {
    console.log("Uređivanje pozvano");
    if (this.doctorToEditId && this.myFormForEdit.valid) {
      const updatedDoctorData = this.myFormForEdit.value;
      updatedDoctorData.titula = parseInt(updatedDoctorData.titula);

      // Uklonimo provjeru trenutne titule i nastavimo s ažuriranjem
      const headers = MojConfig.http_opcije();

      this.http.put<any>(MojConfig.adresa_servera + '/Ljekar/' + this.doctorToEditId, updatedDoctorData, headers).subscribe({
        next: (response: any) => {
          this.openSnackBar('Uspješno ste ažurilali zahtjev!', 'Zatvori');
          console.log('Podaci o ljekaru su uspješno ažurirani:', response);
          this.ucitajLjekare();
          this.uredjivanje = false;
          this.myFormForEdit.reset();
        },
        error: (error: any) => {
          console.error('Greška pri ažuriranju podataka o ljekaru:', error);
        }
      });
    } else {
      this.openSnackBar('Forma za unos nije zadovoljena!', 'Zatvori', 'left');

      console.error('Neispravni podaci za ažuriranje ljekara ili nije odabran ljekar za uređivanje.');
    }
  }



  ucitajLjekare() {
    const headers = MojConfig.http_opcije();

    this.http.get<any[]>(MojConfig.adresa_servera + '/Ljekar',headers).subscribe(
      (response) => {
        this.ljekari = response;
        console.log('Podaci o ljekarima:', this.ljekari);
      },
      (error) => {
        console.error('Greška pri dobijanju podataka o ljekarima:', error);
      }
    );
  }


  btnDodaj(): void {
    if (!this.myForm.valid) {
      this.openSnackBar('Forma za unos nije zadovoljena!', 'Zatvori', 'left');

      return;
    }

    const imeControl = this.myForm.get('ime');
    const prezimeControl = this.myForm.get('prezime');
    const titulaControl = this.myForm.get('titula');
    const sifraControl = this.myForm.get('sifra');
    const usernameControl = this.myForm.get('username');
    const lozinkaControl = this.myForm.get('lozinka');


    if (imeControl && prezimeControl && titulaControl && sifraControl && usernameControl && lozinkaControl) {

      const saljemo = {
        ime: imeControl.value,
        prezime: prezimeControl.value,
        titula: parseInt(titulaControl.value),
        sifra: sifraControl.value,
        username: usernameControl.value,
        lozinka: lozinkaControl.value

      };
      
      const headers = MojConfig.http_opcije();

      this.http.post(MojConfig.adresa_servera + '/Ljekar', saljemo,headers).subscribe({
        next: (x: any) => {
          this.ucitajLjekare();
          console.log('Novi ljekar uspješno dodat:', x);
          this.openSnackBar('Uspješno ste izviršili zahtjev!', 'Zatvori');

          this.ucitajLjekare();
          this.prikazi = false;
          this.myForm.reset();
        },
        error: (x: any) => {
          console.error('Greška pri dodavanju novog ljekara:', x);


        }
      });
    }
  }


  btnObrisi(): void {
    console.log("brisanje pozvano");
    if (this.doctorToDeleteId) {
      const headers = MojConfig.http_opcije();

      this.http.delete(MojConfig.adresa_servera + '/Ljekar/' + this.doctorToDeleteId,headers).subscribe({
        next: (x: any) => {
          this.openSnackBar('Uspješno ste obrisali ljekara!', 'Zatvori');

          this.ucitajLjekare();
          console.log('Doktor uspješno obrisan:', x);

          this.ucitajLjekare();
          this.brisanje = false;
          this.myForm.reset();
        },
        error: (x: any) => {
          console.error('Greška pri brisanju doktora:', x);
          this.openSnackBar('Ljekar nije obrisan', 'Zatvori');



        }
      });
    }
  }

}

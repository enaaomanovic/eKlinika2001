import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MojConfig } from 'src/app/moj-config';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

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


  constructor(private http: HttpClient, private fb: FormBuilder) {

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
    this.http.get<any>(MojConfig.adresa_servera + '/Ljekar/' + ljekarId).subscribe(
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


      this.getTitulaForDoctor(this.doctorToEditId).then((currentTitula: number) => {

        if (currentTitula === 0) {
          console.error('Nije moguće mijenjati titulu ljekara "Specijalista".');
          return;
        }




        this.http.put<any>(MojConfig.adresa_servera + '/Ljekar/' + this.doctorToEditId, updatedDoctorData).subscribe({
          next: (response: any) => {
            console.log('Podaci o ljekaru su uspješno ažurirani:', response);


            this.ucitajLjekare();


            this.uredjivanje = false;

            this.myFormForEdit.reset();
          },
          error: (error: any) => {
            console.error('Greška pri ažuriranju podataka o ljekaru:', error);
          }
        });
      }).catch((error: any) => {
        console.error('Greška pri dohvaćanju trenutne titule ljekara:', error);
      });
    } else {
      console.error('Neispravni podaci za ažuriranje ljekara ili nije odabran ljekar za uređivanje.');
    }
  }


  getTitulaForDoctor(doctorId: number): Promise<number> {
    return new Promise((resolve, reject) => {

      this.http.get<any>(MojConfig.adresa_servera + '/Ljekar/' + doctorId).subscribe({
        next: (response: any) => {

          const titula = response.titula;
          resolve(titula);
        },
        error: (error: any) => {
          console.error('Greška pri dohvaćanju podataka o ljekaru:', error);
          reject(error);
        }
      });
    });
  }

  ucitajLjekare() {
    this.http.get<any[]>(MojConfig.adresa_servera + '/Ljekar').subscribe(
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

      this.http.post(MojConfig.adresa_servera + '/Ljekar', saljemo).subscribe({
        next: (x: any) => {
          this.ucitajLjekare();
          console.log('Novi ljekar uspješno dodat:', x);

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
      this.http.delete(MojConfig.adresa_servera + '/Ljekar/' + this.doctorToDeleteId).subscribe({
        next: (x: any) => {
          this.ucitajLjekare();
          console.log('Doktor uspješno obrisan:', x);

          this.ucitajLjekare();
          this.brisanje = false;
          this.myForm.reset();
        },
        error: (x: any) => {
          console.error('Greška pri brisanju doktora:', x);


        }
      });
    }
  }

}

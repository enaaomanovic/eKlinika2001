import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, firstValueFrom } from 'rxjs';
import { MojConfig } from 'src/app/moj-config';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login-home',
  templateUrl: './login-home.component.html',
  styleUrls: ['./login-home.component.css']
})
export class LoginHomeComponent implements OnInit {
deleteItem(arg0: any) {
throw new Error('Method not implemented.');
}

  prijemPacijenta: any;
  pacijenti: any[] = [];
  ljekari: any[] = [];
  ljekariZaEdit: any[] = [];


  prikazi :boolean=false;
  brisanje :boolean=false;

  myForm: FormGroup;
  minDateTime: string;
  admissionToEditId: any;
  admissionToDeleteId: any;

  ljekariLoaded: boolean = false;

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
  async getPrijemPacijenta() {
    try {
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get(MojConfig.adresa_servera + "/PrijemPacijenta",headers));
      this.prijemPacijenta = response;
    } catch (error) {
      console.error('Greška pri dobijanju podataka:', error);
    }
  }



  async filterData() {
    const fromDate = (document.getElementById('from-date') as HTMLInputElement).value;
    const toDate = (document.getElementById('to-date') as HTMLInputElement).value;
    try {
      console.log("uslo u filter");
  
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get(MojConfig.adresa_servera +
         "/PrijemPacijenta?DatumIVrijemePrijemaStart=" + fromDate + '&DatumIVrijemePrijemaEnd=' + toDate,headers));
      this.prijemPacijenta = response;
      console.log(response);
    } catch (error) {
      console.error('Greška pri dobijanju podataka:', error);
    }
  }
  


  async getPacijent(pacijentId: number): Promise<void> {
    try {
      const headers = MojConfig.http_opcije();
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Pacijent/" + pacijentId,headers));
      this.pacijenti[pacijentId] = `${response.ime} ${response.prezime}`;
    } catch (error) {
      console.error('Greška pri dobijanju podataka o pacijentu:', error);
      this.pacijenti[pacijentId] = 'Nepoznato';
    }
  }

  async getLjekar(ljekarId: number): Promise<void> {
    try {
      console.log('Pozivam getLjekar sa ID:', ljekarId);
      const headers = MojConfig.http_opcije();
  
      const response = await firstValueFrom(this.http.get<any>(MojConfig.adresa_servera + "/Ljekar/" + ljekarId, headers));
      console.log('Odgovor od getLjekar:', response);
  
      this.ljekari[ljekarId] = `${response.ime} ${response.prezime} - ${response.sifra}`;
    } catch (error) {
      console.error('Greška pri dobijanju podataka o ljekaru:', error);
      this.ljekari[ljekarId] = 'Nepoznato';
    }
  }
  

  async ngOnInit(): Promise<void> {
    try {
      await this.getPrijemPacijenta();
  
  
      for (let prijem of this.prijemPacijenta) {
        this.getLjekar(prijem.nadlezniLjekarId);

        this.getPacijent(prijem.pacijentId);
      }
  
  
      this.ucitajPacijente();
      this.ucitajLjekare();
       
      
    } catch (error) {
      console.error('Greška u ngOnInit metodi:', error);
    }
  }
  
  ucitajLjekare() {
    if (!this.ljekariLoaded) {
      const headers = MojConfig.http_opcije();
  
      this.http.get<any[]>(MojConfig.adresa_servera + '/Ljekar?Titula=' + 0,headers).subscribe(
        (response) => {
          this.ljekariZaEdit = response;
          console.log('Podaci o ljekarima:', this.ljekariZaEdit);
        },
        (error) => {
          console.error('Greška pri dobijanju podataka o ljekarima:', error);
        }
      );
  
      this.ljekariLoaded = true; 
    }
  }
  
  
  
  title = 'angular-dropdownlist';
  public dropdownListFilterType: string = 'Contains';
  public dataFields: Object = { text: 'Name', value: 'Id' };
  public localData: Object[] = [];
  public sampleData: string[] = [];

  ucitajPacijente() {
    console.log("uslo");
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



  openModal(admissionToEditId:any) {
  
    this.admissionToEditId=admissionToEditId;
    this.ucitajAdmission(this.admissionToEditId);
   
    console.log(admissionToEditId);

    this.prikazi = true;
 
  }
  ucitajAdmission(admissionToEditId: any) {
    const headers = MojConfig.http_opcije();
  
    this.http.get<any>(MojConfig.adresa_servera + '/PrijemPacijenta/' + admissionToEditId, headers).subscribe(
      (response) => {
        this.myForm.patchValue({
          datumIVrijemePrijema: response.datumIVrijemePrijema,
          pacijentId: response.pacijentId,
          nadlezniLjekarId: response.nadlezniLjekarId,
          hitniPrijem: response.hitniPrijem
        });
  
        console.log('Podaci o prijemu:', response);
  

      },
      (error) => {
        console.error('Greška pri dobijanju podataka o prijemu:', error);
      }
    );
  }
  
  
 
  closeModal() {
    this.prikazi = false;
  }
  btnUredi() {
    if (this.admissionToEditId && this.myForm.valid) {
      const datumIVrijemePrijemaControl = this.myForm.get('datumIVrijemePrijema');
      const pacijentIdControl = this.myForm.get('pacijentId');
      const nadlezniLjekarIdControl = this.myForm.get('nadlezniLjekarId');
      const hitniPrijemControl = this.myForm.get('hitniPrijem');

      if (datumIVrijemePrijemaControl && pacijentIdControl && nadlezniLjekarIdControl && hitniPrijemControl) {
        const updatedadmissionData = {
          datumIVrijemePrijema: datumIVrijemePrijemaControl.value,
          pacijentId: pacijentIdControl.value,
          nadlezniLjekarId: nadlezniLjekarIdControl.value,
          hitniPrijem: hitniPrijemControl.value,
        };
       
        const headers = MojConfig.http_opcije();

        this.http.put<any>(MojConfig.adresa_servera + '/PrijemPacijenta/' + this.admissionToEditId, updatedadmissionData, headers).subscribe({
          next: (response: any) => {
            this.openSnackBar('Uspješno ste ažurirali zahtjev!', 'Zatvori');
            console.log('Podaci o prijemu su uspješno ažurirani:', response);
            this.getPrijemPacijenta();
            console.log('ucitavanje podataka:', response);
           this.getLjekar(response.nadlezniLjekarId);
           this.getPacijent(response.pacijentId);
           
            this.myForm.reset();
            this.prikazi = false;
          },
          error: (error: any) => {
            console.error('Greška pri ažuriranju podataka o prijemu:', error);
          }
        });
      } else {
        console.error('Nije moguće pristupiti kontrolama forme.');
      }
    } else {
      console.error('Neispravni podaci za ažuriranje prijema.');
    }
}

openModalObrisi(admissionId: any) {
  this.admissionToDeleteId = admissionId;
  console.log(this.admissionToDeleteId);
  this.brisanje = true;

  console.log("Open modal for brisanje method called");
}

closeModalObrisi() {
  console.log("close modal for delete method called");
  this.brisanje = false;
}
btnObrisi(): void {
  console.log("brisanje pozvano");
  if (this.admissionToDeleteId) {
    const headers = MojConfig.http_opcije();

    this.http.delete(MojConfig.adresa_servera + '/PrijemPacijenta/' + this.admissionToDeleteId,headers).subscribe({
      next: (x: any) => {
        this.openSnackBar('Uspješno ste obrisali prijem!', 'Zatvori');

        this.ucitajLjekare();
        console.log('Doktor uspješno obrisan:', x);

        this.getPrijemPacijenta();

        this.brisanje = false;
        this.myForm.reset();
      },
      error: (x: any) => {
        console.error('Greška pri brisanju doktora:', x);
        this.openSnackBar('Prijem nije obrisan', 'Zatvori');
      }
    });
  }
}

}


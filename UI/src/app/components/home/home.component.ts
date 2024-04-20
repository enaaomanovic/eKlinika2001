import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MojConfig } from 'src/app/moj-config';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loginForm: FormGroup;
  prikazi: boolean = false;

  constructor(private router: Router, private http: HttpClient, private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      lozinka: ['', Validators.required]
    });
  }

  btnLogin() {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username')?.value;
      const password = this.loginForm.get('lozinka')?.value;
     
      MojConfig.postaviKorisnika(username, password);
  
      const headers = MojConfig.http_opcije(); 
  
      this.http.get<any>('https://localhost:59904/Ljekar', headers)
        .subscribe({
          next: (data) => {
            console.log('Uspješno logiranje', data);
            this.router.navigate(['/login-home']);
          },
          error: (error) => {
            console.error('Greška prilikom logiranja', error);
          }
        });
    }
  }

  login(username: string, password: string): void {
    // Logika za provjeru korisničkih podataka
    // Nakon uspješnog prijavljivanja
    MojConfig.postaviKorisnika(username, password);
  }
  
  ngOnInit(): void {
    this.prikazi = false;
  }

  openModal() {
    this.prikazi = true;
  }

  closeModal() {
    this.prikazi = false;
  }
}

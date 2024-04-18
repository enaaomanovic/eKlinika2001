import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Dodajte sljedeće Angular Material module
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { LoginHomeComponent } from './components/login-home/login-home.component';
import { LogNavComponent } from './components/log-nav/log-nav.component';
import { NewPatientComponent } from './components/new-patient/new-patient.component';
import { NewDoctorComponent } from './components/new-doctor/new-doctor.component';
import { NewAdmissionComponent } from './components/new-admission/new-admission.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    LoginHomeComponent,
    LogNavComponent,
    NewPatientComponent,
    NewDoctorComponent,
    NewAdmissionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule, // Dodajte MatToolbarModule
    MatButtonModule // Dodajte MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

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
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { PdfComponent } from './pdf/pdf.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { UnauthorizedInterceptor } from './unauthorized.interceptor';


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
    NewAdmissionComponent,
    PdfComponent,

 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule, 
    MatButtonModule, 
    HttpClientModule,
    FormsModule ,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    DropDownListModule,
     ButtonModule,
     MatSnackBarModule,
  
  

  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UnauthorizedInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

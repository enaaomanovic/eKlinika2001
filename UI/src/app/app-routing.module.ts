import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component'; 
import { LoginHomeComponent } from './components/login-home/login-home.component';
import { getLocaleFirstDayOfWeek } from '@angular/common';
import { LogNavComponent } from './components/log-nav/log-nav.component';
import { NewPatientComponent } from './components/new-patient/new-patient.component';
import { NewDoctorComponent } from './components/new-doctor/new-doctor.component';
import { NewAdmissionComponent } from './components/new-admission/new-admission.component';
const routes: Routes = [
  { path: '', component: HomeComponent } ,
  { path: 'login-home', component: LoginHomeComponent } ,
  { path: 'login-home', component: LoginHomeComponent } ,
  { path: 'log-nav', component: LogNavComponent } ,
  { path: 'new-patient', component: NewPatientComponent } ,
  { path: 'new-doctor', component: NewDoctorComponent } ,
  { path: 'new-admission', component: NewAdmissionComponent } ,







];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-patient',
  templateUrl: './new-patient.component.html',
  styleUrls: ['./new-patient.component.css']
})
export class NewPatientComponent implements OnInit {

  prikazi: boolean = false;

  constructor(private router: Router) {}
  ngOnInit(): void {
   this.prikazi=false;
  }

  openModal() {
    console.log("Open modal method called");
    this.prikazi = true;
  }

  closeModal() {
    console.log("close modal method called");
    this.prikazi = false;
  }

 

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-doctor',
  templateUrl: './new-doctor.component.html',
  styleUrls: ['./new-doctor.component.css']
})
export class NewDoctorComponent implements OnInit {

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

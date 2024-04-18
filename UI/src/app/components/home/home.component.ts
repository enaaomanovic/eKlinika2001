import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

login() {
throw new Error('Method not implemented.');
}

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

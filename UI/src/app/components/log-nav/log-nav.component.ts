import { Component, OnInit } from '@angular/core';
import { MojConfig } from 'src/app/moj-config';

@Component({
  selector: 'app-log-nav',
  templateUrl: './log-nav.component.html',
  styleUrls: ['./log-nav.component.css']
})
export class LogNavComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  logout(): void {
    MojConfig.odlogujKorisnika();
  }
}

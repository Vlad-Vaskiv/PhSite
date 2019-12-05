import { Component, OnInit, Input } from '@angular/core';
import { Phone } from 'src/app/_models/phone';

@Component({
  selector: 'app-phone-cont',
  templateUrl: './phone-cont.component.html',
  styleUrls: ['./phone-cont.component.css']
})
export class PhoneContComponent implements OnInit {
@Input() phone: Phone;
  constructor() { }

  ngOnInit() {
  }

}

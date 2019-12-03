import { Component, OnInit, Input } from '@angular/core';
import { Firm } from 'src/app/_models/firm';

@Component({
  selector: 'app-firm-cont',
  templateUrl: './firm-cont.component.html',
  styleUrls: ['./firm-cont.component.css']
})
export class FirmContComponent implements OnInit {
@Input() firm: Firm;
  constructor() { }

  ngOnInit() {
  }

}

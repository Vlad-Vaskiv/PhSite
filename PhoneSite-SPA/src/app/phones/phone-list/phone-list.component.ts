import { Component, OnInit } from '@angular/core';
import { Phone } from 'src/app/_models/phone';
import { PhoneService } from 'src/app/_services/phone.service';

@Component({
  selector: 'app-phone-list',
  templateUrl: './phone-list.component.html',
  styleUrls: ['./phone-list.component.css']
})
export class PhoneListComponent implements OnInit {

  phones: Phone[];
  constructor(private phoneService: PhoneService) { }

  ngOnInit() {
    this.loadPhones();
  }

  loadPhones() {
    this.phoneService.getPhones().subscribe((phones: Phone[]) => {
      this.phones = phones;
    }, error => {
      console.log(error);
    });
  }
}

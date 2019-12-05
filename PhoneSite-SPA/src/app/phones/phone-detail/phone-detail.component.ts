import { Component, OnInit } from '@angular/core';
import { Phone } from 'src/app/_models/phone';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PhoneService } from 'src/app/_services/phone.service';

@Component({
  selector: 'app-phone-detail',
  templateUrl: './phone-detail.component.html',
  styleUrls: ['./phone-detail.component.css']
})
export class PhoneDetailComponent implements OnInit {

  phone: Phone;
  constructor(private phoneService: PhoneService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadPhone();
  }

  loadPhone() {
    this.phoneService.getPhone(+this.route.snapshot.params['id'])
        .subscribe((phone: Phone) => {
          this.phone = phone;
        }, error => {
          this.alertify.error(error);
        }); // + конвертит в number из string
  }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FirmServiceService } from 'src/app/_services/firm-service.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Firm } from 'src/app/_models/firm';
import { PhoneService } from 'src/app/_services/phone.service';
import { Phone } from 'src/app/_models/phone';

@Component({
  selector: 'app-firm-detail',
  templateUrl: './firm-detail.component.html',
  styleUrls: ['./firm-detail.component.css']
})
export class FirmDetailComponent implements OnInit {
  firm: Firm;
  phones: Phone[];

  // tslint:disable-next-line:max-line-length
  constructor(private firmService: FirmServiceService, private phoneService: PhoneService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadPhones();
  }

  loadFirm() {
    this.firmService.getFirm(+this.route.snapshot.params['id'])
        .subscribe((firm: Firm) => {
          this.firm = firm;
        }, error => {
          this.alertify.error(error);
        }); // + конвертит в number из string
  }

  loadPhones() {
    this.phoneService.getPhones().subscribe((phones: Phone[]) => {
      this.phones = phones;
    }, error => {
      console.log(error);
    });
  }
}

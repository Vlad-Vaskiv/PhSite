import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FirmServiceService } from 'src/app/_services/firm-service.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Firm } from 'src/app/_models/firm';

@Component({
  selector: 'app-firm-detail',
  templateUrl: './firm-detail.component.html',
  styleUrls: ['./firm-detail.component.css']
})
export class FirmDetailComponent implements OnInit {
  firm: Firm;

  constructor(private firmService: FirmServiceService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadFirm();
  }

  loadFirm() {
    this.firmService.getFirm(+this.route.snapshot.params['id'])
        .subscribe((firm: Firm) => {
          this.firm = firm;
        }, error => {
          this.alertify.error(error);
        }); // + конвертит в number из string
  }
}

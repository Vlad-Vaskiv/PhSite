import { Component, OnInit } from '@angular/core';
import {Firm} from '../../_models/firm';
import {FirmServiceService} from '../../_services/firm-service.service';

@Component({
  selector: 'app-firm-list',
  templateUrl: './firm-list.component.html',
  styleUrls: ['./firm-list.component.css']
})
export class FirmListComponent implements OnInit {

  firms: Firm[];
  constructor(private firmService: FirmServiceService) { }

  ngOnInit() {
    this.loadFirms();
  }
  loadFirms() {
    this.firmService.getFirms().subscribe((firms: Firm[]) => {
      this.firms = firms;
    }, error => {
      console.log(error);
    });
  }
}

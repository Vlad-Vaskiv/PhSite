import { Component, OnInit } from '@angular/core';
import { Phone } from 'src/app/_models/phone';
import { PhoneService } from 'src/app/_services/phone.service';
import { PaginatedResult, Pagination } from 'src/app/_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PageChangedEvent } from 'ngx-bootstrap';

@Component({
  selector: 'app-phone-list',
  templateUrl: './phone-list.component.html',
  styleUrls: ['./phone-list.component.css']
})
export class PhoneListComponent implements OnInit {

  phones: Phone[];
  pagination: Pagination;
  constructor(private phoneService: PhoneService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    // this.loadPhones();
    this.route.data.subscribe(data => {
      this.phones = data['phones'].result;
      this.pagination = data['phones'].pagination;
    });
  }

  pageChanged(event: PageChangedEvent): void {
    this.pagination.currentPage = event.page;
    this.loadPhones();
  }

  loadPhones() {
    this.phoneService.getPhones(this.pagination.currentPage, this.pagination.itemsPerPage)
      .subscribe((res: PaginatedResult<Phone[]>) => {
        this.phones = res.result;
        this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }
}

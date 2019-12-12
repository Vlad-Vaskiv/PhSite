import {Injectable} from '@angular/core';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PhoneService } from 'src/app/_services/phone.service';
import { Phone } from 'src/app/_models/phone';
import { AlertifyService } from 'src/app/_services/alertify.service';


@Injectable()
export class PhoneListResolver implements Resolve<Phone[]> {
    pageNumber = 1;
    pageSize = 2;

    constructor(private phoneService: PhoneService, private router: Router,
        private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Phone[]> {
        return this.phoneService.getPhones(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}

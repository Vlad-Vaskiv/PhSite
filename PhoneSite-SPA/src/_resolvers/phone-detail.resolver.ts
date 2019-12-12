import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Phone } from 'src/app/_models/phone';
import { PhoneService } from 'src/app/_services/phone.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Injectable()
export class PhoneDetailResolver implements Resolve<Phone> {
    constructor(private phoneService: PhoneService, private router: Router, private alerify: AlertifyService) { }
    resolve(route: ActivatedRouteSnapshot):  Observable<Phone> {
      return this.phoneService.getPhone(route.params['id']).pipe(
        catchError(error => {
          this.alerify.error('Проблемы с получением данных');
          this.router.navigate(['/posters']);
          return of(null);
        })
      );
        // Когда мы используем resolver мы выходим из posterService ->
        // получаем poster, который совпадает c route parametr(там наша id), который мы стремимся получить ->
        // все остально это ловим ошибки
    }
}

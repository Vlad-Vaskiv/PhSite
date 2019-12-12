import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Phone } from '../_models/phone';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class PhoneService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  getPhones(page?, itemsPerPage?): Observable<PaginatedResult<Phone[]>> {
    const paginatedResult: PaginatedResult<Phone[]> = new PaginatedResult<Phone[]>();

    let params  = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params =  params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }
    return this.http.get<Phone[]>(this.baseUrl + 'phones', {observe: 'response', params })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
            return paginatedResult;
        })
      );
  }

  getPhone(id): Observable<Phone> {
    return this.http.get<Phone>(this.baseUrl + 'phones/' + id, httpOptions);
  }

  upload(formData) {
    return this.http.request('https://localhost:5000/api/posters', formData, {reportProgress: true, observe: 'events'});
  }
}

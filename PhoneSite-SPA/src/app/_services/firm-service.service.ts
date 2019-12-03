import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Firm } from '../_models/firm';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token')
  })
};
@Injectable({
  providedIn: 'root'
})
export class FirmServiceService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }
  getFirms(): Observable<Firm[]> {
    return this.http.get<Firm[]>(this.baseUrl + 'firms', httpOptions);
  }
  getFirm(id): Observable<Firm> {
    return this.http.get<Firm>(this.baseUrl + 'firms/' + id, httpOptions);
  }

}

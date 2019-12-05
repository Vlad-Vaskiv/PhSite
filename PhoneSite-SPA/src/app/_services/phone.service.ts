import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Phone } from '../_models/phone';


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
  getPhones(): Observable<Phone[]> {
    return this.http.get<Phone[]>(this.baseUrl + 'phones', httpOptions);
  }
  getPhone(id): Observable<Phone> {
    return this.http.get<Phone>(this.baseUrl + 'phones/' + id, httpOptions);
  }
}

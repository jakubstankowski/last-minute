import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Offers} from './offers';
import {Observable, of} from 'rxjs';
import {environment} from '../../environments/environment';
import {catchError, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HolidayOffersService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getOffers(): Observable<Offers[]>{
    return this.http.get<Offers[]>(this.baseUrl + 'offers');
  }
}

import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IOffers} from '../shared/models/offers';

@Injectable({
    providedIn: 'root'
})

export class HolidayOffersService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getOffers(): Observable<IOffers[]> {
        return this.http.get<IOffers[]>(this.baseUrl + 'offers');
    }
}

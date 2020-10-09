import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Offers} from '../../shared/models/offers';
import {Observable} from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class HolidayOffersService {
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {
    }

    getOffers(): Observable<Offers[]> {
        return this.http.get<Offers[]>(this.baseUrl + 'offers');
    }

}

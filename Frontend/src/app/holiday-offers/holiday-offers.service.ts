import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IOffers} from '../shared/models/offers';
import {OffersParams} from "../shared/models/offersParams";

@Injectable({
    providedIn: 'root'
})

export class HolidayOffersService {
    baseUrl = environment.apiUrl;
    offersParams = new OffersParams();

    constructor(private http: HttpClient) {
        const params = this.getOffersParams();
        params.sort = 'priceAsc';
        this.setOffersParams(params);
    }

    getOffers(): Observable<IOffers[]> {
        let params = new HttpParams();

        if (this.offersParams.sort) {
            params = params.append('sort', this.offersParams.sort);
        }

        return this.http.get<IOffers[]>(this.baseUrl + 'offers', {params});
    }

    setOffersParams(params: OffersParams) {
        this.offersParams = params;
    }

    getOffersParams() {
        return this.offersParams;
    }

}

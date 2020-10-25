import {Component, OnDestroy, OnInit} from '@angular/core';
import {IOffers} from '../../shared/models/offers';
import {HolidayOffersService} from '../holiday-offers.service';

@Component({
    selector: 'app-holiday-offers-list',
    templateUrl: './holiday-offers-list.component.html',
    styleUrls: ['./holiday-offers-list.component.css']
})
export class HolidayOffersListComponent implements OnInit, OnDestroy {
    offers: IOffers[];
    loading: boolean;

    constructor(private holidayOffersService: HolidayOffersService) {
    }

    ngOnInit() {
        this.getOffers();
    }

    ngOnDestroy() {

    }

    getOffers(): void {
        this.loading = true;
        this.holidayOffersService.getOffers()
            .subscribe(
                (offers: IOffers[]) => {
                    this.offers = offers;
                    this.loading = false;
                    console.log('offers: ', this.offers);
                },
                (err) => console.error(err),
                () => console.log('observable complete'));
    }

}

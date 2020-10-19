import {Component, OnInit} from '@angular/core';
import {IOffers} from '../../shared/models/offers';
import {HolidayOffersService} from '../holiday-offers.service';

@Component({
    selector: 'app-holiday-offers-list',
    templateUrl: './holiday-offers-list.component.html',
    styleUrls: ['./holiday-offers-list.component.css']
})
export class HolidayOffersListComponent implements OnInit {
    offers: IOffers[];
    loading: boolean;

    constructor(private holidayOffersService: HolidayOffersService) {
    }

    ngOnInit() {
        this.reloadOffers();
    }

    getOffers(): void {
        this.loading = true;
        this.holidayOffersService.getOffers()
            .subscribe(offer => {
                this.loading = false;
                this.offers = offer;
            });
    }

    reloadOffers(): void {
        this.loading = true;
        this.holidayOffersService.reloadOffers()
            .subscribe(
                (response) => {
                    this.loading = false;
                    this.getOffers();
                },
                (err) => console.error(err),
                () => console.log('observable complete')
            );
    }

}

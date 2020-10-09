import {Component, OnInit} from '@angular/core';
import {IOffers} from '../../shared/models/offers';
import {HolidayOffersService} from '../../core/services/holiday-offers.service';

@Component({
    selector: 'app-holiday-offers-list',
    templateUrl: './holiday-offers-list.component.html',
    styleUrls: ['./holiday-offers-list.component.css']
})
export class HolidayOffersListComponent implements OnInit {
    offers: IOffers[];

    constructor(private holidayOffers: HolidayOffersService) {
    }

    ngOnInit() {
        this.getOffers();
    }

    getOffers(): void {
        this.holidayOffers.getOffers()
            .subscribe(offer => this.offers = offer);
    }

}

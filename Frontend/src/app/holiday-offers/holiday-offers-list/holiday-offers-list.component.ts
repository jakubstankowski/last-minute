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
        this.getOffers();
    }

    getOffers(): void {
        this.loading = true;
        this.holidayOffersService.getOffers()
            .subscribe(
                (response) => {
                    console.log('response: ', response);
                },
                (err) => console.error(err),
                () => console.log('observable complete'));
    }

}

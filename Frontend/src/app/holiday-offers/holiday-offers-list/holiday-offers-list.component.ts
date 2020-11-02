import {Component, OnDestroy, OnInit} from '@angular/core';
import {IOffers} from '../../shared/models/offers';
import {HolidayOffersService} from '../holiday-offers.service';
import {IPreferences} from "../../shared/models/preferences";
import {HolidayPreferencesService} from "../../holiday-preferences/holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";

@Component({
    selector: 'app-holiday-offers-list',
    templateUrl: './holiday-offers-list.component.html',
    styleUrls: ['./holiday-offers-list.component.css']
})
export class HolidayOffersListComponent implements OnInit, OnDestroy {
    offers: IOffers[];
    preferences: IPreferences
    loading: boolean;

    constructor(private holidayOffersService: HolidayOffersService, private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService) {
    }

    ngOnInit() {
        this.loading = true;
        this.getOffers();
        this.getHolidayPreferences();
    }

    ngOnDestroy() {

    }

    private getOffers(): void {
        this.holidayOffersService.getOffers()
            .subscribe(
                (offers: IOffers[]) => {
                    this.offers = offers;
                    this.loading = false;
                },
                error => {
                    this.notificationService.openSnackBar(error.error.message);
                    throw new Error(error);
                })
    }

    private getHolidayPreferences(): void {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(preferences => {
                    this.preferences = preferences;
                },
                error => {
                    this.notificationService.openSnackBar(error.error.message);
                    throw new Error(error);
                })
    }
}

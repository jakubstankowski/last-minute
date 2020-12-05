import {Component, OnDestroy, OnInit} from '@angular/core';
import {IOffers} from '../../shared/models/offers';
import {HolidayOffersService} from '../holiday-offers.service';
import {IPreferences} from "../../shared/models/preferences";
import {HolidayPreferencesService} from "../../holiday-preferences/holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";
import {MatDialog} from "@angular/material/dialog";
import {HolidayPreferencesDialogComponent} from "../../holiday-preferences/holiday-preferences-dialog/holiday-preferences-dialog.component";
import {OffersParams} from "../../shared/models/offersParams";

@Component({
    selector: 'app-holiday-offers-list',
    templateUrl: './holiday-offers-list.component.html',
    styleUrls: ['./holiday-offers-list.component.css']
})
export class HolidayOffersListComponent implements OnInit {
    offers: IOffers[];
    preferences?: IPreferences
    loading: boolean;
    offersParams: OffersParams;
    sortOptions = [
        {name: 'Price: Low to High', value: 'priceAsc'},
        {name: 'Price: High to Low', value: 'priceDesc'}
    ];

    constructor(private holidayOffersService: HolidayOffersService, private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService, public dialog: MatDialog) {
        this.offersParams = this.holidayOffersService.getOffersParams();
    }

    ngOnInit() {
        this.loading = true;
        this.getHolidayPreferences();
    }

    private getHolidayPreferences(): void {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(preferences => {
                    this.preferences = preferences;
                    this.getOffers();
                },
                error => {
                    this.notificationService.openSnackBar(error.error.message);
                    throw new Error(error);
                });
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


    openPreferencesDialog() {
        const dialogRef = this.dialog.open(HolidayPreferencesDialogComponent, {
            panelClass: 'custom-modalbox',
            data: {mode: 'edit'}
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                this.loading = true;
                //this.getHolidayPreferences();
            }

        });
    }

    onSortSelected(event) {
        const sort = event.target.value;
        const params = this.holidayOffersService.getOffersParams();
        params.sort = sort;
        this.holidayOffersService.setOffersParams(params);
        this.getOffers();
    }
}

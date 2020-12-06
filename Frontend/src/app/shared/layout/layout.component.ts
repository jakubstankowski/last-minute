import {Component, OnInit, ChangeDetectorRef, AfterViewInit} from '@angular/core';
import {MediaMatcher} from '@angular/cdk/layout';
import {Observable} from 'rxjs';
import {AuthenticationService} from '../../core/services/auth.service';
import {SpinnerService} from '../../core/services/spinner.service';
import {AuthGuard} from 'src/app/core/guards/auth.guard';
import {IUser} from '../models/user';
import {HolidayPreferencesService} from "../../holiday-preferences/holiday-preferences.service";
import {NotificationService} from "../../core/services/notification.service";
import {MatDialog} from "@angular/material/dialog";
import {HolidayPreferencesDialogComponent} from "../../holiday-preferences/holiday-preferences-dialog/holiday-preferences-dialog.component";
import {Router} from "@angular/router";


@Component({
    selector: 'app-layout',
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.css']
})


export class LayoutComponent implements OnInit, AfterViewInit {
    _mobileQueryListener: () => void;
    mobileQuery: MediaQueryList;
    currentUser$: Observable<IUser>;
    loading: boolean;

    constructor(private changeDetectorRef: ChangeDetectorRef,
                private media: MediaMatcher,
                public spinnerService: SpinnerService,
                private authService: AuthenticationService,
                private authGuard: AuthGuard,
                private holidayPreferencesService: HolidayPreferencesService,
                private notificationService: NotificationService,
                public dialog: MatDialog,
                private router: Router
    ) {

        this.mobileQuery = this.media.matchMedia('(max-width: 1000px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        this.mobileQuery.addListener(this._mobileQueryListener);
    }

    ngOnInit(): void {
        this.loading = true;
        this.getPreference();
        this.currentUser$ = this.authService.currentUser$;
    }


    ngAfterViewInit(): void {
        this.changeDetectorRef.detectChanges();
    }

    logout() {
        this.authService.logout();
    }


    getPreference() {
        this.holidayPreferencesService.getHolidayPreference()
            .subscribe(
                preference => {
                    if (!preference) {
                        this.router.navigate(['/holiday-preferences/create']);
                    }

                    this.loading = false;
                },
                error => {
                    this.notificationService.openSnackBar(error.error.message);
                    throw new Error(error);
                });
    }

}


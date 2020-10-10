import {Component, OnInit, ChangeDetectorRef, OnDestroy, AfterViewInit} from '@angular/core';
import {MediaMatcher} from '@angular/cdk/layout';
import {TimerObservable} from 'rxjs/observable/TimerObservable';
import {Observable, Subscription} from 'rxjs';

import {environment} from './../../../environments/environment';
import {AuthenticationService} from './../../core/services/auth.service';
import {SpinnerService} from '../../core/services/spinner.service';
import {AuthGuard} from 'src/app/core/guards/auth.guard';
import {IUser} from '../models/user';

@Component({
    selector: 'app-layout',
    templateUrl: './layout.component.html',
    styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit,  AfterViewInit {

    private _mobileQueryListener: () => void;
    mobileQuery: MediaQueryList;
    showSpinner: boolean;
    userName: string;
    isAdmin: boolean;
    currentUser$: Observable<IUser>;

    private autoLogoutSubscription: Subscription;

    constructor(private changeDetectorRef: ChangeDetectorRef,
                private media: MediaMatcher,
                public spinnerService: SpinnerService,
                private authService: AuthenticationService,
                private authGuard: AuthGuard) {

        this.mobileQuery = this.media.matchMedia('(max-width: 1000px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        // tslint:disable-next-line: deprecation
        this.mobileQuery.addListener(this._mobileQueryListener);
    }

    ngOnInit(): void {
        //this.loadCurrentUser();
        this.currentUser$ = this.authService.currentUser$;
    }


    ngAfterViewInit(): void {
        this.changeDetectorRef.detectChanges();
    }

    loadCurrentUser() {
        alert('load from layout');
        const token = localStorage.getItem('token');
        this.authService.loadCurrentUser(token).subscribe(() => {
            console.log('loaded user');
        }, error => {
            console.log(error);
        });
    }

    logout() {
        this.authService.logout();
    }
}

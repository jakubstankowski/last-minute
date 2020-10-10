import {Injectable, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';
import * as moment from 'moment';
import 'rxjs/add/operator/delay';

import {environment} from '../../../environments/environment';
import {of, EMPTY, ReplaySubject} from 'rxjs';
import {IUser} from '../../shared/models/user';
import {Router} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    baseUrl = environment.apiUrl;
    private currentUserSource = new ReplaySubject<IUser>(1);
    currentUser$ = this.currentUserSource.asObservable();

    constructor(private http: HttpClient,
                @Inject('LOCALSTORAGE') private localStorage: Storage, private router: Router) {
    }

    login(values: any) {
        return this.http.post(this.baseUrl + 'auth/login', values).pipe(
            map((user: IUser) => {
                if (user) {
                    console.log('user', user);
                    this.localStorage.setItem('token', user.token);
                    this.currentUserSource.next(user);
                }
            })
        );
    }

    register(values: any) {
        return this.http.post(this.baseUrl + 'auth/register', values).pipe(
            map((user: IUser) => {
                if (user) {
                    this.localStorage.setItem('token', user.token);
                    this.currentUserSource.next(user);
                }
            })
        );
    }

    logout() {
        this.localStorage.removeItem('token');
        this.currentUserSource.next(null);
        this.router.navigateByUrl('/auth/login');
    }

    getCurrentUser(): any {
        // TODO: Enable after implementation
        // return JSON.parse(this.localStorage.getItem('currentUser'));
        return {
            token: 'aisdnaksjdn,axmnczm',
            isAdmin: true,
            email: 'john.doe@gmail.com',
            id: '12312323232',
            alias: 'john.doe@gmail.com'.split('@')[0],
            expiration: moment().add(1, 'days').toDate(),
            fullName: 'John Doe'
        };
    }
}

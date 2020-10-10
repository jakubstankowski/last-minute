import {Injectable, Inject} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {map} from 'rxjs/operators';
import * as moment from 'moment';
import 'rxjs/add/operator/delay';

import {environment} from '../../../environments/environment';
import {of, EMPTY, ReplaySubject, BehaviorSubject} from 'rxjs';
import {IUser} from '../../shared/models/user';
import {Router} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    baseUrl = environment.apiUrl;
    private currentUserSource = new BehaviorSubject<IUser>(null);
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

    loadCurrentUser(token: string) {
        if (token === null) {
            this.currentUserSource.next(null);
            return of(null);
        }

        let headers = new HttpHeaders();
        headers = headers.set('Authorization', `Bearer ${token}`);

        return this.http.get(this.baseUrl + 'account', {headers}).pipe(
            map((user: IUser) => {
                if (user) {
                    localStorage.setItem('token', user.token);
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


}

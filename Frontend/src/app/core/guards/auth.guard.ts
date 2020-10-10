import {Injectable} from '@angular/core';
import {CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router} from '@angular/router';
import {Observable} from 'rxjs';
import {map, take} from 'rxjs/operators';
import {AuthenticationService} from '../services/auth.service';

@Injectable({
    providedIn: 'root'
})

export class AuthGuard implements CanActivate {
    constructor(private authService: AuthenticationService, private router: Router) {
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> {
        return this.authService.currentUser$.pipe(
            take(1),
            map(auth => {
                console.log('auth: ', auth);
                const isAuth = !!auth;
                console.log('is auth? ', isAuth);
                if (isAuth) {
                    return true;
                }
                this.router.navigate(['auth/login']);
            }));
    }
}

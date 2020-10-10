import { Injectable } from '@angular/core';
import {Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot} from '@angular/router';
import { AuthenticationService } from '../services/auth.service';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';

@Injectable()
export class AdminGuard implements CanActivate {
    constructor(private authService: AuthenticationService, private router: Router) {
    }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> {
        return this.authService.currentUser$.pipe(
            map(auth => {
                if (auth) {
                    return true;
                }
                this.router.navigate(['auth/login']);
            }));
    }
}

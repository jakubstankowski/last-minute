import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import {AuthGuard} from './core/guards/auth.guard';
import {HolidayPreferencesCreateComponent} from "./holiday-preferences/holiday-preferences-create/holiday-preferences-create.component";

const appRoutes: Routes = [
    {
        path: 'auth',
        loadChildren: './auth/auth.module#AuthModule'
    },
    {
        path: 'holiday-offers',
        loadChildren: './holiday-offers/holiday-offers.module#HolidayOffersModule',
        canActivate: [AuthGuard]
    },
    {
        path: 'holiday-preferences/create',
        component: HolidayPreferencesCreateComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'users',
        loadChildren: './users/users.module#UsersModule',
        canActivate: [AuthGuard]
    },
    {
        path: 'account',
        loadChildren: './account/account.module#AccountModule',
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        redirectTo: 'holiday-offers',
        pathMatch: 'full',
        canActivate: [AuthGuard]
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule],
    providers: []
})
export class AppRoutingModule {
}

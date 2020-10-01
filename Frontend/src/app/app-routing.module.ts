import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HolidayOffersComponent} from './holiday-offers/holiday-offers.component';

const routes: Routes = [{
  path: '',
  component: HolidayOffersComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

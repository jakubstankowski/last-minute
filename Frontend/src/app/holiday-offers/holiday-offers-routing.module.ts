import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../shared/layout/layout.component';
import {HolidayOffersListComponent} from './holiday-offers-list/holiday-offers-list.component';


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', component: HolidayOffersListComponent },
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class HolidayOffersRoutingModule { }

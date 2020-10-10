import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../shared/layout/layout.component';
import {HolidayPreferencesListComponent} from './holiday-preferences-list/holiday-preferences-list.component';


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', component: HolidayPreferencesListComponent },
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class HolidayPreferencesRoutingModule { }

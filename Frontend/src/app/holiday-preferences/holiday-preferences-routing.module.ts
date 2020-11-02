import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../shared/layout/layout.component';
import {HolidayPreferencesComponent} from "./holiday-preferences/holiday-preferences.component";


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: ':mode', component: HolidayPreferencesComponent },
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class HolidayPreferencesRoutingModule { }

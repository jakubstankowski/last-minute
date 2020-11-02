import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LayoutComponent} from '../shared/layout/layout.component';
import {HolidayPreferencesListComponent} from './holiday-preferences-list/holiday-preferences-list.component';
import {HolidayPreferencesEditComponent} from './holiday-preferences-edit/holiday-preferences-edit.component';
import {HolidayPreferencesCreateComponent} from "./holiday-preferences-create/holiday-preferences-create.component";
import {HolidayPreferencesComponent} from "./holiday-preferences/holiday-preferences.component";


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', component: HolidayPreferencesListComponent },
      { path: 'edit', component: HolidayPreferencesEditComponent },
      { path: 'create', component: HolidayPreferencesCreateComponent },
      { path: ':mode', component: HolidayPreferencesComponent },
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})


export class HolidayPreferencesRoutingModule { }

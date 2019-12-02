import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PhoneListComponent } from './phone-list/phone-list.component';

export const appRoutes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'phones', component: PhoneListComponent},
 // {path: '**', redirectTo: 'home', pathMatch: 'full '}
];

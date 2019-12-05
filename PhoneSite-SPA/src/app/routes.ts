import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FirmListComponent } from './firms/firm-list/firm-list.component';
import {FirmDetailComponent} from './firms/firm-detail/firm-detail.component';
import { PhoneDetailComponent } from './phones/phone-detail/phone-detail.component';
import { PhoneListComponent } from './phones/phone-list/phone-list.component';

export const appRoutes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'firms', component: FirmListComponent},
  {path: 'firms/:id', component: FirmDetailComponent},
  {path: 'phones', component: PhoneListComponent},
  {path: 'phones/:id', component: PhoneDetailComponent},
 // {path: '**', redirectTo: 'home', pathMatch: 'full '}
];

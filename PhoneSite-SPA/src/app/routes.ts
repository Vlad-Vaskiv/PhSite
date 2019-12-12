import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FirmListComponent } from './firms/firm-list/firm-list.component';
import {FirmDetailComponent} from './firms/firm-detail/firm-detail.component';
import { PhoneDetailComponent } from './phones/phone-detail/phone-detail.component';
import { PhoneListComponent } from './phones/phone-list/phone-list.component';
import { PhoneListResolver } from 'src/_resolvers/phone-list.resolver';
import { AuthGuard } from './_guards/auth.guard';
import { PhoneDetailResolver } from 'src/_resolvers/phone-detail.resolver';

export const appRoutes: Routes = [
  {path: 'home', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'firms', component: FirmListComponent},
      {path: 'firms/:id', component: FirmDetailComponent},
      {path: 'phones', component: PhoneListComponent, resolve: {phones: PhoneListResolver}},
      {path: 'phones/:id', component: PhoneDetailComponent, resolve: {phone: PhoneDetailResolver}},
    ],
  },
  {path: '**', redirectTo: 'home', pathMatch: 'prefix'}
];

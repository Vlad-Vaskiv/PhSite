import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule, PaginationModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { HttpClient } from 'selenium-webdriver/http';

import {AccountService} from './_services/account.service';
import { from } from 'rxjs';
import { ErrorInterceptor, ErrorInterceptorProvider } from './_services/error.interceptor';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AlertifyService } from './_services/alertify.service';
import { FirmListComponent } from './firms/firm-list/firm-list.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { FirmServiceService } from './_services/firm-service.service';
import { FirmContComponent } from './firms/firm-cont/firm-cont.component';
import { FirmDetailComponent } from './firms/firm-detail/firm-detail.component';
import { PhoneDetailComponent } from './phones/phone-detail/phone-detail.component';
import { PhoneListComponent } from './phones/phone-list/phone-list.component';
import { PhoneContComponent } from './phones/phone-cont/phone-cont.component';
import { PhoneService } from './_services/phone.service';
import { PhoneDetailResolver } from 'src/_resolvers/phone-detail.resolver';
import { PhoneListResolver } from 'src/_resolvers/phone-list.resolver';
import { JwtHelperService } from '@auth0/angular-jwt';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      FirmListComponent,
      FirmContComponent,
      FirmDetailComponent,
      PhoneContComponent,
      PhoneDetailComponent,
      PhoneListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      PaginationModule.forRoot()
   ],
   providers: [
      AccountService,
      ErrorInterceptorProvider,
      AlertifyService,
      FirmServiceService,
      PhoneService,
      PhoneListResolver,
      PhoneDetailResolver,
      JwtHelperService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';

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


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      FirmListComponent,
      FirmContComponent,
      FirmDetailComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AccountService,
      ErrorInterceptorProvider,
      AlertifyService,
      FirmServiceService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

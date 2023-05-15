import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeroesListComponent } from './heroes-list/heroes-list.component';
import { SecretPipe } from './heroes-list/secret/secret.pipe';
import { FistComponent } from './fist/fist.component';
import { HeroDetailsComponent } from './hero-details/hero-details.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HeroEditComponent } from './hero-edit/hero-edit.component';
import { ReservationsListComponent } from './reservations-list/reservations-list.component';
import { ReservationDetailsComponent } from './reservation-details/reservation-details.component';
import { ReservationEditComponent } from './reservation-edit/reservation-edit.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { AuthInterceptorService } from './shared/services/auth-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    HeroesListComponent,
    SecretPipe,
    FistComponent,
    HeroDetailsComponent,
    HomeComponent,
    NavMenuComponent,
    HeroEditComponent,
    ReservationsListComponent,
    ReservationDetailsComponent,
    ReservationEditComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,  
    AuthenticationModule,
    RouterModule.forRoot([
      { path: 'heroEdit/:id', component: HeroEditComponent},
      { path: 'heroEdit', component: HeroEditComponent},
      { path: 'heroes/:id', component: HeroDetailsComponent },
      { path: 'reservations', component: ReservationsListComponent },
      { path: 'reservations/:id', component: ReservationDetailsComponent },
      { path: 'reservationEdit/:id', component: ReservationEditComponent },
      { path: 'reservationEdit', component: ReservationEditComponent },
      {
        path: 'heroes',
        component: HeroesListComponent,
      },
      { path: 'home', component: HomeComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' },
    ]),
  ],
  providers: [
    {    provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

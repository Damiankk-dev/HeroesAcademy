import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { HeroesListComponent } from './heroes-list/heroes-list.component';
import { SecretPipe } from './heroes-list/secret/secret.pipe';
import { FistComponent } from './fist/fist.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { HeroEditComponent } from './hero-edit/hero-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    HeroesListComponent, SecretPipe, FistComponent, HeroDetailComponent, HeroEditComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'heroEdit', component: HeroEditComponent},
      { path: 'heroes/:id', component: HeroDetailComponent },
      { path: 'heroes', component: HeroesListComponent },
      { path: 'home', component: HomeComponent},
      { path: '', redirectTo:'home', pathMatch: 'full' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgParticlesModule } from "ng-particles";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
// import { ClientUIComponent } from './client-ui/client-ui.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login-component';
import { SearchComponent } from './search/search.component';
import { FetchConsensusUniprotComponent } from './fetch-consensus-uniprot/fetch-consensus-uniprot.component';
import { FilterPipe } from './shared/filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    SearchComponent,
    FetchConsensusUniprotComponent,
    FilterPipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgParticlesModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'fetch-consensus-uniprot', component: FetchConsensusUniprotComponent },
      { path: 'Login', component: LoginComponent }, // added component
      { path: 'search', component: SearchComponent } // added component
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
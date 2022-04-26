import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgParticlesModule } from "ng-particles";
import { MatSliderModule } from '@angular/material/slider';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';





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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FancyCardComponent } from './fancy-card/fancy-card.component';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatIconModule} from '@angular/material/icon';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatRadioModule} from '@angular/material/radio';
import { InfoCardComponent } from './info-card/info-card.component';



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
    FancyCardComponent,
    InfoCardComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgParticlesModule,
    MatSliderModule,
    MatCardModule,
    MatButtonModule,
    MatPaginatorModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MatProgressBarModule,
    MatButtonToggleModule,
    MatIconModule,
    MatCheckboxModule,
    MatRadioModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'fetch-consensus-uniprot', component: FetchConsensusUniprotComponent },
      { path: 'Login', component: LoginComponent }, // added component
      { path: 'search', component: SearchComponent } // added component
    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

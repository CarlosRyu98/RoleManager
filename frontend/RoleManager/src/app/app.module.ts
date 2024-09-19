import { NgModule } from '@angular/core';
import {
  BrowserModule,
  provideClientHydration,
} from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CampaignsListComponent } from './features/campaigns/campaign-list/campaign-list.component';
import { CampaignDetailComponent } from './features/campaigns/campaign-detail/campaign-detail.component';
import { CommonModule } from '@angular/common';
import { CharacterDetailComponent } from './features/characters/character-detail/character-detail.component';
import { CharacterListComponent } from './features/characters/character-list/character-list.component';
import { DomainListComponent } from './features/domain/domain-list/domain-list.component';
import { DomainDetailComponent } from './features/domain/domain-detail/domain-detail.component';
import { FactionListComponent } from './features/factions/faction-list/faction-list.component';
import { FactionDetailComponent } from './features/factions/faction-detail/faction-detail.component';
import { LocationListComponent } from './features/locations/location-list/location-list.component';
import { LocationDetailComponent } from './features/locations/location-detail/location-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    CampaignsListComponent,
    CampaignDetailComponent,
    CharacterListComponent,
    CharacterDetailComponent,
    DomainListComponent,
    DomainDetailComponent,
    FactionListComponent,
    FactionDetailComponent,
    LocationListComponent,
    LocationDetailComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, CommonModule],
  providers: [provideClientHydration()],
  bootstrap: [AppComponent],
})
export class AppModule {}

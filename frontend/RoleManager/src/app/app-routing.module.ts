import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { CampaignsListComponent } from './features/campaigns/campaign-list/campaign-list.component';
import { CampaignDetailComponent } from './features/campaigns/campaign-detail/campaign-detail.component';
import { CharacterListComponent } from './features/characters/character-list/character-list.component';
import { LocationListComponent } from './features/locations/location-list/location-list.component';
import { FactionListComponent } from './features/factions/faction-list/faction-list.component';
import { DomainListComponent } from './features/domain/domain-list/domain-list.component';
import { CharacterDetailComponent } from './features/characters/character-detail/character-detail.component';
import { LocationDetailComponent } from './features/locations/location-detail/location-detail.component';
import { FactionDetailComponent } from './features/factions/faction-detail/faction-detail.component';
import { DomainDetailComponent } from './features/domain/domain-detail/domain-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'campaigns', component: CampaignsListComponent },
  { path: 'campaigns/:id', component: CampaignDetailComponent }, // Solo muestra el detalle de la campaña

  // Nuevas páginas independientes para personajes, localizaciones, facciones y dominios
  { path: 'campaigns/:id/characters', component: CharacterListComponent },
  {
    path: 'campaigns/:campaignId/characters/:id',
    component: CharacterDetailComponent,
  },

  { path: 'campaigns/:id/locations', component: LocationListComponent },
  {
    path: 'campaigns/:campaignId/locations/:id',
    component: LocationDetailComponent,
  },

  { path: 'campaigns/:id/factions', component: FactionListComponent },
  {
    path: 'campaigns/:campaignId/factions/:id',
    component: FactionDetailComponent,
  },

  { path: 'campaigns/:id/domains', component: DomainListComponent },
  {
    path: 'campaigns/:campaignId/domains/:id',
    component: DomainDetailComponent,
  },

  { path: '**', redirectTo: '' }, // Redirige a la página de inicio para cualquier ruta no encontrada
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

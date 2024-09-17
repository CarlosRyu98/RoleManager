import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampaignComponent } from './pages/campaign/campaign.component';
import { HomeComponent } from './pages/home/home.component';
import { DomainComponent } from './pages/domain/domain.component';
import { CharacterComponent } from './pages/character/character.component';
import { FactionComponent } from './pages/faction/faction.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'campaign/:id', component: CampaignComponent },
  { path: 'domain/:id', component: DomainComponent },
  { path: 'character/:id', component: CharacterComponent },
  { path: 'faction/:id', component: FactionComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

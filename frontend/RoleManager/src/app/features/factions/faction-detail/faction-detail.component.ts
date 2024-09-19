import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location as LocationAngular } from '@angular/common';
import { Faction } from '../../../core/models/faction.model';

@Component({
  selector: 'app-faction-detail',
  templateUrl: './faction-detail.component.html',
  styleUrls: ['./faction-detail.component.css'],
})
export class FactionDetailComponent implements OnInit {
  faction!: Faction; // Facción que se mostrará
  factionId!: number;

  // Simulación de datos (reemplazar con un servicio real)
  factions: Faction[] = [
    {
      factionId: 1,
      campaignId: 1,
      name: 'Guerreros del Fuego',
      description: 'Una facción conocida por su fuerza y coraje.',
      type: 'Militar',
      leaderId: 1,
      leader: { id: 1, name: 'Aragorn' },
      members: [
        { id: 2, name: 'Legolas' },
        { id: 3, name: 'Gimli' },
      ],
      base: 'Fortaleza de Roca Roja',
      history: 'Una facción que se forjó en las tierras volcánicas.',
      objectives: 'Conquistar nuevas tierras y defender su reino.',
      allies: [{ factionId: 2, name: 'Aliados del Viento', campaignId: 1 }],
      enemies: [{ factionId: 3, name: 'Los Sombras Oscuras', campaignId: 1 }],
    },
    // Otras facciones...
  ];

  constructor(
    private route: ActivatedRoute,
    private location: LocationAngular
  ) {}

  ngOnInit(): void {
    this.factionId = +this.route.snapshot.paramMap.get('factionId')!;

    // Busca la facción por ID
    // this.faction = this.factions.find(
    //   (faction) => faction.factionId === this.factionId
    // )!;
    this.faction = this.factions[0];
  }

  goBack(): void {
    this.location.back();
  }
}

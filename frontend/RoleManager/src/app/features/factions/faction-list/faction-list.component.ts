import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

// Modelo mock-up de una Facción
interface Faction {
  id: number;
  name: string;
  description: string;
}

@Component({
  selector: 'app-faction-list',
  templateUrl: './faction-list.component.html',
  styleUrls: ['./faction-list.component.css'],
})
export class FactionListComponent implements OnInit {
  // Simulación de una lista de facciones
  factions: Faction[] = [
    {
      id: 1,
      name: 'The Shadow Brotherhood',
      description: 'A secretive faction that operates from the shadows.',
    },
    {
      id: 2,
      name: 'Order of the Light',
      description: 'A noble faction dedicated to justice and peace.',
    },
    {
      id: 3,
      name: 'The Fire Clan',
      description:
        'A fierce faction known for their fiery temper and strength.',
    },
    {
      id: 4,
      name: 'The Oceanic Alliance',
      description:
        'A faction that governs the seas and protects maritime interests.',
    },
  ];

  campaignId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private location: Location
  ) {}

  ngOnInit(): void {
    // Obtener el ID de la campaña de la ruta activa
    this.campaignId = +this.route.snapshot.paramMap.get('id')!; // Asegúrate de que el ID sea un número
  }

  createNewFaction() {
    // Navega a la ruta para crear una nueva facción
    this.router.navigate([`/campaigns/${this.campaignId}/factions/new`]);
  }

  goBack(): void {
    this.location.back();
  }
}

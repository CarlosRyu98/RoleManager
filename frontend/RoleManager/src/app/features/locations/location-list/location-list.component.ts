import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

// Modelo mock-up de una Ubicación
interface ILocation {
  id: number;
  name: string;
  description: string;
}

@Component({
  selector: 'app-location-list',
  templateUrl: './location-list.component.html',
  styleUrls: ['./location-list.component.css'],
})
export class LocationListComponent implements OnInit {
  // Simulación de una lista de ubicaciones
  locations: ILocation[] = [
    {
      id: 1,
      name: 'Enchanted Forest',
      description: 'A mystical forest filled with magical creatures.',
    },
    {
      id: 2,
      name: 'Ancient Ruins',
      description: 'The remains of a once-great civilization.',
    },
    {
      id: 3,
      name: 'Crystal Caverns',
      description: 'A series of caves filled with stunning crystals.',
    },
    {
      id: 4,
      name: 'Desert Oasis',
      description: 'A refreshing oasis amidst the vast desert.',
    },
  ];

  campaignId!: number;

  constructor(private route: ActivatedRoute, private location: Location) {}

  ngOnInit(): void {
    // Obtener el ID de la campaña de la ruta activa
    this.campaignId = +this.route.snapshot.paramMap.get('id')!; // Asegúrate de que el ID sea un número
  }

  goBack(): void {
    this.location.back();
  }
}

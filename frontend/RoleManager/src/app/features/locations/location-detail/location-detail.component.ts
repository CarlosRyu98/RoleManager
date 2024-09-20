import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location as LocationAngular } from '@angular/common';
import { Location } from '../../../core/models/location.model'; // Asume que tienes este modelo

@Component({
  selector: 'app-location-detail',
  templateUrl: './location-detail.component.html',
  styleUrls: ['./location-detail.component.css'],
})
export class LocationDetailComponent implements OnInit {
  location!: Location; // Localización que se mostrará
  locationId!: number;

  // Simulación de datos (reemplazar con un servicio real)
  locations: Location[] = [
    {
      locationId: 1,
      name: 'Bosque Oscuro',
      description: 'Un denso bosque lleno de peligros.',
      domainId: 1,
      domain: { domainId: 1, name: 'Dominio de los Elfos', campaignId: 1 }, // Datos del dominio
      characterIds: [1, 2],
      characters: [
        { id: 1, name: 'Aragorn' },
        { id: 2, name: 'Legolas' },
      ],
      campaignId: 1,
    },
    // Otras localizaciones...
  ];

  constructor(
    private route: ActivatedRoute,
    private locationService: LocationAngular // Inyección del servicio de Angular para regresar
  ) {}

  ngOnInit(): void {
    this.locationId = +this.route.snapshot.paramMap.get('locationId')!;

    // Busca la localización por ID (puedes reemplazar esto con una llamada a un servicio real)
    // this.location = this.locations.find(
    //   (location) => location.locationId === this.locationId
    // )!;
    this.location = this.locations[0];
  }

  goBack(): void {
    this.locationService.back();
  }
}

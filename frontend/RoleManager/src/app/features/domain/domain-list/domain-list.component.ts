import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

// Modelo mock-up de un Dominio
interface Domain {
  id: number;
  name: string;
  description: string;
}

@Component({
  selector: 'app-domain-list',
  templateUrl: './domain-list.component.html',
  styleUrls: ['./domain-list.component.css'],
})
export class DomainListComponent implements OnInit {
  // Simulación de una lista de dominios
  domains: Domain[] = [
    {
      id: 1,
      name: 'Domain of Shadows',
      description: 'A mysterious domain shrouded in darkness and secrecy.',
    },
    {
      id: 2,
      name: 'Realm of Light',
      description: 'A domain bathed in eternal light and peace.',
    },
    {
      id: 3,
      name: 'Kingdom of Flames',
      description:
        'A fiery domain known for its volcanic landscapes and hot tempers.',
    },
    {
      id: 4,
      name: 'Oceanic Depths',
      description:
        'A domain beneath the waves, full of ancient secrets and sea creatures.',
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

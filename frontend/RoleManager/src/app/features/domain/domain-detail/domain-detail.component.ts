import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location as LocationAngular } from '@angular/common';
import { Domain } from '../../../core/models/domain.model';

@Component({
  selector: 'app-domain-detail',
  templateUrl: './domain-detail.component.html',
  styleUrls: ['./domain-detail.component.css'],
})
export class DomainDetailComponent implements OnInit {
  domain!: Domain; // El dominio que se mostrará
  domainId!: number;

  // Simulación de datos (reemplaza esto con tus datos reales o servicio)
  domains: Domain[] = [
    {
      domainId: 1,
      name: 'Kingdom of Zaria',
      description: 'A vast and ancient kingdom known for its powerful army.',
      type: 'Reino',
      locationIds: [1, 2],
      locations: [
        {
          name: 'Zaria Castle',
          locationId: 1,
        },
        {
          name: 'Old Forest',
          locationId: 2,
        },
      ],
      characterIds: [1, 2],
      characters: [
        {
          name: 'King Valron',
          id: 1,
        },
        {
          name: 'Sir Lancelot',
          id: 2,
        },
      ],
      factionIds: [1],
      factions: [
        {
          name: 'Knights of Zaria',
          factionId: 1,
          campaignId: 1,
        },
      ],
      history: 'Once a small tribe, Zaria grew into a mighty kingdom.',
      objectives: 'To expand its borders and protect its people.',
      campaignId: 1,
    },
    // Otros dominios...
  ];

  constructor(
    private route: ActivatedRoute,
    private location: LocationAngular
  ) {}

  ngOnInit(): void {
    this.domainId = +this.route.snapshot.paramMap.get('domainId')!;

    // Busca el dominio por ID
    // this.domain = this.domains.find((dom) => dom.domainId === this.domainId)!;
    this.domain = this.domains[0];
  }

  goBack(): void {
    this.location.back();
  }
}

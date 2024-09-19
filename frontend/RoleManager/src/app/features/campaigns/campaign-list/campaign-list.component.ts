import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-campaign-list',
  templateUrl: './campaign-list.component.html',
  styleUrls: ['./campaign-list.component.css'],
})
export class CampaignsListComponent implements OnInit {
  campaigns = [
    { id: 1, name: 'Campaña 1', description: 'Descripción de la Campaña 1' },
    { id: 2, name: 'Campaña 2', description: 'Descripción de la Campaña 2' },
    { id: 3, name: 'Campaña 3', description: 'Descripción de la Campaña 3' },
  ];

  constructor(private router: Router) {}

  ngOnInit(): void {}

  createNewCampaign() {
    // Navega a la ruta para crear una nueva campaña
    this.router.navigate(['/campaigns/new']);
  }

  viewCampaignDetails(id: number) {
    // Navega a la ruta de detalles de la campaña con el ID proporcionado
    this.router.navigate([`/campaigns/${id}`]);
  }
}

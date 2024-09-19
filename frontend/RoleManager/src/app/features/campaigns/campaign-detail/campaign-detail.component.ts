import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-campaign-detail',
  templateUrl: './campaign-detail.component.html',
  styleUrls: ['./campaign-detail.component.css'],
})
export class CampaignDetailComponent implements OnInit {
  campaign: any;

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    // Obtener el ID de la campaña de los parámetros de la ruta
    const campaignId = this.route.snapshot.paramMap.get('id');

    // Comprobar si campaignId no es null
    if (campaignId) {
      // Aquí normalmente obtendrás los detalles de la campaña desde un servicio
      // Para este ejemplo, usaremos datos simulados
      this.campaign = {
        id: +campaignId,
        name: `Campaña ${campaignId}`,
        description: `Descripción detallada de la Campaña ${campaignId}`,
      };
    } else {
      // Manejar el caso en que campaignId es null (por ejemplo, redirigiendo a una página de error o a la lista de campañas)
      this.router.navigate(['/campaigns']);
    }
  }

  goBack() {
    this.router.navigate(['/campaigns']);
  }

  viewDetails(section: string) {
    const campaignId = this.campaign?.id;
    if (campaignId) {
      this.router.navigate([`/campaigns/${campaignId}/${section}`]);
    } else {
      // Manejar el caso en que no se encuentra el ID de la campaña
      this.router.navigate(['/campaigns']);
    }
  }
}

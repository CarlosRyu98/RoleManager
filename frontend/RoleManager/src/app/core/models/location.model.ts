import { Domain } from 'domain';
import { Character } from './campaign.model';

export interface Location {
  locationId: number; // Identificador único de la localización
  name: string; // Nombre de la localización
  description?: string; // Descripción de la localización (opcional)
  domainId?: number; // ID del dominio al que pertenece (opcional)
  domain?: Domain; // Navegación al dominio (opcional)
  characterIds?: number[]; // IDs de personajes en esta localización (opcional)
  characters?: Character[]; // Lista de personajes en la localización (opcional)
  campaignId?: number; // ID de la campaña a la que pertenece la localización
}

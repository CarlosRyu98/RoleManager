import { Character } from './campaign.model';
import { Faction } from './faction.model';
import { Location } from './location.model';

export interface Domain {
  domainId: number; // Identificador único del dominio
  name: string; // Nombre del dominio
  description?: string; // Descripción del dominio (opcional)
  type?: string; // Tipo del dominio (opcional, e.g., "Reino", "Federación")
  locationIds?: number[]; // Lista de identificadores de localizaciones asociadas (opcional)
  locations?: Location[]; // Lista de localizaciones (opcional)
  characterIds?: number[]; // Lista de identificadores de personajes en este dominio (opcional)
  characters?: Character[]; // Lista de personajes (opcional)
  factionIds?: number[]; // Lista de identificadores de facciones en este dominio (opcional)
  factions?: Faction[]; // Lista de facciones (opcional)
  history?: string; // Historia del dominio (opcional)
  objectives?: string; // Objetivos del dominio (opcional)
  campaignId: number; // ID de la campaña a la que pertenece el dominio (opcional)
}

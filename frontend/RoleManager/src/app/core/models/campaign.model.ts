import { Domain } from 'domain';
import { Faction } from './faction.model';

export interface Campaign {
  campaignId: number; // Identificador único de la campaña
  name: string; // Nombre de la campaña
  description?: string; // Descripción de la campaña (opcional)
  history?: string; // Historia de la campaña (opcional)
  characterIds?: number[]; // Lista de identificadores de personajes (opcional)
  characters?: Character[]; // Lista de personajes (opcional)
  factionIds?: number[]; // Lista de identificadores de facciones (opcional)
  factions?: Faction[]; // Lista de facciones (opcional)
  domainIds?: number[]; // Lista de identificadores de dominios (opcional)
  domains?: Domain[]; // Lista de dominios (opcional)
  locationIds?: number[]; // Lista de identificadores de ubicaciones (opcional)
  locations?: Location[]; // Lista de ubicaciones (opcional)
  questIds?: number[]; // Lista de identificadores de misiones (opcional)
  quests?: Quest[]; // Lista de misiones (opcional)
}

// Ejemplo de interfaces para los tipos relacionados (debes definir estas interfaces según tu modelo)
export interface Character {
  id: number;
  name: string;
  // Otros campos necesarios
}

export interface Quest {
  id: number;
  name: string;
  // Otros campos necesarios
}

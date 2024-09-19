import { Character } from './campaign.model';

export interface Faction {
  factionId: number; // Identificador único de la facción
  campaignId: number; // ID de la campaña a la que pertenece la facción
  name: string; // Nombre de la facción
  description?: string; // Descripción de la facción (opcional)
  type?: string; // Tipo de la facción (opcional)
  leaderId?: number; // ID del personaje líder (opcional)
  leader?: Character; // Personaje líder (opcional)
  members?: Character[]; // Lista de personajes miembros (opcional)
  base?: string; // Base de operaciones (opcional)
  history?: string; // Historia de la facción (opcional)
  objectives?: string; // Objetivos de la facción (opcional)
  allies?: Faction[]; // Lista de facciones aliadas (opcional)
  enemies?: Faction[]; // Lista de facciones enemigas (opcional)
}

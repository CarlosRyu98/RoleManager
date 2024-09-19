import { Faction } from "./faction.model";

export interface Character {
  characterId: number; // Identificador único del personaje
  name?: string; // Nombre del personaje
  sex?: string; // Sexo del personaje
  race?: string; // Raza del personaje
  inventory?: string[]; // Inventario del personaje
  proficiencies?: string[]; // Competencias del personaje
  languages?: string[]; // Idiomas que habla el personaje
  backstory?: string; // Historia del personaje
  motivations?: string; // Motivaciones del personaje
  personalityTraits?: string; // Rasgos de personalidad
  physicalDescription?: string; // Descripción física
  quirks?: string; // Manías
  status?: string; // Estado del personaje
  campaignId: number; // ID de la campaña a la que pertenece
  factionId?: number; // ID de la facción a la que pertenece (opcional)
  faction?: Faction; // Navegación a la facción (opcional)
  locationId?: number; // ID de la localización (opcional)
  allies?: Character[]; // Simpatías del personaje
  rivals?: Character[]; // Rivalidades del personaje
}

export interface CharacterEpic extends Character {
  strength?: number; // Fuerza del personaje
  dexterity?: number; // Destreza del personaje
  constitution?: number; // Constitución del personaje
  intelligence?: number; // Inteligencia del personaje
  wisdom?: number; // Sabiduría del personaje
  charisma?: number; // Carisma del personaje
  hitPoints?: number; // Puntos de vida
  armorClass?: number; // Clase de armadura
}

export interface CharacterNpc extends Character {
  // Puedes agregar propiedades específicas para NPCs aquí si es necesario
}

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import {
  Character,
  CharacterNpc,
  CharacterEpic,
} from '../../../core/models/character.model';

// Importa la interfaz Character
@Component({
  selector: 'app-character-list',
  templateUrl: './character-list.component.html',
  styleUrls: ['./character-list.component.css'],
})
export class CharacterListComponent implements OnInit {
  // Simulación de una lista de personajes
  characters: Character[] = [
    {
      characterId: 1,
      name: 'Goroth the Fierce',
      sex: 'Male',
      race: 'Human',
      inventory: ['Sword', 'Shield'],
      proficiencies: ['Melee', 'Archery'],
      languages: ['Common', 'Elvish'],
      backstory: 'A legendary warrior of great power.',
      motivations: 'To protect the realm.',
      personalityTraits: 'Brave, Stubborn',
      physicalDescription: 'Tall and muscular',
      quirks: 'Always carries a lucky charm',
      status: 'Alive',
      campaignId: 1,
      factionId: 1,
      allies: [],
      rivals: [],
    },
    // Aquí puedes incluir más personajes si lo deseas.
  ];

  npcs: CharacterNpc[] = [];
  epicCharacters: CharacterEpic[] = [];
  campaignId!: number;

  constructor(private route: ActivatedRoute, private location: Location) {}

  ngOnInit(): void {
    // Generación de NPCs
    this.npcs = [
      {
        characterId: 5,
        name: 'Thalia the Herbalist',
        sex: 'Female',
        race: 'Human',
        inventory: ['Herbal Kit'],
        proficiencies: ['Herbalism'],
        languages: ['Common'],
        backstory: 'A skilled herbalist who knows the secrets of the forest.',
        motivations: 'To heal the sick and wounded.',
        personalityTraits: 'Gentle, Knowledgeable',
        physicalDescription: 'Short with long, flowing hair',
        quirks: 'Always smells like herbs',
        status: 'Alive',
        campaignId: 1,
        allies: [],
        rivals: [],
      },
      {
        characterId: 6,
        name: 'Grom the Guard',
        sex: 'Male',
        race: 'Orc',
        inventory: ['Spear', 'Shield'],
        proficiencies: ['Melee'],
        languages: ['Common', 'Orcish'],
        backstory: 'A loyal guard who protects the village.',
        motivations: 'To keep the village safe.',
        personalityTraits: 'Loyal, Tough',
        physicalDescription: 'Large and muscular',
        quirks: 'Always sharpens his spear',
        status: 'Alive',
        campaignId: 1,
        allies: [],
        rivals: [],
      },
      {
        characterId: 7,
        name: 'Lira the Bard',
        sex: 'Female',
        race: 'Halfling',
        inventory: ['Lute'],
        proficiencies: ['Performance', 'Storytelling'],
        languages: ['Common', 'Halfling'],
        backstory: 'A wandering bard who brings joy to all.',
        motivations: 'To entertain and spread stories.',
        personalityTraits: 'Cheerful, Witty',
        physicalDescription: 'Small and lively',
        quirks: 'Always has a new song to sing',
        status: 'Alive',
        campaignId: 1,
        allies: [],
        rivals: [],
      },
    ];

    // Generación de Personajes Épicos
    this.epicCharacters = [
      {
        characterId: 8,
        name: 'Aelar the Valiant',
        sex: 'Male',
        race: 'Elf',
        inventory: ['Legendary Sword'],
        proficiencies: ['Swordsmanship', 'Leadership'],
        languages: ['Common', 'Elvish'],
        backstory: 'A hero who once saved the kingdom from a dark lord.',
        motivations: 'To restore peace and justice.',
        personalityTraits: 'Noble, Brave',
        physicalDescription: 'Tall with striking features',
        quirks: 'Has a scar over his eye',
        status: 'Alive',
        campaignId: 1,
        factionId: 1, // Asignar a una facción si es necesario
        allies: [],
        rivals: [],
      },
      {
        characterId: 9,
        name: 'Seraphina the Enchantress',
        sex: 'Female',
        race: 'Human',
        inventory: ['Staff of Power'],
        proficiencies: ['Magic', 'Enchanting'],
        languages: ['Common', 'Arcane'],
        backstory: 'A powerful enchantress feared by many.',
        motivations: 'To gain knowledge of ancient magic.',
        personalityTraits: 'Mysterious, Ambitious',
        physicalDescription: 'Elegant with a commanding presence',
        quirks: 'Always plays with her staff',
        status: 'Alive',
        campaignId: 1,
        factionId: 2,
        allies: [],
        rivals: [],
      },
      {
        characterId: 10,
        name: 'Thorne the Beastmaster',
        sex: 'Male',
        race: 'Half-Orc',
        inventory: ['Beast Whistle'],
        proficiencies: ['Animal Handling', 'Tracking'],
        languages: ['Common', 'Orcish'],
        backstory: 'A legendary beastmaster who commands a pack of wolves.',
        motivations: 'To protect the wilds from encroachment.',
        personalityTraits: 'Wild, Intuitive',
        physicalDescription: 'Rugged and fierce-looking',
        quirks: 'Always accompanied by a wolf',
        status: 'Alive',
        campaignId: 1,
        allies: [],
        rivals: [],
      },
    ];

    this.campaignId = +this.route.snapshot.paramMap.get('id')!; // Asegúrate de que el ID sea un número
  }

  // Función para volver atrás
  goBack(): void {
    this.location.back();
  }
}

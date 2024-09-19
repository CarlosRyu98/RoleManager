import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  Character,
  CharacterEpic,
  CharacterNpc,
} from '../../../core/models/character.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-character-detail',
  templateUrl: './character-detail.component.html',
  styleUrls: ['./character-detail.component.css'],
})
export class CharacterDetailComponent implements OnInit {
  character!: Character | CharacterEpic | CharacterNpc; // Puede ser un personaje épico o un NPC
  campaignId!: number;
  characterId!: number;

  // Simulación de datos (reemplaza esto con tus datos reales o servicio)
  characters: (Character | CharacterEpic | CharacterNpc)[] = [
    // Aquí deberías incluir tus personajes de prueba
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

      // Atributos épicos añadidos
      strength: 18, // Fuerza
      dexterity: 14, // Destreza
      constitution: 16, // Constitución
      intelligence: 12, // Inteligencia
      wisdom: 10, // Sabiduría
      charisma: 15, // Carisma
      hitPoints: 120, // Puntos de vida
      armorClass: 18, // Clase de armadura
    },
    // Más personajes...
  ];

  constructor(private route: ActivatedRoute, private location: Location) {}

  // Método para comprobar si un personaje es de tipo CharacterEpic
  isCharacterEpic(
    character: Character | CharacterEpic | CharacterNpc
  ): character is CharacterEpic {
    // Verifica si el personaje tiene los atributos específicos de CharacterEpic
    return (
      'strength' in character &&
      'dexterity' in character &&
      'constitution' in character &&
      'intelligence' in character &&
      'wisdom' in character &&
      'charisma' in character &&
      'hitPoints' in character &&
      'armorClass' in character
    );
  }

  ngOnInit(): void {
    this.campaignId = +this.route.snapshot.paramMap.get('campaignId')!;
    this.characterId = +this.route.snapshot.paramMap.get('characterId')!;

    // // Busca el personaje por ID
    // this.character = this.characters.find(
    //   (char) => char.characterId === this.characterId
    // )!;

    // Toma el primer personaje de la lista
    this.character = this.characters[0];
  }

  goBack(): void {
    this.location.back();
  }
}

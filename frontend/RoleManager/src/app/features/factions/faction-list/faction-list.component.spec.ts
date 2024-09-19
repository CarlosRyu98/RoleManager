/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FactionListComponent } from './faction-list.component';

describe('FactionListComponent', () => {
  let component: FactionListComponent;
  let fixture: ComponentFixture<FactionListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FactionListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FactionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CampaignsListComponent } from './campaign-list.component';

describe('CampaignsListComponent', () => {
  let component: CampaignsListComponent;
  let fixture: ComponentFixture<CampaignsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CampaignsListComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampaignsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

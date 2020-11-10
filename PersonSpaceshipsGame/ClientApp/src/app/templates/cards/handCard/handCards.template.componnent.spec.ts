
import { TestBed, ComponentFixture } from '@angular/core/testing';
import { HandCardsComponent } from './handCards.template.component';
import { ComponentFactory, Component, DebugElement } from '@angular/core';
import { FixedSizeVirtualScrollStrategy } from '@angular/cdk/scrolling';

describe('HandCardsTemplate', () => {
  let componnent: HandCardsComponent;
  let fixture: ComponentFixture<HandCardsComponent>;
  let de: DebugElement;

  beforeEach(async() => {
    TestBed.configureTestingModule({
      declarations: [HandCardsComponent], // your component here
      imports: [],
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HandCardsComponent);
    componnent = fixture.componentInstance;
    de = fixture.debugElement;
  });

  it('componnent be created', () => {
    expect(componnent).toBeTruthy();
  });
});

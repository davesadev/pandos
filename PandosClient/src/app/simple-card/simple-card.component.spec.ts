import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatCard } from '@angular/material/card';

import { SimpleCardComponent } from './simple-card.component';

describe('SimpleCardComponent', () => {
  let component: SimpleCardComponent;
  let fixture: ComponentFixture<SimpleCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SimpleCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpleCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

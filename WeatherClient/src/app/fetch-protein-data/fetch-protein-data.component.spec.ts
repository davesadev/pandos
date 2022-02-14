import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchProteinDataComponent } from './fetch-protein-data.component';

describe('FetchProteinDataComponent', () => {
  let component: FetchProteinDataComponent;
  let fixture: ComponentFixture<FetchProteinDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FetchProteinDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchProteinDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

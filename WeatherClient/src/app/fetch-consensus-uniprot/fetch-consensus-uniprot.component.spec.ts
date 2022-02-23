import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchConsensusUniprotComponent } from './fetch-consensus-uniprot.component';

describe('FetchConsensusUniprotComponent', () => {
  let component: FetchConsensusUniprotComponent;
  let fixture: ComponentFixture<FetchConsensusUniprotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FetchConsensusUniprotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchConsensusUniprotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

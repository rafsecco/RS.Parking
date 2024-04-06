import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccordTypesListComponent } from './accordtypes-list.component';

describe('AccordTypesListComponent', () => {
  let component: AccordTypesListComponent;
  let fixture: ComponentFixture<AccordTypesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccordTypesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccordTypesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

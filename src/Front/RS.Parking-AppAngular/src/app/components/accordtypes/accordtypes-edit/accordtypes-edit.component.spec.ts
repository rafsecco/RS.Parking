import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccordTypesEditComponent } from './accordtypes-edit.component';

describe('AccordTypesEditComponent', () => {
  let component: AccordTypesEditComponent;
  let fixture: ComponentFixture<AccordTypesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccordTypesEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccordTypesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccordtypesListComponent } from './accordtypes-list.component';

describe('AccordtypesListComponent', () => {
  let component: AccordtypesListComponent;
  let fixture: ComponentFixture<AccordtypesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccordtypesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccordtypesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

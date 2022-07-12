import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccordtypesComponent } from './accordtypes.component';

describe('AccordtypesComponent', () => {
  let component: AccordtypesComponent;
  let fixture: ComponentFixture<AccordtypesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccordtypesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccordtypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

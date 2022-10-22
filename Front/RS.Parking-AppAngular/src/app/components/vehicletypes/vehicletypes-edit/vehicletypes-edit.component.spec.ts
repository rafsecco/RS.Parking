import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicletypesEditComponent } from './vehicletypes-edit.component';

describe('VehicletypesEditComponent', () => {
  let component: VehicletypesEditComponent;
  let fixture: ComponentFixture<VehicletypesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicletypesEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicletypesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

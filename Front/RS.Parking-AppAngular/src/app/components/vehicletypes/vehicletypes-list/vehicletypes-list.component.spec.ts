import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicletypesListComponent } from './vehicletypes-list.component';

describe('VehicletypesListComponent', () => {
  let component: VehicletypesListComponent;
  let fixture: ComponentFixture<VehicletypesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicletypesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicletypesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

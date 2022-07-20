import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicletypesNewComponent } from './vehicletypes-new.component';

describe('VehicletypesNewComponent', () => {
  let component: VehicletypesNewComponent;
  let fixture: ComponentFixture<VehicletypesNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicletypesNewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicletypesNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

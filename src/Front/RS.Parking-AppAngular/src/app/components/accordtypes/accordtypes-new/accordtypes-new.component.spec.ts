import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccordTypesNewComponent } from './accordtypes-new.component';

describe('AccordTypesNewComponent', () => {
  let component: AccordTypesNewComponent;
  let fixture: ComponentFixture<AccordTypesNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccordTypesNewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccordTypesNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

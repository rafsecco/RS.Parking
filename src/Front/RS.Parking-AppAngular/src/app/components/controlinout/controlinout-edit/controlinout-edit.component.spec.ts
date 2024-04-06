import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlinoutEditComponent } from './controlinout-edit.component';

describe('ControlinoutEditComponent', () => {
  let component: ControlinoutEditComponent;
  let fixture: ComponentFixture<ControlinoutEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ControlinoutEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ControlinoutEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

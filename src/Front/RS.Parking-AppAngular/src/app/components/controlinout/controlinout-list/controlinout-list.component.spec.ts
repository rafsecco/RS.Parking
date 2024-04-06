import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlInOutListComponent } from './controlinout-list.component';

describe('ControlInOutListComponent', () => {
  let component: ControlInOutListComponent;
  let fixture: ComponentFixture<ControlInOutListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ControlInOutListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ControlInOutListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

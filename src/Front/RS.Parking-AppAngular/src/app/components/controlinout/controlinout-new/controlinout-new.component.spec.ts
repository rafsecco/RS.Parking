import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlinoutNewComponent } from './controlinout-new.component';

describe('ControlinoutNewComponent', () => {
  let component: ControlinoutNewComponent;
  let fixture: ComponentFixture<ControlinoutNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ControlinoutNewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ControlinoutNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

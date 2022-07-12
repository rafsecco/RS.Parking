/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ControlinoutComponent } from './controlinout.component';

describe('ControlinoutComponent', () => {
  let component: ControlinoutComponent;
  let fixture: ComponentFixture<ControlinoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ControlinoutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ControlinoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

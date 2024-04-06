/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ControlInOutService } from './ControlInOut.service';

describe('Service: ControlInOut', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ControlInOutService]
    });
  });

  it('should ...', inject([ControlInOutService], (service: ControlInOutService) => {
    expect(service).toBeTruthy();
  }));
});

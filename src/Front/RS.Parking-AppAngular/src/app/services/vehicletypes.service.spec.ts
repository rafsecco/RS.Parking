/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { VehicletypesService } from './vehicletypes.service';

describe('Service: Vehicletypes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VehicletypesService]
    });
  });

  it('should ...', inject([VehicletypesService], (service: VehicletypesService) => {
    expect(service).toBeTruthy();
  }));
});

/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AccordTypesService } from './AccordTypes.service';

describe('Service: AccordTypes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccordTypesService]
    });
  });

  it('should ...', inject([AccordTypesService], (service: AccordTypesService) => {
    expect(service).toBeTruthy();
  }));
});

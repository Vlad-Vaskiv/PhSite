/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FirmServiceService } from './firm-service.service';

describe('Service: FirmService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FirmServiceService]
    });
  });

  it('should ...', inject([FirmServiceService], (service: FirmServiceService) => {
    expect(service).toBeTruthy();
  }));
});

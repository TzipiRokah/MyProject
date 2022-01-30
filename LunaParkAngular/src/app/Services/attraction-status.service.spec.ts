import { TestBed, inject } from '@angular/core/testing';

import { AttractionStatusService } from './attraction-status.service';

describe('AttractionStatusService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AttractionStatusService]
    });
  });

  it('should be created', inject([AttractionStatusService], (service: AttractionStatusService) => {
    expect(service).toBeTruthy();
  }));
});

import { TestBed, inject } from '@angular/core/testing';

import { QueuePerUserService } from './queue-per-user.service';

describe('QueuePerUserService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QueuePerUserService]
    });
  });

  it('should be created', inject([QueuePerUserService], (service: QueuePerUserService) => {
    expect(service).toBeTruthy();
  }));
});

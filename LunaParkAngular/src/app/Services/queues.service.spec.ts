import { TestBed, inject } from '@angular/core/testing';

import { QueuesService } from './queues.service';

describe('QueuesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QueuesService]
    });
  });

  it('should be created', inject([QueuesService], (service: QueuesService) => {
    expect(service).toBeTruthy();
  }));
});

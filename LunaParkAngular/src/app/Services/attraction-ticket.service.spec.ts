import { TestBed, inject } from '@angular/core/testing';

import { AttractionTicketService } from './attraction-ticket.service';

describe('AttractionTicketService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AttractionTicketService]
    });
  });

  it('should be created', inject([AttractionTicketService], (service: AttractionTicketService) => {
    expect(service).toBeTruthy();
  }));
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TicketBasketComponent } from './ticket-basket.component';

describe('TicketBasketComponent', () => {
  let component: TicketBasketComponent;
  let fixture: ComponentFixture<TicketBasketComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TicketBasketComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TicketBasketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

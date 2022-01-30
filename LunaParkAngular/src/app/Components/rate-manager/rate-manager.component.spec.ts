import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RateManagerComponent } from './rate-manager.component';

describe('RateManagerComponent', () => {
  let component: RateManagerComponent;
  let fixture: ComponentFixture<RateManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RateManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RateManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

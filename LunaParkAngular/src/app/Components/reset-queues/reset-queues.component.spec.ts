import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResetQueuesComponent } from './reset-queues.component';

describe('ResetQueuesComponent', () => {
  let component: ResetQueuesComponent;
  let fixture: ComponentFixture<ResetQueuesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResetQueuesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResetQueuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

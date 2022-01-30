import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttractionStatusViewComponent } from './attraction-status-view.component';

describe('AttractionStatusViewComponent', () => {
  let component: AttractionStatusViewComponent;
  let fixture: ComponentFixture<AttractionStatusViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttractionStatusViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttractionStatusViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

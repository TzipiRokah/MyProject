import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SadranComponent } from './sadran.component';

describe('SadranComponent', () => {
  let component: SadranComponent;
  let fixture: ComponentFixture<SadranComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SadranComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SadranComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

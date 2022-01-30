import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseAttractionComponent } from './choose-attraction.component';

describe('ChooseAttractionComponent', () => {
  let component: ChooseAttractionComponent;
  let fixture: ComponentFixture<ChooseAttractionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChooseAttractionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseAttractionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

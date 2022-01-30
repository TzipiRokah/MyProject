import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickAttractionComponent } from './quick-attraction.component';

describe('QuickAttractionComponent', () => {
  let component: QuickAttractionComponent;
  let fixture: ComponentFixture<QuickAttractionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuickAttractionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickAttractionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

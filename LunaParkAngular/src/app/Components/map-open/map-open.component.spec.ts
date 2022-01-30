import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapOpenComponent } from './map-open.component';

describe('MapOpenComponent', () => {
  let component: MapOpenComponent;
  let fixture: ComponentFixture<MapOpenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapOpenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

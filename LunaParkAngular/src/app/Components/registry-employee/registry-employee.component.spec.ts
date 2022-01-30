import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistryEmployeeComponent } from './registry-employee.component';

describe('RegistryEmployeeComponent', () => {
  let component: RegistryEmployeeComponent;
  let fixture: ComponentFixture<RegistryEmployeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistryEmployeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistryEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

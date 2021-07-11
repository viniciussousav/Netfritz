import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FitasManagementComponent } from './fitas-management.component';

describe('FitasManagementComponent', () => {
  let component: FitasManagementComponent;
  let fixture: ComponentFixture<FitasManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FitasManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FitasManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

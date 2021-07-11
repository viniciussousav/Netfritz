import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewFitaModalComponent } from './new-fita-modal.component';

describe('NewFitaModalComponent', () => {
  let component: NewFitaModalComponent;
  let fixture: ComponentFixture<NewFitaModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewFitaModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewFitaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

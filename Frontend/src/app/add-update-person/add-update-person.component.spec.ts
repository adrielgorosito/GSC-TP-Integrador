import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdatePersonComponent } from './add-update-person.component';

describe('AddUpdatePersonComponent', () => {
  let component: AddUpdatePersonComponent;
  let fixture: ComponentFixture<AddUpdatePersonComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddUpdatePersonComponent]
    });
    fixture = TestBed.createComponent(AddUpdatePersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

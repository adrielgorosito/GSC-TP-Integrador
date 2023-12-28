import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PeopleCRUDComponent } from './people-crud.component';

describe('PeopleCRUDComponent', () => {
  let component: PeopleCRUDComponent;
  let fixture: ComponentFixture<PeopleCRUDComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PeopleCRUDComponent]
    });
    fixture = TestBed.createComponent(PeopleCRUDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

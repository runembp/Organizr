import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateNewspostComponent } from './create-newspost.component';

describe('CreateNewspostComponent', () => {
  let component: CreateNewspostComponent;
  let fixture: ComponentFixture<CreateNewspostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateNewspostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateNewspostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

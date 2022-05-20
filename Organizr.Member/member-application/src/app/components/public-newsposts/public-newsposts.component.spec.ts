import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicNewspostsComponent } from './public-newsposts.component';

describe('PublicNewspostsComponent', () => {
  let component: PublicNewspostsComponent;
  let fixture: ComponentFixture<PublicNewspostsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublicNewspostsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PublicNewspostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

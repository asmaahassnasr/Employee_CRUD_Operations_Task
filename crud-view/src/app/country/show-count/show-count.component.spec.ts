import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowCountComponent } from './show-count.component';

describe('ShowCountComponent', () => {
  let component: ShowCountComponent;
  let fixture: ComponentFixture<ShowCountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowCountComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowCountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

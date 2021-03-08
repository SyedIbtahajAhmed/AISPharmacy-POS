import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericsComponent } from './generics.component';

describe('GenericsComponent', () => {
  let component: GenericsComponent;
  let fixture: ComponentFixture<GenericsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenericsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenericsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

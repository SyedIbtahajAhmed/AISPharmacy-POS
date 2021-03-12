import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateGenericDialogComponent } from './create-generic-dialog.component';

describe('CreateGenericDialogComponent', () => {
  let component: CreateGenericDialogComponent;
  let fixture: ComponentFixture<CreateGenericDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateGenericDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateGenericDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

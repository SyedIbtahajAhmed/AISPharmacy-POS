import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditGenericDialogComponent } from './edit-generic-dialog.component';

describe('EditGenericDialogComponent', () => {
  let component: EditGenericDialogComponent;
  let fixture: ComponentFixture<EditGenericDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditGenericDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditGenericDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

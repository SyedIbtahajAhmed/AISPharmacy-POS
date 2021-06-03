import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsOfGenericComponent } from './products-of-generic.component';

describe('ProductsOfGenericComponent', () => {
  let component: ProductsOfGenericComponent;
  let fixture: ComponentFixture<ProductsOfGenericComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsOfGenericComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsOfGenericComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsofCompanyComponent } from './productsof-company.component';

describe('ProductsofCompanyComponent', () => {
  let component: ProductsofCompanyComponent;
  let fixture: ComponentFixture<ProductsofCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsofCompanyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsofCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

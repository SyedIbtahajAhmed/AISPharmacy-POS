import { Component, Injector, ChangeDetectionStrategy, OnInit, ChangeDetectorRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { GetProductOutputDto, ProductServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent extends AppComponentBase implements OnInit {


  keyword: string;
  products: GetProductOutputDto[] = [];


  constructor(
    injector: Injector,
    private _productService: ProductServiceProxy,
    private ref: ChangeDetectorRef
    ) {
    super(injector);
    this._productService.listAllProducts(this.keyword).subscribe( (result) => {
      this.products = result;
      this.ref.markForCheck();
      //console.log(result);
    });
  }

  ngOnInit(): void {

  }
}

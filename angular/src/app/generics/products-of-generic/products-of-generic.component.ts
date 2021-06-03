import {Component, EventEmitter, Injector, OnInit, Output} from '@angular/core';
import {
    CompanyServiceProxy,
    GetProductOutputDto, MedicineGenericServiceProxy,
    ProductServiceProxy,
    UpdateProductInputDto
} from '../../../shared/service-proxies/service-proxies';
import {BsModalRef, BsModalService} from 'ngx-bootstrap/modal';
import {CreateProductDialogComponent} from '../../products/create-product/create-product-dialog/create-product-dialog.component';
import {EditProductDialogComponent} from '../../products/edit-product/edit-product-dialog/edit-product-dialog.component';
import {finalize} from 'rxjs/operators';
import {PagedListingComponentBase, PagedRequestDto} from '../../../shared/paged-listing-component-base';
import {appModuleAnimation} from '../../../shared/animations/routerTransition';

class PagedProductsRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}


@Component({
  selector: 'app-products-of-generic',
  templateUrl: './products-of-generic.component.html',
  styleUrls: ['./products-of-generic.component.css'],
    animations: [appModuleAnimation()]
})
export class ProductsOfGenericComponent extends PagedListingComponentBase<GetProductOutputDto> {

    products: GetProductOutputDto[] = [];
    keyword = '';
    totalProducts: number;
    advancedFiltersVisible = false;
    genericId: number;
    selectValue = 10;

    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        private _genericService: MedicineGenericServiceProxy,
        private _productService: ProductServiceProxy,
        private _modalService: BsModalService,
    ) {
        super(injector);
        //
        // this._productService.listAllProducts().subscribe((data: any) => {
        //   // console.log(data);
        //   this.products = data;
        //   this.totalProducts = this.products.length;
        //   console.log(this.totalProducts);
        // });
    }

    createProduct(): void {
        let createOrEditProductDialog: BsModalRef;
        if (!this.genericId) {
            createOrEditProductDialog = this._modalService.show(
                CreateProductDialogComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditProductDialog = this._modalService.show(
                CreateProductDialogComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        genericId: this.genericId,
                    },
                }
            );
        }

        createOrEditProductDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }

    editProduct(product: UpdateProductInputDto): void {
        let createOrEditProductDialog: BsModalRef;
        if (!product) {
            abp.message.error(
                this.l('Generic Does Not Exist.\nTry Adding First!')
            );
        } else {
            createOrEditProductDialog = this._modalService.show(
                EditProductDialogComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: product.id,
                    },
                }
            );
        }

        createOrEditProductDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }

    clearFilters(): void {
        this.keyword = '';
        this.getDataPage(1);
    }

    OnSearch(event: any) {
        this.keyword = event.target.value;
        this.getDataPage(1);
        console.log(this.keyword);
    }

    SelectItemNo() {
        if ( this.selectValue != null ) {
            this.pageSize = this.selectValue;
        } else {
            this.selectValue = 10;
        }
    }

    protected list(
        request: PagedProductsRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        request.keyword = this.keyword;

        this._genericService
            .getProductsOfGeneric(
                this.genericId,
                request.keyword
            )
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: any) => {
                this.products = result;
                this.totalProducts = this.products.length;
                this.showPaging(result, pageNumber);
                console.log('The Result Of List Is \n\n' + JSON.stringify(this.products));
            });
    }

    protected deleteProduct(product: number): void {
        abp.message.confirm(
            this.l('Product ' + product + ' Will Be Deleted!'),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._productService.delete(product).subscribe(() => {
                        abp.notify.success(this.l('Successfully Deleted'));
                        this.refresh();
                    });
                }
            }
        );
    }



    protected delete(entity: GetProductOutputDto): void {
        throw new Error('Method not implemented.');
    }

    // private showResetPasswordUserDialog(id?: number): void {
    //   this._modalService.show(ResetPasswordDialogComponent, {
    //     class: 'modal-lg',
    //     initialState: {
    //       id: id,
    //     },
    //   });
    // }

    // private showCreateOrEditProductDialog(id?: number): void {
    //     let createOrEditProductDialog: BsModalRef;
    //     if (!id) {
    //         createOrEditProductDialog = this._modalService.show(
    //             CreateProductDialogComponent,
    //             {
    //                 class: 'modal-lg',
    //             }
    //         );
    //     } else {
    //         createOrEditProductDialog = this._modalService.show(
    //             EditProductDialogComponent,
    //             {
    //                 class: 'modal-lg',
    //                 initialState: {
    //                     id: id,
    //                 },
    //             }
    //         );
    //     }
    //
    //     createOrEditProductDialog.content.onSave.subscribe(() => {
    //         this.refresh();
    //     });
    // }

}

import {Component, Injector, OnInit} from '@angular/core';
import {PagedListingComponentBase, PagedRequestDto} from '../../shared/paged-listing-component-base';
import {
    GetGenericOutputDto, GetProductOutputDto,
    MedicineGenericServiceProxy, ProductServiceProxy, UpdateGenericInputDto, UpdateProductInputDto,
    UserDto,
    UserDtoPagedResultDto,
    UserServiceProxy
} from '../../shared/service-proxies/service-proxies';
import {BsModalRef, BsModalService} from 'ngx-bootstrap/modal';
import {finalize} from 'rxjs/operators';
import {ResetPasswordDialogComponent} from '../users/reset-password/reset-password.component';
import {CreateUserDialogComponent} from '../users/create-user/create-user-dialog.component';
import {EditUserDialogComponent} from '../users/edit-user/edit-user-dialog.component';
import {CreateProductDialogComponent} from '../products/create-product/create-product-dialog/create-product-dialog.component';
import {EditProductDialogComponent} from '../products/edit-product/edit-product-dialog/edit-product-dialog.component';
import {CreateGenericDialogComponent} from './create-generic-dialog/create-generic-dialog.component';
import {EditGenericDialogComponent} from './edit-generic-dialog/edit-generic-dialog.component';
import {appModuleAnimation} from '../../shared/animations/routerTransition';


class PagedGenericsRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}

@Component({
  selector: 'app-generics',
  templateUrl: './generics.component.html',
  styleUrls: ['./generics.component.css'],
    animations: [appModuleAnimation()]
})
export class GenericsComponent extends PagedListingComponentBase<GetGenericOutputDto> {
    generics: GetGenericOutputDto[] = [];
    keyword = '';
    totalGenerics: number;
    advancedFiltersVisible = false;

    constructor(
        injector: Injector,
        private _genericService: MedicineGenericServiceProxy,
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

    createGeneric(): void {
        this.showCreateOrEditGenericDialog();
    }

    editGeneric(generic: UpdateGenericInputDto): void {
        this.showCreateOrEditGenericDialog(generic.id);
    }

    clearFilters(): void {
        this.keyword = '';
        this.getDataPage(1);
    }

    protected list(
        request: PagedGenericsRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        request.keyword = this.keyword;

        this._genericService
            .getAllGenerics(
                request.keyword
            )
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: any) => {
                this.generics = result;
                this.totalGenerics = this.generics.length;
                this.showPaging(result, pageNumber);
                // console.log("The Result Of List Is \n\n" + JSON.stringify(this.products));
            });
    }

    protected deleteGeneric(generic: number): void {
        abp.message.confirm(
            this.l('Product ' + generic + ' Will Be Deleted!'),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._genericService.delete(generic).subscribe(() => {
                        abp.notify.success(this.l('Successfully Deleted'));
                        this.refresh();
                    });
                }
            }
        );
    }



    protected delete(entity: GetGenericOutputDto): void {
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

    private showCreateOrEditGenericDialog(id?: number): void {
        let createOrEditGenericDialog: BsModalRef;
        if (!id) {
            createOrEditGenericDialog = this._modalService.show(
                CreateGenericDialogComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditGenericDialog = this._modalService.show(
                EditGenericDialogComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id,
                    },
                }
            );
        }

        createOrEditGenericDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }


    OnSearch(event: any) {
        this.keyword = event.target.value;
        this.getDataPage(1);
        console.log(this.keyword);
    }
}

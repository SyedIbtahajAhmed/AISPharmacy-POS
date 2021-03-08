import {Component, Injector, OnInit} from '@angular/core';
import {PagedListingComponentBase, PagedRequestDto} from '../../shared/paged-listing-component-base';
import {
    GetGenericOutputDto,
    MedicineGenericServiceProxy, UpdateGenericInputDto,
    UserDto,
    UserDtoPagedResultDto,
    UserServiceProxy
} from '../../shared/service-proxies/service-proxies';
import {BsModalRef, BsModalService} from 'ngx-bootstrap/modal';
import {finalize} from 'rxjs/operators';
import {ResetPasswordDialogComponent} from '../users/reset-password/reset-password.component';
import {CreateUserDialogComponent} from '../users/create-user/create-user-dialog.component';
import {EditUserDialogComponent} from '../users/edit-user/edit-user-dialog.component';


class PagedGenericsRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}


class MedicineGenericServiceProxyerviceProxy {
}

@Component({
  selector: 'app-generics',
  templateUrl: './generics.component.html',
  styleUrls: ['./generics.component.css']
})
export class GenericsComponent extends PagedListingComponentBase<GetGenericOutputDto> {
    generics: GetGenericOutputDto[] = [];
    keyword = '';

    constructor(
        injector: Injector,
        private _genericsService: MedicineGenericServiceProxy,
        private _modalService: BsModalService
    ) {
        super(injector);
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

        this._genericsService
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
                this.showPaging(result, pageNumber);
            });
    }


    protected deleteGeneric(genericId: number): void {
        abp.message.confirm(
            this.l('Generic ' + genericId + ' Will Be Deleted!'),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._genericsService.delete(genericId).subscribe(() => {
                        abp.notify.success(this.l('Successfully Deleted'));
                        this.refresh();
                    });
                }
            }
        );
    }

    protected delete(entity: GetGenericOutputDto): void {
    }

    // private showResetPasswordUserDialog(id?: number): void {
    //     this._modalService.show(ResetPasswordDialogComponent, {
    //         class: 'modal-lg',
    //         initialState: {
    //             id: id,
    //         },
    //     });
    // }

    private showCreateOrEditGenericDialog(id?: number): void {
        let createOrEditGenericDialog: BsModalRef;
        if (!id) {
            createOrEditGenericDialog = this._modalService.show(
                CreateUserDialogComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditGenericDialog = this._modalService.show(
                EditUserDialogComponent,
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
}

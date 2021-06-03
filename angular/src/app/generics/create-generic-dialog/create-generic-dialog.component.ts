import {ChangeDetectorRef, Component, EventEmitter, Injector, OnInit, Output} from '@angular/core';
import {
    CompanyServiceProxy, CreateGenericInputDto,
    CreateProductInputDto,
    GetCompanyOutputDto,
    GetGenericOutputDto, GetProductOutputDto, MedicineGenericServiceProxy,
    ProductServiceProxy
} from '../../../shared/service-proxies/service-proxies';
import {BsModalRef} from 'ngx-bootstrap/modal';
import {finalize} from 'rxjs/operators';
import {PagedListingComponentBase, PagedRequestDto} from '../../../shared/paged-listing-component-base';
import {AppComponentBase} from '../../../shared/app-component-base';

@Component({
  selector: 'app-create-generic-dialog',
  templateUrl: './create-generic-dialog.component.html',
  styleUrls: ['./create-generic-dialog.component.css']
})
export class CreateGenericDialogComponent extends AppComponentBase implements OnInit {

    saving = false;
    generic = new CreateGenericInputDto();

    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _genericService: MedicineGenericServiceProxy,
        public bsModalRef: BsModalRef,
    ) {
        super(injector);
    }

    ngOnInit(): void {

        //console.log ( this.product.companyId );
    }

    // setInitialRolesStatus(): void {
    //   _map(this.roles, (item) => {
    //     this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
    //       item.normalizedName
    //     );
    //   });
    // }

    // isRoleChecked(normalizedName: string): boolean {
    //   // just return default role checked status
    //   // it's better to use a setting
    //   return this.defaultRoleCheckedStatus;
    // }

    // onRoleChange(role: RoleDto, $event) {
    //   this.checkedRolesMap[role.normalizedName] = $event.target.checked;
    // }

    // getCheckedRoles(): string[] {
    //   const roles: string[] = [];
    //   _forEach(this.checkedRolesMap, function (value, key) {
    //     if (value) {
    //       roles.push(key);
    //     }
    //   });
    //   return roles;
    // }

    save(): void {
        this.saving = true;

        this._genericService
            .create(this.generic)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('Saved Successfully'));
                this.bsModalRef.hide();
                this.onSave.emit();
                window.location.reload();
            });
    }

    // SelectCompanyDropdown(event: any) {
    //   this.companyId = event.target.value;
    //   console.log(this.companyId);
    // }


}

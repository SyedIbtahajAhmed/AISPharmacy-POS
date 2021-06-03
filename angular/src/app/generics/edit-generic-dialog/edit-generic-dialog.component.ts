import {Component, EventEmitter, Injector, OnInit, Output} from '@angular/core';
import {
    CompanyServiceProxy,
    GetCompanyOutputDto,
    GetGenericOutputDto, MedicineGenericServiceProxy,
    ProductServiceProxy, UpdateGenericInputDto,
    UpdateProductInputDto
} from '../../../shared/service-proxies/service-proxies';
import {BsModalRef} from 'ngx-bootstrap/modal';
import {Router} from '@angular/router';
import {finalize} from 'rxjs/operators';
import {AppComponentBase} from '../../../shared/app-component-base';

@Component({
  selector: 'app-edit-generic-dialog',
  templateUrl: './edit-generic-dialog.component.html',
  styleUrls: ['./edit-generic-dialog.component.css']
})
export class EditGenericDialogComponent extends AppComponentBase implements OnInit {

    saving = false;
    generic = new UpdateGenericInputDto();
    keyword = '';
    // roles: RoleDto[] = [];
    // checkedRolesMap: { [key: string]: boolean } = {};
    genericId: number;

    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _genericService: MedicineGenericServiceProxy,
        public bsModalRef: BsModalRef,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._genericService.getGenericById(this.genericId).subscribe((result: any) => {
            this.generic = result;
        });
    }

    // setInitialRolesStatus(): void {
    //   _map(this.roles, (item) => {
    //     this.checkedRolesMap[item.normalizedName] = this.isRoleChecked(
    //       item.normalizedName
    //     );
    //   });
    // }

    // isRoleChecked(normalizedName: string): boolean {
    //   return _includes(this.user.roleNames, normalizedName);
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

        // this.user.roleNames = this.getCheckedRoles();

        this._genericService
            .update(this.generic)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.bsModalRef.hide();
                this.onSave.emit();
                window.location.reload();
            });
    }

}

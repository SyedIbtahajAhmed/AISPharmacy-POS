import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CompanyServiceProxy,
    GetCompanyOutputDto, GetGenericOutputDto, MedicineGenericServiceProxy,
    ProductServiceProxy,
    UpdateProductInputDto
} from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-product-dialog',
  templateUrl: './edit-product-dialog.component.html',
  styleUrls: ['./edit-product-dialog.component.css']
})
export class EditProductDialogComponent extends AppComponentBase implements OnInit {
  saving = false;
  product = new UpdateProductInputDto();
  companies: GetCompanyOutputDto[];
  generics: GetGenericOutputDto[];
  keyword = '';
  // roles: RoleDto[] = [];
  // checkedRolesMap: { [key: string]: boolean } = {};
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    private _companyService: CompanyServiceProxy,
    private _genericService: MedicineGenericServiceProxy,
    public bsModalRef: BsModalRef,
    private router: Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._productService.getProductById(this.id).subscribe((result) => {
      this.product = result;
    });

    this._companyService.getAllCompanies(this.keyword).subscribe((result) => {
        this.companies = result;
    });

    this._genericService.getAllGenerics(this.keyword).subscribe((result) => {
        this.generics = result;
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

    this._productService
      .update(this.product)
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

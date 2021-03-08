import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
import { CompanyServiceProxy, CreateProductInputDto, GetCompanyOutputDto, ProductServiceProxy, RoleDto } from '@shared/service-proxies/service-proxies';
import { result } from 'lodash-es';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-product-dialog',
  templateUrl: './create-product-dialog.component.html',
  styleUrls: ['./create-product-dialog.component.css']
  //changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateProductDialogComponent extends AppComponentBase implements OnInit {

  saving = false;
  product = new CreateProductInputDto();
  companies: GetCompanyOutputDto[];
  companyId: number;
  keyword: string = null;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    private _companyService: CompanyServiceProxy,
    public bsModalRef: BsModalRef,
    private ref: ChangeDetectorRef
  ) {
    super(injector);

    this._companyService.getAllCompanies(this.keyword).subscribe( (result) => {
      this.companies = result;
      this.ref.markForCheck();
      // console.log(JSON.stringify(this.companies));
    });


    //Setting CompanyId
    if (this.companyId == undefined) {
      this.companyId = 0;
      this.ref.markForCheck();
      console.log(this.companyId);
    }

  }

  ngOnInit(): void {

    //console.log ( this.product.companyId );

    console.log("Company ID Received: " + this.companyId);
    // this.product.companyId = this.companyId;
    // this.product.isActive = true;

    // this._userService.getRoles().subscribe((result) => {
    //   this.roles = result.items;
    //   this.setInitialRolesStatus();
    // });
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

    this._productService
      .create(this.product)
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

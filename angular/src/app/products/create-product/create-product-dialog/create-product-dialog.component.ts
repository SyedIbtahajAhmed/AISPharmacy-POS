import { ChangeDetectionStrategy, ChangeDetectorRef, Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';
import {
    CompanyServiceProxy,
    CreateProductInputDto,
    GetCompanyOutputDto, GetGenericOutputDto, GetProductOutputDto,
    MedicineGenericServiceProxy,
    ProductServiceProxy,
    RoleDto
} from '@shared/service-proxies/service-proxies';
import { result } from 'lodash-es';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import {PagedListingComponentBase, PagedRequestDto} from '../../../../shared/paged-listing-component-base';
import {type} from 'os';

@Component({
    selector: 'app-create-product-dialog',
    templateUrl: './create-product-dialog.component.html',
    styleUrls: ['./create-product-dialog.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateProductDialogComponent extends PagedListingComponentBase<GetProductOutputDto> implements OnInit {

  saving = false;
  product = new CreateProductInputDto();
  companies: GetCompanyOutputDto[];
  generics: GetGenericOutputDto[];
  companyId: number;
  genericId: number;
  keyword: string = null;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _productService: ProductServiceProxy,
    private _genericService: MedicineGenericServiceProxy,
    private _companyService: CompanyServiceProxy,
    public bsModalRef: BsModalRef,
    private ref: ChangeDetectorRef
  ) {
    super(injector);

    this._companyService.getAllCompanies(this.keyword).subscribe( (data) => {
      this.companies = data;
      this.ref.markForCheck();
      console.log(JSON.stringify(this.companies));
    });

    this._genericService.getAllGenerics(this.keyword).subscribe((data) => {
        this.generics = data;
        this.ref.markForCheck();
        console.log(JSON.stringify(this.generics));
    });

  }

  ngOnInit(): void {

    //console.log ( this.product.companyId );

      // Setting CompanyId
      if (this.companyId === undefined) {
          this.companyId = 0;
          // this.ref.markForCheck();
          console.log('Company Id Changed To: ' + this.companyId);
      }
      if (this.genericId === undefined) {
          this.genericId = 0;
          // this.ref.markForCheck();
          console.log('Generic Id Changed To: ' + this.genericId);
      }

      console.log('Company Id Received From Products Of Company: ' + this.companyId);
      console.log('Generic Id Received From Products Of Company: ' + this.genericId);
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

    OnSearch(event: any) {
        this.keyword = event.target.value;
        this.getDataPage(1);
        console.log(this.keyword);
    }

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

    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        throw new Error('Method not implemented.');
    }
    protected delete(entity: GetProductOutputDto): void {
        throw new Error('Method not implemented.');
    }

  // SelectCompanyDropdown(event: any) {
  //   this.companyId = event.target.value;
  //   console.log(this.companyId);
  // }

}

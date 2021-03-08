import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CompanyServiceProxy, CreateCompanyInputDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-create-company',
  templateUrl: './create-company.component.html',
  styleUrls: ['./create-company.component.css']
})
export class CreateCompanyComponent extends AppComponentBase implements OnInit {

  saving = false;
  company = new CreateCompanyInputDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _companyService: CompanyServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
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

    this._companyService
      .create(this.company)
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


}

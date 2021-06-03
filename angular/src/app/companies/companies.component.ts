import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { CompanyServiceProxy, CreateCompanyInputDto, GetCompanyOutputDto, UpdateCompanyInputDto } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateCompanyComponent } from './create-company/create-company.component';
import { EditCompanyComponent } from './edit-company/edit-company.component';
import { ProductsofCompanyComponent } from './productsof-company/productsof-company.component';



class PagedCompaniesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css'],
  animations: [appModuleAnimation()]
})
export class CompaniesComponent extends PagedListingComponentBase<GetCompanyOutputDto> {
  companies: GetCompanyOutputDto[] = [];
  keyword = '';
  totalCompanies: number;
  advancedFiltersVisible = false;
  selectValue = 10;

  constructor(
    injector: Injector,
    private _companyService: CompanyServiceProxy,
    private _modalService: BsModalService,
  ) {
    super(injector);

  }

  createCompany(): void {
    this.showCreateOrEditCompanyDialog();
  }

  editCompany(company: UpdateCompanyInputDto): void {
    this.showCreateOrEditCompanyDialog(company.id);
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
    request: PagedCompaniesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._companyService
      .getAllCompanies(
        request.keyword
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: any) => {
        this.companies = result;
        this.totalCompanies = this.companies.length;
        this.showPaging(result, pageNumber);
      });
  }

  protected deleteCompany(company: number): void {
    abp.message.confirm(
      this.l('Company ' + company + ' Will Be Deleted!'),
      undefined,
      (result: boolean) => {
        if (result) {
          this._companyService.delete(company).subscribe(() => {
            abp.notify.success(this.l('Successfully Deleted'));
            this.refresh();
          });
        }
      }
    );
  }

  private SeeProducts(companyId?: number): void {
      console.log(companyId);
    let productsOfCompanyDialog: BsModalRef;
    if (companyId != null) {
        productsOfCompanyDialog = this._modalService.show(
        ProductsofCompanyComponent,
        {
          class: 'modal-xl',
          initialState: {
              companyId: companyId,
          },
        }
      );
    } else {
      abp.message.error(
        this.l('Company Does Not Exist.\nTry Adding First!')
      );
    }

      productsOfCompanyDialog.content.onSave.subscribe(() => {
          this.refresh();
      });
  }



  protected delete(entity: GetCompanyOutputDto): void {
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

  private showCreateOrEditCompanyDialog(id?: number): void {
    let createOrEditCompanyDialog: BsModalRef;
    if (!id) {
      createOrEditCompanyDialog = this._modalService.show(
        CreateCompanyComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditCompanyDialog = this._modalService.show(
        EditCompanyComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCompanyDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}

import { Component, inject, OnInit } from '@angular/core';
import { ComponentCardComponent } from '../../../shared/components/common/component-card/component-card.component';
import { PageBreadcrumbComponent } from '../../../shared/components/common/page-breadcrumb/page-breadcrumb.component';
import { BasicTableThreeComponent } from '../../../shared/components/tables/basic-tables/basic-table-three/basic-table-three.component';
import { HttpcommonService } from '../../../services/common/httpcommon.service';
import { Customer_API_URL } from '../../../const/apiurl';

@Component({
  selector: 'app-customers',
  imports: [ ComponentCardComponent,
      PageBreadcrumbComponent,BasicTableThreeComponent],
  templateUrl: './customers.component.html',
  styleUrl: './customers.component.css',
})
export class CustomersComponent implements OnInit {

  private httpService = inject(HttpcommonService);
  tableData: any[] = [];
  errorMessage: string = '';
  ngOnInit(): void {
    
    // Simulated fetch from a local JSON file or API
    this.loadCustomers();
  }
   loadCustomers(): void {
    this.httpService.getAll(`${Customer_API_URL}/?isDeleted=false`).subscribe({
      next: (data : any) => {
        console.log('Fetched customer data:', data.content.data);  
        this.tableData = data.content.data;
      },
      error: (err) => {
        this.errorMessage = err.message;
      }
    });
  }
}

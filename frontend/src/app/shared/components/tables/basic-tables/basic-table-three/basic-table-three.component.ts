import { CommonModule } from '@angular/common';
import { Component, OnInit,Input, SimpleChanges, OnChanges } from '@angular/core';
import { ButtonComponent } from '../../../ui/button/button.component';
import { TableDropdownComponent } from '../../../common/table-dropdown/table-dropdown.component';
import { BadgeComponent } from '../../../ui/badge/badge.component';
import { MatTableModule } from '@angular/material/table'; // Must be sub-packaged path!

interface Transaction {
  image: string;
  action: string;
  date: string;
  amount: string;
  category: string;
  status: "Success" | "Pending" | "Failed";
}

@Component({
  selector: 'app-basic-table-three',
  imports: [
    CommonModule,
    ButtonComponent,
     MatTableModule
  ],
  templateUrl: './basic-table-three.component.html',
  styles: ``
})
export class BasicTableThreeComponent implements OnInit, OnChanges {

  // Type definition for the transaction data

// Holds raw data from the JSON file
    @Input() tableData: any[] = [];
    @Input() title: string = '';
  
  // Holds extracted column keys dynamically
  columns: string[] = [];
  ngOnInit(): void {
    console.log('CommonTableData received:', this.tableData);

    // Extract columns safely if data is available
    if (this.tableData.length > 0) {
      this.columns = Object.keys(this.tableData[0]); 
      // Output will be: ['id', 'name', 'role', 'status']
    }
  }

  currentPage = 1;
  itemsPerPage = 5;
  ngOnChanges(changes: SimpleChanges) { 
       if (changes['tableData']?.currentValue?.length) {
    this.columns = Object.keys(this.tableData[0]);
    this.currentPage = 1; // reset page when new data arrives
  
  }
  }
  get totalPages(): number {
    return Math.ceil(this.tableData.length / this.itemsPerPage);
  }

  get currentItems(): any[] {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    console.log('Current Items:',start ,this.tableData.slice(start, start + this.itemsPerPage));
    return this.tableData.slice(start, start + this.itemsPerPage);
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  handleViewMore(item: Transaction) {
    // logic here
    console.log('View More:', item);
  }

  handleDelete(item: Transaction) {
    // logic here
    console.log('Delete:', item);
  }
  onSearch(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
   // this.searchSubject.next(value);
  }

  getBadgeColor(status: string): 'success' | 'warning' | 'error' {
    if (status === 'Success') return 'success';
    if (status === 'Pending') return 'warning';
    return 'error';
  }
}

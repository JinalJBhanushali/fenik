import { CommonModule } from '@angular/common';
import { Component, OnInit,Input } from '@angular/core';
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
export class BasicTableThreeComponent implements OnInit {

  // Type definition for the transaction data

// Holds raw data from the JSON file
  tableData: any[] = [];
  
  // Holds extracted column keys dynamically
  columns: string[] = [];
  @Input() CommonTableData: any;
  ngOnInit(): void {
    // Simulated fetch from a local JSON file or API
    this.tableData = this.CommonTableData;

    // Extract columns safely if data is available
    if (this.tableData.length > 0) {
      this.columns = Object.keys(this.tableData[0]); 
      // Output will be: ['id', 'name', 'role', 'status']
    }
  }
  transactionData: Transaction[] = [
    {
      image: "/images/brand/brand-08.svg", // Path or URL for the image
      action: "Bought PYPL", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-07.svg", // Path or URL for the image
      action: "Bought AAPL", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Pending",
    },
    {
      image: "/images/brand/brand-15.svg", // Path or URL for the image
      action: "Sell KKST", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-02.svg", // Path or URL for the image
      action: "Bought FB", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-10.svg", // Path or URL for the image
      action: "Sell AMZN", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Failed",
    },
    {
      image: "/images/brand/brand-08.svg", // Path or URL for the image
      action: "Bought PYPL", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-07.svg", // Path or URL for the image
      action: "Bought AAPL", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Pending",
    },
    {
      image: "/images/brand/brand-15.svg", // Path or URL for the image
      action: "Sell KKST", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-02.svg", // Path or URL for the image
      action: "Bought FB", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-10.svg", // Path or URL for the image
      action: "Sell AMZN", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Failed",
    },
    {
      image: "/images/brand/brand-08.svg", // Path or URL for the image
      action: "Bought PYPL", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-07.svg", // Path or URL for the image
      action: "Bought AAPL", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Pending",
    },
    {
      image: "/images/brand/brand-15.svg", // Path or URL for the image
      action: "Sell KKST", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-02.svg", // Path or URL for the image
      action: "Bought FB", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Success",
    },
    {
      image: "/images/brand/brand-10.svg", // Path or URL for the image
      action: "Sell AMZN", // Action description
      date: "Nov 23, 01:00 PM", // Date and time of the transaction
      amount: "$2,567.88", // Transaction amount
      category: "Finance", // Category of the transaction
      status: "Failed",
    },
  ]

  currentPage = 1;
  itemsPerPage = 5;

  get totalPages(): number {
    return Math.ceil(this.transactionData.length / this.itemsPerPage);
  }

  get currentItems(): Transaction[] {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    return this.transactionData.slice(start, start + this.itemsPerPage);
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

  getBadgeColor(status: string): 'success' | 'warning' | 'error' {
    if (status === 'Success') return 'success';
    if (status === 'Pending') return 'warning';
    return 'error';
  }
}

import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { Product } from '../../models/product';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {
  dataSaved = false;
  productForm: any;
  allProducts: Observable<Product[]>;
  dataSource: MatTableDataSource<Product>;
  displayedColumns: string[] = ['Name', 'Code', 'Price'];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private productService: ProductsService,
    private formbulider: FormBuilder
  ) {

  }

  ngOnInit() {
    this.createProductForm();
    this.loadAlProducts();
  }

  createProductForm() {
    this.productForm = this.formbulider.group({
      Name: ['', [Validators.required]],
      Code: ['', [Validators.required]],
      Price: ['', [Validators.required]]
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  loadAlProducts() {
    this.productService.getProducts().subscribe(data => {
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  submit() {
    this.dataSaved = false;
    const product = this.productForm.value;
    this.createProduct(product);
    this.productForm.reset();
  }

  createProduct(product: Product) {

    this.productService.addProduct(product).subscribe(el => {
      this.dataSaved = true;
      this.resetForm();
    });
  }

  resetForm() {
    this.productForm.reset();
    this.dataSaved = false;
    this.loadAlProducts();
  }
}

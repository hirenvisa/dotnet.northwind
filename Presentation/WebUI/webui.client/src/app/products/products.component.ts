import { Component } from '@angular/core';
import { ProductsClient, ProductsListVm } from '../northwind-traders-api';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  public vm: ProductsListVm = new ProductsListVm();

  constructor(private client: ProductsClient) {
    client.getAll().subscribe(result => {
      this.vm = result
    }, error => console.error(error));
  }
}

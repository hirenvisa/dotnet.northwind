import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomersClient, ProductsClient } from './northwind-traders-api';


import { CustomersComponent } from './customers/customers.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';

import { ModalModule } from 'ngx-bootstrap/modal';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ProductsComponent } from './products/products.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    CustomerDetailComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    ModalModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    CustomersClient,
    ProductsClient,
    BsModalService
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

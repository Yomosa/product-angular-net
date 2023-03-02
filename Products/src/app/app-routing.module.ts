import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './components/Products/add-product/add-product.component';
import { EditProductComponent } from './components/Products/edit-product/edit-product.component';
import { ProductsListComponent } from './components/Products/products-list/products-list.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsListComponent
  },
  {
    path: 'products',
    component: ProductsListComponent
  },
  {
    path: 'products/add',
    component: AddProductComponent
  },
  {
    path: 'products/edit/:id',
    component: EditProductComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit {

  products: Product[] = [
    {
      id: '1',
      name: 'Phone',
      description: 'For calling',
      brand: 'Samsung',
      price: 1200
    },
    {
      id: '2',
      name: 'Chips',
      description: 'For when your hungry',
      brand: 'Lays',
      price: 3.5
    },
    {
      id: '3',
      name: 'Coffee',
      description: 'For when you want to drink something',
      brand: 'Nespresso',
      price: 10
    },
  ];

  constructor() {}

  ngOnInit(): void {
  }
}

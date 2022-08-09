import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl = `${environment.apiUrl}product`;
  constructor(
    protected _http: HttpClient
    ) 
  {
    
  }

  getProducts(): Observable<Product[]> {
    return this._http.get<Product[]>(this.baseUrl);
  }

  addProduct(product: Product) {
    return this._http.post<Product>(this.baseUrl, product);
  }
}

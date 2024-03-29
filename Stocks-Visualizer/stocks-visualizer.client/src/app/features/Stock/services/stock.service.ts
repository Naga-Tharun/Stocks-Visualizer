import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddStockRequest } from '../models/add-stock-request.model';
import { Stock } from '../models/stock.model';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { StockView } from '../models/stock-view.model';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http : HttpClient) { }

  addStock(data : AddStockRequest) : Observable<Stock> {
    return this.http.post<Stock>(`${environment.apiBaseUrl}/api/Stocks`, data);
  }

  getAllStocks() : Observable<Stock[]> {
    return this.http.get<Stock[]>(`${environment.apiBaseUrl}/api/Stocks`);
  }

  getStock(data: string): Observable<StockView> {
    return this.http.get<StockView>(`${environment.apiBaseUrl}/api/Stocks/${data}`);
  }
}

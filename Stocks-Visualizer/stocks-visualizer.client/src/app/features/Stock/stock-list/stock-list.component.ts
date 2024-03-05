import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Stock } from '../models/stock.model';
import { StockService } from '../services/stock.service';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html',
  styleUrl: './stock-list.component.css'
})
export class StockListComponent implements OnInit{
  stocks$?: Observable<Stock[]>;


  constructor(private stockService : StockService) {

  }

  ngOnInit(): void {
    this.stocks$ = this.stockService.getAllStocks();
  }
}

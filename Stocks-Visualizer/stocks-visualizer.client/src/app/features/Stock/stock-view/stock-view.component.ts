import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { StockService } from '../services/stock.service';
import { ViewStock } from '../models/view-stock.model';

@Component({
  selector: 'app-stock-view',
  templateUrl: './stock-view.component.html',
  styleUrl: './stock-view.component.css'
})
export class StockViewComponent implements OnInit,OnDestroy {
  id: string | null = null;
  stock?: ViewStock;
  paramSubscription?: Subscription;
  constructor(private route: ActivatedRoute, private stockService: StockService) {

  }
  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        if (this.id) {
          this.stockService.getStock(this.id).subscribe({
            next: (response) => {
              this.stock = response;
            }
          })
        }
      }
    });
  }


}

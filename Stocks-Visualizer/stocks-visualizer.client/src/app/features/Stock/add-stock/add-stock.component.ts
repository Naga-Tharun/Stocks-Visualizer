import { Component, OnDestroy } from '@angular/core';
import { StockService } from '../services/stock.service';
import { Router } from '@angular/router';
import { AddStockRequest } from '../models/add-stock-request.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-stock',
  templateUrl: './add-stock.component.html',
  styleUrl: './add-stock.component.css'
})
export class AddStockComponent implements OnDestroy {
 
  model: AddStockRequest;

  private addStockSubscription? : Subscription;

  constructor(private stockService : StockService, private router : Router) {
    this.model = {
      symbol : '',
      interval : '',
      timeFrame : '',
    }
  }

  onFormSubmit() {
    this.addStockSubscription = this.stockService.addStock(this.model)
    .subscribe({
      next: (response) => {
        this.router.navigateByUrl('/');
      },
    });
    console.log(this.model);
  }

  ngOnDestroy(): void {
    this.addStockSubscription?.unsubscribe();
  }
}

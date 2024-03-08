import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStockComponent } from './features/Stock/add-stock/add-stock.component';
import { StockListComponent } from './features/Stock/stock-list/stock-list.component';
import { StockViewComponent } from './features/Stock/stock-view/stock-view.component';
import { CandlestickChartComponent } from './features/Stock/candlestick-chart/candlestick-chart.component';

const routes: Routes = [
  {
    path: 'stocks/addstock',
    component: AddStockComponent
  },
  {
    path: 'stocks',
    component: StockListComponent
  },
  {
    path: 'stocks/view/:id',
    component: StockViewComponent
  },
  {
    path: 'test',
    component: CandlestickChartComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

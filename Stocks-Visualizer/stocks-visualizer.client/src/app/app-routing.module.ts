import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStockComponent } from './features/Stock/add-stock/add-stock.component';
import { StockListComponent } from './features/Stock/stock-list/stock-list.component';
import { ViewStockComponent } from './features/Stock/view-stock/view-stock.component';

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
    path: 'stocks/:id',
    component: ViewStockComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

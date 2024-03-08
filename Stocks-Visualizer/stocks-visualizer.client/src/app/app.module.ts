import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { AddStockComponent } from './features/Stock/add-stock/add-stock.component';
import { StockListComponent } from './features/Stock/stock-list/stock-list.component';
import { FormsModule } from '@angular/forms';
import { StockViewComponent } from './features/Stock/stock-view/stock-view.component';
import ChartsModule from 'chart.js/auto';
import { CandlestickChartComponent } from './features/Stock/candlestick-chart/candlestick-chart.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AddStockComponent,
    StockListComponent,
    AddStockComponent,
    StockListComponent,
    StockViewComponent,
    CandlestickChartComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

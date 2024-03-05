import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { AddStockComponent } from './features/Stock/add-stock/add-stock.component';
import { StockListComponent } from './features/Stock/stock-list/stock-list.component';
import { FormsModule } from '@angular/forms';
import { ViewStockComponent } from './features/Stock/view-stock/view-stock.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AddStockComponent,
    StockListComponent,
    AddStockComponent,
    StockListComponent,
    ViewStockComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

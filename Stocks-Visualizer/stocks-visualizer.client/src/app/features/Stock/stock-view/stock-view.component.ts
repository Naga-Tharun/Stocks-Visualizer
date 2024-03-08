import { Component, OnDestroy, OnInit, numberAttribute } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { StockService } from '../services/stock.service';
import { StockView } from '../models/stock-view.model';
import Chart from 'chart.js/auto';
import { ChartOptions, ChartType } from 'chart.js/auto';

import 'chartjs-chart-financial';

import ApexCharts from 'apexcharts'

@Component({
  selector: 'app-stock-view',
  templateUrl: './stock-view.component.html',
  styleUrl: './stock-view.component.css'
})
export class StockViewComponent implements OnInit,OnDestroy {
  id: string | null = null;
  stock?: StockView;
  paramSubscription?: Subscription;
  constructor(private route: ActivatedRoute, private stockService: StockService) {

  }
  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
  }

  async ngOnInit(): Promise<void> {
    this.paramSubscription = await this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        if (this.id) {
          this.stockService.getStock(this.id).subscribe({
            next: (response) => {
              this.stock = response;
              console.log(this.stock);

              const combinedData = this.stock?.openDate.map((date, index) => {
                return {
                  x: new Date(date),
                  y: [this.stock?.open[index], this.stock?.high[index], this.stock?.low[index], this.stock?.close[index]]
                };
              });
          
              // console.log(combinedData);
              // console.log(this.stock?.openDate);

              var options = {
                series: [{
                  name: 'candle',
                  type: 'candlestick',
                  data: combinedData
                }],
                chart: {
                height: 350,
                width: '70%',
                maxWidth: 800,
                type: 'candlestick',
                align: 'center'
                },
                title: {
                  text: 'CandleStick Chart',
                  align: 'left'
                },
                stroke: {
                  width: [3, 1]
                },
                xaxis: {
                  type: 'datetime'
                },
                yaxis: {
                  tooltip: {
                    enabled: true
                  },
                },
                responsive: [
                  {
                    breakpoint: 1000,
                    options: {
                      chart: {
                        width: '80%',
                      },
                    },
                  },
                ]
              };
          
              var chart = new ApexCharts(document.querySelector("#chartholder"), options);
              chart.render();
            }
          })
        }
      }
    });
  }
}

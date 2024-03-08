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
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        if (this.id) {
          this.stockService.getStock(this.id).subscribe({
            next: (response) => {
              this.stock = response;
              // console.log(this.stock);
              const combinedData = this.stock?.openDate.map((date, index) => {
                return {
                  x: new Date(date),
                  y: [this.stock?.open[index], this.stock?.high[index], this.stock?.low[index], this.stock?.close[index]]
                };
              });

              console.log(combinedData);
              // console.log(this.stock?.openDate);
              // Assuming you have the stock data in the variable 'data'
              const movingAverageData = calculateMovingAverage(combinedData, combinedData.length);

              var modifiedMovingAverageData = movingAverageData.map((value, index) => {
                return {
                  x: combinedData[index].x,
                  y: value
                };
              });

              modifiedMovingAverageData = movingAverageData.map((value, index) => ({
                x: combinedData[index].x,
                y: value,
              }))
              .sort((a, b) => a.x.getTime() - b.x.getTime());

              console.log(modifiedMovingAverageData);

              var options = {
                series: [{
                  name: 'candle',
                  type: 'candlestick',
                  data: combinedData
                },
                {
                  name: 'Moving Average',
                  type: 'line',
                  data: modifiedMovingAverageData,
                },],
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
          });
        }
      }
    });
  }
}

function calculateMovingAverage(data: {x: Date; y: (number | undefined)[];}[], period:number) {
  const closeValues = data.map((dataPoint) => dataPoint.y[3] || 0);
  const movingAverage: number[] = [];

  for (let i = 0; i < closeValues.length; i++) {
    const startIndex = Math.max(0, i - period + 1);
    const valuesToAverage = closeValues.slice(startIndex, i + 1);
    const average = valuesToAverage.reduce((sum, value) => sum + value, 0) / valuesToAverage.length;
    movingAverage.push(average);
  }
  // console.log(movingAverage);
  return movingAverage;
}

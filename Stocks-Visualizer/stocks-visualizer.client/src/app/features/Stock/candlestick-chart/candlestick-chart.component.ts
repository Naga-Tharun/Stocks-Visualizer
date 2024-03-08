// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-candlestick-chart',
//   templateUrl: './candlestick-chart.component.html',
//   styleUrl: './candlestick-chart.component.css'
// })
// export class CandlestickChartComponent {

// }

// candlestick-chart.component.ts

// candlestick-chart.component.ts

// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-candlestick-chart',
//   templateUrl: './candlestick-chart.component.html',
//   styleUrl: './candlestick-chart.component.css'
// })
// export class CandlestickChartComponent {
//   // Example Candlestick Data
//   candlestickData = [
//     ['Mon', 20, 28, 38, 45],
//     ['Tue', 31, 38, 55, 66],
//     ['Wed', 50, 55, 77, 80],
//     ['Thu', 77, 77, 66, 50],
//     ['Fri', 68, 66, 22, 15],
//   ];

//   // Example Candlestick Chart Options
//   chartOptions = {
//     legend: 'none',
//     candlestick: {
//       fallingColor: { strokeWidth: 0, fill: '#a52714' },
//       risingColor: { strokeWidth: 0, fill: '#0f9d58' },
//     },
//   };
// }


// import { Component } from '@angular/core';
// import { Chart } from 'chart.js';
// import 'chartjs-chart-financial';

// @Component({
//   selector: 'app-candlestick-chart',
//   templateUrl: './candlestick-chart.component.html',
//   styleUrl: './candlestick-chart.component.css'
// })
// export class CandlestickChartComponent {
//   constructor() {
//     // Example data for candlestick chart
//     const data = {
//       labels: ['Date 1', 'Date 2', 'Date 3', 'Date 4'],
//       datasets: [
//         {
//           label: 'Candlestick Chart',
//           data: [
//             { t: 'Date 1', o: 100, h: 120, l: 80, c: 110 },
//             { t: 'Date 2', o: 80, h: 90, l: 70, c: 85 },
//             { t: 'Date 3', o: 120, h: 130, l: 110, c: 125 },
//             { t: 'Date 4', o: 110, h: 115, l: 100, c: 105 },
//           ],
//         },
//       ],
//     };

//     // Get the canvas element
//     const ctx = document.getElementById('candlestickChart') as HTMLCanvasElement;

    
//     // Create the candlestick chart
//     new Chart(ctx, {
//       type: 'candlestick',
//       data: data,
//       options: {
//         // Add chart options as needed
//       },
//     });
//     console.log(data);
//   }
// }

// import { Component, AfterViewInit, OnInit } from '@angular/core';
// import { Chart,  LinearScale, PointElement, Tooltip, Legend, TimeScale, TimeSeriesScale } from 'chart.js';
// import 'chartjs-chart-financial';
// import 'chartjs-adapter-moment';
// import { OhlcElement, OhlcController, CandlestickElement, CandlestickController } from 'chartjs-chart-financial';
// Chart.register(OhlcElement, OhlcController, CandlestickElement, CandlestickController);
// Chart.register(LinearScale, PointElement, Tooltip, Legend, TimeScale, TimeSeriesScale); 

// @Component({
//   selector: 'app-candlestick-chart',
//   templateUrl: './candlestick-chart.component.html',
//   styleUrls: ['./candlestick-chart.component.css']
// })
// export class CandlestickChartComponent implements OnInit {
//   ngOnInit() {

//     // Get the canvas element
//     const canvas = document.getElementById('candlestickChart') as HTMLCanvasElement;

//     // Check if the canvas is accessible
//     if (!canvas) {
//       console.error('Canvas element not found');
//       return;
//     }

//     // Get the 2D context of the canvas
//     const ctx = canvas.getContext('2d');

//     // Check if the 2D context is available
//     if (!ctx) {
//       console.error('Unable to get 2D context for canvas');
//       return;
//     }

//     // Add some text to the canvas
//     ctx.font = '20px Arial';
//     ctx.fillStyle = 'black';
//     ctx.fillText('Hello, Canvas!', 50, 50);

//     // Example data for candlestick chart
//     const data = {
//       labels: ['Date 1', 'Date 2', 'Date 3', 'Date 4'],
//       datasets: [
//         {
//           label: 'Candlestick Chart',
//           data: [
//             { t: 'Date 1', o: 100, h: 120, l: 80, c: 110 },
//             { t: 'Date 2', o: 80, h: 90, l: 70, c: 85 },
//             { t: 'Date 3', o: 120, h: 130, l: 110, c: 125 },
//             { t: 'Date 4', o: 110, h: 115, l: 100, c: 105 },
//           ],
//         },
//       ],
//     };

//     // // Get the canvas element
//     // const ctx = document.getElementById('candlestickChart') as HTMLCanvasElement;

//     // Chart.register(OhlcElement, OhlcController, CandlestickElement, CandlestickController);

//     // Create the candlestick chart
//     var chart = new Chart(ctx, {
//       type: 'candlestick',
//       data: data,
//       options: {
//         // Add chart options as needed
//       },
//     });

    

//     // // Example data for bar chart
//     // const data = {
//     //   labels: ['Category 1', 'Category 2', 'Category 3', 'Category 4'],
//     //   datasets: [
//     //     {
//     //       label: 'Bar Chart',
//     //       data: [50, 70, 30, 90],
//     //       backgroundColor: ['red', 'green', 'blue', 'orange'],
//     //       borderColor: ['red', 'green', 'blue', 'orange'],
//     //       borderWidth: 1,
//     //     },
//     //   ],
//     // };

//     // // Create the bar chart
//     // new Chart(ctx, {
//     //   type: 'bar',
//     //   data: data,
//     //   // options: {
//     //   //   scales: {
//     //   //     y: {
//     //   //       beginAtZero: true,
//     //   //     },
//     //   //   },
//     //   // },
//     // });
//   }
// }



import { Component, AfterViewInit, OnInit } from '@angular/core';
import { Chart,  LinearScale, PointElement, Tooltip, Legend, TimeScale, TimeSeriesScale } from 'chart.js';
import 'chartjs-chart-financial';
import 'chartjs-adapter-moment';
import { OhlcElement, OhlcController, CandlestickElement, CandlestickController } from 'chartjs-chart-financial';
Chart.register(OhlcElement, OhlcController, CandlestickElement, CandlestickController);
Chart.register(LinearScale, PointElement, Tooltip, Legend, TimeScale, TimeSeriesScale); 

import ApexCharts from 'apexcharts'

@Component({
  selector: 'app-candlestick-chart',
  templateUrl: './candlestick-chart.component.html',
  styleUrls: ['./candlestick-chart.component.css']
})
export class CandlestickChartComponent implements OnInit {

  ngOnInit() {
    var options = {
      
      series: [{
      name: 'line',
      type: 'line',
      data: [
        {
          x: new Date(1538778600000),
          y: 6604
        }, {
          x: new Date(1538782200000),
          y: 6602
        }, {
          x: new Date(1538814600000),
          y: 6607
        }, {
          x: new Date(1538884800000),
          y: 6620
        }
      ]
    }, {
      name: 'candle',
      type: 'candlestick',
      data: [
        {
          x: new Date(1538778600000),
          y: [6629.81, 6650.5, 6623.04, 6633.33]
        },
        {
          x: new Date(1538780400000),
          y: [6632.01, 6643.59, 6620, 6630.11]
        },
        {
          x: new Date(1538782200000),
          y: [6630.71, 6648.95, 6623.34, 6635.65]
        },
        {
          x: new Date(1538784000000),
          y: [6635.65, 6651, 6629.67, 6638.24]
        },
        {
          x: new Date(1538785800000),
          y: [6638.24, 6640, 6620, 6624.47]
        },
        {
          x: new Date(1538787600000),
          y: [6624.53, 6636.03, 6621.68, 6624.31]
        },
        {
          x: new Date(1538789400000),
          y: [6624.61, 6632.2, 6617, 6626.02]
        },
        {
          x: new Date(1538791200000),
          y: [6627, 6627.62, 6584.22, 6603.02]
        },
        {
          x: new Date(1538793000000),
          y: [6605, 6608.03, 6598.95, 6604.01]
        },
        {
          x: new Date(1538794800000),
          y: [6604.5, 6614.4, 6602.26, 6608.02]
        },
        {
          x: new Date(1538796600000),
          y: [6608.02, 6610.68, 6601.99, 6608.91]
        },
        {
          x: new Date(1538798400000),
          y: [6608.91, 6618.99, 6608.01, 6612]
        },
        {
          x: new Date(1538800200000),
          y: [6612, 6615.13, 6605.09, 6612]
        },
        {
          x: new Date(1538802000000),
          y: [6612, 6624.12, 6608.43, 6622.95]
        },
        {
          x: new Date(1538803800000),
          y: [6623.91, 6623.91, 6615, 6615.67]
        },
        {
          x: new Date(1538805600000),
          y: [6618.69, 6618.74, 6610, 6610.4]
        },
        {
          x: new Date(1538807400000),
          y: [6611, 6622.78, 6610.4, 6614.9]
        },
        {
          x: new Date(1538809200000),
          y: [6614.9, 6626.2, 6613.33, 6623.45]
        },
        {
          x: new Date(1538811000000),
          y: [6623.48, 6627, 6618.38, 6620.35]
        },
        {
          x: new Date(1538812800000),
          y: [6619.43, 6620.35, 6610.05, 6615.53]
        },
        {
          x: new Date(1538814600000),
          y: [6615.53, 6617.93, 6610, 6615.19]
        },
        {
          x: new Date(1538816400000),
          y: [6615.19, 6621.6, 6608.2, 6620]
        },
        {
          x: new Date(1538818200000),
          y: [6619.54, 6625.17, 6614.15, 6620]
        },
        {
          x: new Date(1538820000000),
          y: [6620.33, 6634.15, 6617.24, 6624.61]
        },
        {
          x: new Date(1538821800000),
          y: [6625.95, 6626, 6611.66, 6617.58]
        },
        {
          x: new Date(1538823600000),
          y: [6619, 6625.97, 6595.27, 6598.86]
        },
        {
          x: new Date(1538825400000),
          y: [6598.86, 6598.88, 6570, 6587.16]
        },
        {
          x: new Date(1538827200000),
          y: [6588.86, 6600, 6580, 6593.4]
        },
        {
          x: new Date(1538829000000),
          y: [6593.99, 6598.89, 6585, 6587.81]
        },
        {
          x: new Date(1538830800000),
          y: [6587.81, 6592.73, 6567.14, 6578]
        },
        {
          x: new Date(1538832600000),
          y: [6578.35, 6581.72, 6567.39, 6579]
        },
        {
          x: new Date(1538834400000),
          y: [6579.38, 6580.92, 6566.77, 6575.96]
        },
        {
          x: new Date(1538836200000),
          y: [6575.96, 6589, 6571.77, 6588.92]
        },
        {
          x: new Date(1538838000000),
          y: [6588.92, 6594, 6577.55, 6589.22]
        },
        {
          x: new Date(1538839800000),
          y: [6589.3, 6598.89, 6589.1, 6596.08]
        },
        {
          x: new Date(1538841600000),
          y: [6597.5, 6600, 6588.39, 6596.25]
        },
        {
          x: new Date(1538843400000),
          y: [6598.03, 6600, 6588.73, 6595.97]
        },
        {
          x: new Date(1538845200000),
          y: [6595.97, 6602.01, 6588.17, 6602]
        },
        {
          x: new Date(1538847000000),
          y: [6602, 6607, 6596.51, 6599.95]
        },
        {
          x: new Date(1538848800000),
          y: [6600.63, 6601.21, 6590.39, 6591.02]
        },
        {
          x: new Date(1538850600000),
          y: [6591.02, 6603.08, 6591, 6591]
        },
        {
          x: new Date(1538852400000),
          y: [6591, 6601.32, 6585, 6592]
        },
        {
          x: new Date(1538854200000),
          y: [6593.13, 6596.01, 6590, 6593.34]
        },
        {
          x: new Date(1538856000000),
          y: [6593.34, 6604.76, 6582.63, 6593.86]
        },
        {
          x: new Date(1538857800000),
          y: [6593.86, 6604.28, 6586.57, 6600.01]
        },
        {
          x: new Date(1538859600000),
          y: [6601.81, 6603.21, 6592.78, 6596.25]
        },
        {
          x: new Date(1538861400000),
          y: [6596.25, 6604.2, 6590, 6602.99]
        },
        {
          x: new Date(1538863200000),
          y: [6602.99, 6606, 6584.99, 6587.81]
        },
        {
          x: new Date(1538865000000),
          y: [6587.81, 6595, 6583.27, 6591.96]
        },
        {
          x: new Date(1538866800000),
          y: [6591.97, 6596.07, 6585, 6588.39]
        },
        {
          x: new Date(1538868600000),
          y: [6587.6, 6598.21, 6587.6, 6594.27]
        },
        {
          x: new Date(1538870400000),
          y: [6596.44, 6601, 6590, 6596.55]
        },
        {
          x: new Date(1538872200000),
          y: [6598.91, 6605, 6596.61, 6600.02]
        },
        {
          x: new Date(1538874000000),
          y: [6600.55, 6605, 6589.14, 6593.01]
        },
        {
          x: new Date(1538875800000),
          y: [6593.15, 6605, 6592, 6603.06]
        },
        {
          x: new Date(1538877600000),
          y: [6603.07, 6604.5, 6599.09, 6603.89]
        },
        {
          x: new Date(1538879400000),
          y: [6604.44, 6604.44, 6600, 6603.5]
        },
        {
          x: new Date(1538881200000),
          y: [6603.5, 6603.99, 6597.5, 6603.86]
        },
        {
          x: new Date(1538883000000),
          y: [6603.85, 6605, 6600, 6604.07]
        },
        {
          x: new Date(1538884800000),
          y: [6604.98, 6606, 6604.07, 6606]
        },
      ]
    }],
      chart: {
      height: 350,
      type: 'line',
    },
    title: {
      text: 'CandleStick Chart',
      align: 'left'
    },
    stroke: {
      width: [3, 1]
    },
    tooltip: {
      shared: true,
      custom: [function({seriesIndex, dataPointIndex, w}: { seriesIndex: number, dataPointIndex: number, w: any }) {
        return w.globals.series[seriesIndex][dataPointIndex]
      }, function({ seriesIndex, dataPointIndex, w }: { seriesIndex: number, dataPointIndex: number, w: any }) : string {
        var o = w.globals.seriesCandleO[seriesIndex][dataPointIndex]
        var h = w.globals.seriesCandleH[seriesIndex][dataPointIndex]
        var l = w.globals.seriesCandleL[seriesIndex][dataPointIndex]
        var c = w.globals.seriesCandleC[seriesIndex][dataPointIndex]
        return (
          '<div class="apexcharts-tooltip-candlestick">' +
          '<div>Open: <span class="value">' +
          o +
          '</span></div>' +
          '<div>High: <span class="value">' +
          h +
          '</span></div>' +
          '<div>Low: <span class="value">' +
          l +
          '</span></div>' +
          '<div>Close: <span class="value">' +
          c +
          '</span></div>' +
          '</div>'
        )
      }]
    },
    xaxis: {
      type: 'datetime'
    }
    };

    var chart = new ApexCharts(document.querySelector("#chartholder"), options);
    chart.render();
  }
}
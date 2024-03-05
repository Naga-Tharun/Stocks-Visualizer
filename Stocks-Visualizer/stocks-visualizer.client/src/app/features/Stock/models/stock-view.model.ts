export interface StockView {
  open: Float32Array;
  close: Float32Array;
  high: Float32Array;
  low: Float32Array;
  openDate: Date[];
  symbol: string;
  interval: string;
  timeZone: string;
}

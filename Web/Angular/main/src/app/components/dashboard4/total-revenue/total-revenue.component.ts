import { Component, ViewChild } from '@angular/core';
import {
  ApexChart,
  ChartComponent,
  ApexDataLabels,
  ApexPlotOptions,
  ApexLegend,
  ApexTooltip,
  ApexNonAxisChartSeries,
  ApexResponsive,
  NgApexchartsModule,
} from 'ng-apexcharts';
import { MaterialModule } from 'src/app/material.module';
import { TablerIconsModule } from 'angular-tabler-icons';
export interface totalrevenueChart {
  series: ApexNonAxisChartSeries | any;
  chart: ApexChart | any;
  responsive: ApexResponsive[] | any;
  labels: any;
  tooltip: ApexTooltip | any;
  legend: ApexLegend | any;
  colors: string[] | any;
  stroke: any;
  dataLabels: ApexDataLabels | any;
  plotOptions: ApexPlotOptions | any;
}
@Component({
  selector: 'app-total-revenue',
  standalone: true,
  imports: [NgApexchartsModule, MaterialModule, TablerIconsModule],
  templateUrl: './total-revenue.component.html',
})
export class AppTotalRevenueComponent {
  @ViewChild('chart') chart: ChartComponent = Object.create(null);

  public totalrevenueChart!: Partial<totalrevenueChart> | any;

  constructor() {
    this.totalrevenueChart = {
      series: [
        {
          name: '2025',
          data: [
            800000, 1200000, 1400000, 1300000, 1200000, 1400000, 1300000,
            1300000, 1200000,
          ],
        },
        {
          name: '2024',
          data: [
            200000, 400000, 500000, 300000, 400000, 500000, 300000, 300000,
            400000,
          ],
        },
        {
          name: '2023',
          data: [
            100000, 200000, 400000, 600000, 200000, 400000, 600000, 600000,
            200000,
          ],
        },
      ],
      chart: {
        fontFamily: 'inherit',
        type: 'bar',
        height: 340,
        stacked: true,
        offsetX: -15,
        toolbar: {
          show: false,
        },
        zoom: {
          enabled: true,
        },
      },
      grid: {
        borderColor: 'rgba(0,0,0,0.1)',
        strokeDashArray: 3,
      },
      colors: ['var(--mat-sys-primary)', 'var(--mat-sys-secondary)', '#F8285A'],
      responsive: [
        {
          breakpoint: 480,
          options: {
            legend: {
              position: 'bottom',
              offsetX: -10,
              offsetY: 0,
            },
          },
        },
      ],
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '15%',
          borderRadius: 6,
        },
      },
      dataLabels: {
        enabled: false,
      },
      xaxis: {
        categories: [
          'Jan',
          'Feb',
          'Mar',
          'Apr',
          'May',
          'Jun',
          'Jul',
          'Aug',
          'Sept',
        ],
        labels: {
          style: {
            colors: '#a1aab2',
          },
        },
      },
      yaxis: {
        labels: {
          style: {
            colors: '#a1aab2',
          },
        },
      },
      tooltip: {
        theme: 'dark',
      },
      legend: {
        show: false,
      },
      fill: {
        opacity: 1,
      },
    };
  }
}

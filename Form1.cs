using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace it8
{
  public partial class Form1 : Form
  {
    
    public Form1()
    {
      InitializeComponent();
    }
    Chart Chart;
    private double XMin =1;
    private double XMax = 10;
    private double Step = 1 ;
    private double[] x;
    private double[] y;
    
    private void CalcFunction()
    {
      int count = (int)Math.Ceiling((XMax - XMin) / Step)
      + 1;
      x = new double[count];
      y = new double[count];
      
      for (int i = 0; i < count; i++)
      {
        x[i] = XMin + Step * i;
        y[i] = (Math.Sqrt(1 + Math.Pow(Math.Exp(x[i]), Math.Sqrt(x[i])) + Math.Cos(Math.Pow(x[i], 2))) / (Math.Abs(1 - Math.Pow(Math.Sin(x[i]), 3))) + Math.Log(Math.Abs(2 * x[i])));
       

      }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      CreateChart();

      CalcFunction();

      Chart.Series[0].Points.DataBindXY(x, y);
    


    }

    private void CreateChart()
    {
      // Создаёмновыйэлементуправления Chart
      Chart = new Chart();
      // Помещаем его на форму
      Chart.Parent = this;
      // Задаём размеры элемента
      Chart.SetBounds(10, 10, ClientSize.Width - 20,
      ClientSize.Height - 20);

      // Создаём новую область для построения графика
      ChartArea area = new ChartArea();
      // Даём ей имя (чтобы потом добавлять графики)
      area.Name = "myGraph";
      // Задаём левую и правую границы оси X
      area.AxisX.Minimum = XMin;
      area.AxisX.Maximum = XMax;
      // Определяемшагсетки
      area.AxisX.MajorGrid.Interval = Step;
      // Добавляем область в диаграмму
      Chart.ChartAreas.Add(area);

      // Создаём объект для первого графика
      Series series1 = new Series();
      // Ссылаемся на область для построения графика
      series1.ChartArea = "myGraph";
      // Задаём тип графика - сплайны
      series1.ChartType = SeriesChartType.Spline;
      // Указываем ширину линии графика
      series1.BorderWidth = 3;
      // Название графика для отображения в легенде
      series1.LegendText = "функция";
      // Добавляем в список графиков диаграммы
      Chart.Series.Add(series1);

      // Создаём легенду, которая будет показывать названия
      Legend legend = new Legend();
      Chart.Legends.Add(legend);
    }
  }
}
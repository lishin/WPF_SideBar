using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SidebarExample
{
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();
        private readonly string[] _quotes = new string[]
        {
            "生活就像骑自行车。要保持平衡就要保持运动。",
            "每一个不曾起舞的日子，都是对生命的辜负。",
            "我思故我在。",
            "这是最好的时代，也是最坏的时代。",
            "要么冒险一试，要么什么也不做。"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateColor_Click(object sender, RoutedEventArgs e)
        {
            Color randomColor = Color.FromRgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256));
            ColorRectangle.Fill = new SolidColorBrush(randomColor);
        }

        private void GenerateQuote_Click(object sender, RoutedEventArgs e)
        {
            QuoteText.Text = _quotes[_random.Next(_quotes.Length)];
        }

        private void GenerateShape_Click(object sender, RoutedEventArgs e)
        {
            ShapeCanvas.Children.Clear();
            Shape shape;
            switch (_random.Next(3))
            {
                case 0:
                    shape = new Ellipse { Width = 100, Height = 100 };
                    break;
                case 1:
                    shape = new Rectangle { Width = 100, Height = 100 };
                    break;
                default:
                    var polygon = new Polygon();
                    var points = new PointCollection
                    {
                        new Point(50, 0),
                        new Point(0, 100),
                        new Point(100, 100)
                    };
                    polygon.Points = points;
                    shape = polygon;
                    break;
            }
            shape.Fill = new SolidColorBrush(Color.FromRgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256)));
            Canvas.SetLeft(shape, 50);
            Canvas.SetTop(shape, 50);
            ShapeCanvas.Children.Add(shape);
        }

        private void GenerateLineChart_Click(object sender, RoutedEventArgs e)
        {
            ChartCanvas.Children.Clear();

            // 生成随机数据点
            List<Point> points = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                points.Add(new Point(i * 40, _random.Next(20, 180)));
            }

            // 创建折线
            Polyline polyline = new Polyline
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 2,
                Points = new PointCollection(points)
            };

            ChartCanvas.Children.Add(polyline);

            // 添加X轴和Y轴
            Line xAxis = new Line
            {
                X1 = 0,
                Y1 = 190,
                X2 = 390,
                Y2 = 190,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            ChartCanvas.Children.Add(xAxis);

            Line yAxis = new Line
            {
                X1 = 10,
                Y1 = 0,
                X2 = 10,
                Y2 = 200,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            ChartCanvas.Children.Add(yAxis);

            // 添加数据点
            foreach (var point in points)
            {
                Ellipse ellipse = new Ellipse
                {
                    Width = 6,
                    Height = 6,
                    Fill = Brushes.Red
                };
                Canvas.SetLeft(ellipse, point.X - 3);
                Canvas.SetTop(ellipse, point.Y - 3);
                ChartCanvas.Children.Add(ellipse);
            }
        }

        private void ClearContent_Click(object sender, RoutedEventArgs e)
        {
            QuoteText.Text = string.Empty;
            ColorRectangle.Fill = null;
            ShapeCanvas.Children.Clear();
            ChartCanvas.Children.Clear();
        }
    }
}
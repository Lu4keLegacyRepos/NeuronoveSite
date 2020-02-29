using Perceptron.DataSet;
using Perceptron.Helpers;
using Perceptron.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Visualization
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] filenames = new string[]
        {
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\obdelnik_rozsah.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t1r.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t2r.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t3r.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t4r.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t5r.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t6r.xml",
            @"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\t7r.xml"
        };
        private int fileIndex = 0;
        DataLoader dataLoader = new DataLoader(@"D:\Source Codes\NeuronoveSite\du1\Visualization\InputData\obdelnik_rozsah.xml");
        Perceptron.Perceptron p;

        private readonly UIElement[] defaultCanvas;

        private List<IDataSet> trainData;

        private int ElapsedEpoch = 0;
        public MainWindow()
        {
            InitializeComponent();
            p = new Perceptron.Perceptron(2,0.0001);
            EpochLabel.Content = $"Training epocha: {ElapsedEpoch}";
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";
            SetTrainData();

            W1.Content = p.Weights[0];
            W2.Content = p.Weights[1];
            b.Content = p.Bias;

            defaultCanvas = new UIElement[canvas.Children.Count];
            canvas.Children.CopyTo(defaultCanvas, 0);

        }

        private string GetFilename(string path)
        {
            var parts= path.Split('\\');
            return parts[^1];
        }
        private void SetTrainData()
        {
            p = new Perceptron.Perceptron(2);
            if (fileIndex >= filenames.Length)
            {
                fileIndex = 0;
            }
            fileLabel1.Content = GetFilename(dataLoader.Path);
            ElapsedEpoch = 0;
            dataLoader.Path = filenames[fileIndex++];
            trainData = dataLoader.GetDataSets().trainData;
            if (trainData[0].Input.Length > 2)
            {
                SetTrainData();
                return;
            }
            p.SetTrainData(trainData);
            EpochLabel.Content = $"Training epocha: {ElapsedEpoch}";
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";
        }

        private void VisualizePerceptron()
        {
            ResetCanvas();
            var testData = dataLoader.GetDataSets().testData;
            foreach (TestSet point in testData)
            {
                var mappedX = point.Input[0].Map(dataLoader.Range, (-200, 200));
                var mappedY = point.Input[1].Map(dataLoader.Range, (-200, 200));
                DrawPoint((mappedX, mappedY, OutputConvertor((int)p.Guess(new double[] { mappedX,mappedY}))));
            }

            var tmpStartX = p.LineEquations.GetX((-200, p.Bias, p.Weights[0], p.Weights[1]));
            var tmpEndX = p.LineEquations.GetX((200, p.Bias, p.Weights[0], p.Weights[1]));
            DrawLine((tmpStartX, p.LineEquations.GetY((tmpStartX, p.Bias, p.Weights[0], p.Weights[1]))), (tmpEndX, p.LineEquations.GetY((tmpEndX, p.Bias, p.Weights[0], p.Weights[1]))));
        }

        private void VisualizeTraining()
        {
            ResetCanvas();
            var stepData = trainData;
            if (stepData != null)
            {
                foreach (TrainingSet point in trainData)
                {
                    DrawPoint((point.Input[0].Map(dataLoader.Range, (-200, 200)), point.Input[1].Map(dataLoader.Range, (-200, 200)), OutputConvertor((int)point.Output)));
                }
            }
            var tmpStartX = p.LineEquations.GetX((-200, p.Bias, p.Weights[0], p.Weights[1]));
            var tmpEndX = p.LineEquations.GetX((200, p.Bias, p.Weights[0], p.Weights[1]));
            DrawLine((tmpStartX, p.LineEquations.GetY((tmpStartX, p.Bias, p.Weights[0], p.Weights[1]))),
                (tmpEndX, p.LineEquations.GetY((tmpEndX, p.Bias, p.Weights[0], p.Weights[1]))));

            p.TrainStep();
        }

        private void ResetCanvas()
        {
            canvas.Children.Clear();
            foreach (UIElement child in defaultCanvas)
            {
                canvas.Children.Add(child);

            }
        }
        private Brush OutputConvertor(int o) => o switch
        {
            -1 => Brushes.Red,
            1 => Brushes.Green,
            _ => Brushes.Red
        };

        private void DrawPoint((double x, double y, Brush color) point)
        {
            Ellipse circle = new Ellipse()
            {
                Width = 7,
                Height = 7,
                Stroke = point.color,
                StrokeThickness = 2,
                Fill = OutputConvertor((int)p.Guess(new double[]{ point.x, point.y }))
            };

            canvas.Children.Add(circle);

            circle.SetValue(Canvas.LeftProperty, (double)point.x);
            circle.SetValue(Canvas.TopProperty, (double)point.y);
        }

        private void DrawLine((double x, double y) start, (double x, double y) end)
        {
            var line = new Line();
            line.Stroke = Brushes.Black;
            line.X1 = start.x;
            line.X2 = end.x;
            line.Y1 = start.y;
            line.Y2 = end.y;
            line.StrokeThickness = 1;

            canvas.Children.Add(line);
        }

        private void border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            VisualizeTraining();
            EpochLabel.Content = $"Training epocha: {++ElapsedEpoch}";
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";
            W1.Content = p.Weights[0];
            W2.Content = p.Weights[1];
            b.Content = p.Bias;
            //  Error.Content = p.Error;


        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            VisualizePerceptron();

        }

        private void TrainButton_Click(object sender, RoutedEventArgs e)
        {
            SetTrainData();
            VisualizeTraining();
            EpochLabel.Content = $"Training epocha: {++ElapsedEpoch}";
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";

        }

        private void Train100Button_Click(object sender, RoutedEventArgs e)
        {
            p.Train(99, trainData);
            VisualizeTraining();
            ElapsedEpoch += 100;
            EpochLabel.Content = $"Training epocha: {ElapsedEpoch}";
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";
            W1.Content = p.Weights[0];
            W2.Content = p.Weights[1];
            b.Content = p.Bias;
            
        }

        private void btnTrainFull_Click(object sender, RoutedEventArgs e)
        {
            p.Train(-1, trainData);
            VisualizeTraining();
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";
            W1.Content = p.Weights[0];
            W2.Content = p.Weights[1];
            b.Content = p.Bias;
        }

        private void TrainBig_Click(object sender, RoutedEventArgs e)
        {
            p.Train(10000, trainData);
            VisualizeTraining();
            ElapsedEpoch += 100;
            EpochLabel.Content = $"Training epocha: {ElapsedEpoch}";
            lineLabel.Content = $"Line: {p.LineEquations.ToString((p.Bias, p.Weights[0], p.Weights[1]))}";
            W1.Content = p.Weights[0];
            W2.Content = p.Weights[1];
            b.Content = p.Bias;
        }
    }
}

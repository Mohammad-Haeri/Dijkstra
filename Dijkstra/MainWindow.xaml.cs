using Dijkstra.CustomControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Dijkstra
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A dictionary containing vertices with their weights and availblity
        /// </summary>
        private static readonly Dictionary<string, IDictionary<string, IDictionary<bool, int?>>> _weightedVerticesList = [];

        /// <summary>
        /// A list Containing all vertices
        /// </summary>
        private static readonly List<string> _verticeList = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q"];

        /// <summary>
        /// Dictionary that store founded routes for further routing
        /// </summary>
        private static readonly Dictionary<string, Tuple<int, string>> _heap = [];

        /// <summary>
        /// Dictionary containing vertices as key and their visited status as boolean
        /// </summary>
        private static Dictionary<string, Tuple<bool>> _visitedList = [];


        public MainWindow()
        {
            InitializeComponent();
        }

        #region Initialization

        /// <summary>
        /// Return a nulable in of input string is null or not number
        /// </summary>
        /// <param name="stringNumber">Integer value as string</param>
        /// <returns></returns>
        private static int? ToNullableInt(string stringNumber)
        {
            if (int.TryParse(stringNumber, out int result))
            {
                return result;
            }

            return null;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            //_priorityQueue.Add("A", Tuple.Create(0, ""));
            //_priorityQueue.Add("B", null);

            foreach (string vertice in _verticeList)
            {
                _weightedVerticesList.Add(vertice, new Dictionary<string, IDictionary<bool, int?>>());

                _visitedList.Add(vertice, Tuple.Create(false));
            }


            foreach (RoundedTextBox item in GUIGrid.Children.OfType<RoundedTextBox>())
            {
                #region Mapping

                string from = item.Name[0].ToString();

                string to = item.Name[1].ToString();

                _weightedVerticesList[from].Add(to, new Dictionary<bool, int?> { { true, null } });

                #endregion

                RoundedTextBox newChild = new()
                {
                    Name = $"{item.Name}_Panel",
                    Margin = new Thickness(5),
                    Hint = item.Hint,
                    CornerRadius = new CornerRadius(5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    TextBoxsTextAlignment = TextAlignment.Center,
                    TextBlocksTextAlignment = TextAlignment.Center,
                    IsNumeric = true,
                    MaxLines = 1,
                    TextMaxLenght = 3,
                    MinValue = 1,

                };



                #region Text Binding

                item.SetBinding(RoundedTextBox.TextProperty, new Binding("Text")
                {
                    Source = newChild.baseTextBox,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });


                newChild.SetBinding(RoundedTextBox.TextProperty, new Binding("Text")
                {
                    Source = item,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

                #endregion

                #region Being Available Binding

                item.SetBinding(RoundedTextBox.IsAvailbleProperty, new Binding("IsAvailble")
                {
                    Source = newChild.baseTextBox,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

                newChild.SetBinding(RoundedTextBox.IsAvailbleProperty, new Binding("IsAvailble")
                {
                    Source = item,
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

                #endregion

                PanelStackPanel.Children.Add(newChild);
            }

            InceptionVertice.ItemsSource = DestinationVertice.ItemsSource = _verticeList;

        }

        /// <summary>
        /// Keeping weighted edges dictionary update upon changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVerticeEdgeValueChanged(object? sender, EventArgs e)
        {
            if (sender is RoundedTextBox roundedTextBox)
            {
                string from = roundedTextBox.Name[0].ToString();

                string to = roundedTextBox.Name[1].ToString();


                if (string.IsNullOrWhiteSpace(roundedTextBox.baseTextBox.Text))
                {
                    _weightedVerticesList[from][to].Clear();
                    _weightedVerticesList[from][to].Add(false, null);
                }
                else
                {
                    _weightedVerticesList[from][to].Clear();
                    _weightedVerticesList[from][to][true] = ToNullableInt(roundedTextBox.baseTextBox.Text);
                }

            }

            if (InceptionVertice.SelectedIndex > -1)
            {
                DijkstraAlgorithm(InceptionVertice.SelectedItem.ToString());
            }
        }

        private void OnEdgeAvailabilityChanged(object? sender, EventArgs e)
        {
            var roundedTextBox = sender as RoundedTextBox;

            if (roundedTextBox is not null)
            {
                string from = roundedTextBox.Name[0].ToString();

                string to = roundedTextBox.Name[1].ToString();

                bool key = _weightedVerticesList[from][to].Keys.First();

                int? keepdValue = _weightedVerticesList[from][to][key];

                _weightedVerticesList[from][to].Remove(key);

                _weightedVerticesList[from][to].Add(roundedTextBox.baseTextBox.IsEnabled, keepdValue);
            }
        }

        private void OnCloseLableClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void OnBorderDraging(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        #endregion

        #region Operations




        /// <summary>
        /// Calculate shortest path to all edges from inception point and store in a gloabal static table
        /// </summary>
        private void OnInceptionVerticeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender is ComboBox combobox && combobox.SelectedItem.ToString() is string inception)
            {

                DijkstraAlgorithm(inception);

                if (DestinationVertice.SelectedIndex > -1 && DestinationVertice.SelectedItem.ToString() is string destination)
                {
                    ShowCalculation(inception, destination);
                }
            }
        }

        private void OnDestinationVerticeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string? destination = ((ComboBox)sender).SelectedItem.ToString();
            if (sender is ComboBox combobox && combobox.SelectedItem.ToString() is string destination
               && InceptionVertice.SelectedIndex > -1 && InceptionVertice.SelectedItem.ToString() is string inception)
            {
                ShowCalculation(inception, destination);
            }
        }

        /// <summary>
        /// Show the shortest path to destination vertice in Show Result TextBlock
        /// </summary>
        private void ShowCalculation(string inceptionVertice, string destinationVertice)
        {
            List<string> routes = [];
            string currentVertice = destinationVertice;

            while (currentVertice != inceptionVertice)
            {
                if (!_heap.ContainsKey(currentVertice))
                {
                    ShowResultTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                    ShowResultTextBlock.Text = $"No way from {inceptionVertice} to {destinationVertice}";
                    return;
                }
                routes.Add(_heap[currentVertice].Item2);
                currentVertice = _heap[currentVertice].Item2;
            }

            string path = "";

            for (int i = routes.Count - 1; i >= 0; i--)
            {
                path += $"{routes[i]} --> ";
            }

            path += destinationVertice;

            ShowResultTextBlock.Foreground = new SolidColorBrush(Colors.LightSeaGreen);
            ShowResultTextBlock.Text = path;
        }

        /// <summary>
        /// Calculate shortest path to all edges from inception point base on dijkstra algorithm
        /// </summary>
        /// <param name="inceptionVertice">Inception edge name</param>
        private void DijkstraAlgorithm(string? inceptionVertice)
        {
            if (inceptionVertice is null)
            {
                return;
            }

            int currentVisitingVerticeTotalDistanceToInceptionVertice = 0;

            // clearing heap for new calculation
            _heap.Clear();

            // Make all vertices unvisited except inception vertice
            foreach (var key in _visitedList.Keys)
            {
                if (key.Equals(inceptionVertice))
                {
                    _visitedList[key] = Tuple.Create(true);
                }
                else
                {
                    _visitedList[key] = Tuple.Create(false);
                }

            }

            // Initiaizig inception vertice
            _heap.Add(inceptionVertice, Tuple.Create(0, inceptionVertice));

            string currentVertice = inceptionVertice;

            /// Started from 1 because the last vertice is not calculateable since all other vertices became visted
            for (int i = 1; i < _verticeList.Count; i++)
            {
                if (!_weightedVerticesList.ContainsKey(currentVertice))
                {
                    continue;
                }

                //Grabbing every availbe neighbour of current visiting vertice
                foreach (var vertice in _weightedVerticesList[currentVertice].Keys)
                {
                    // Make sure neighbour vertice is not null and visited status is false
                    if (vertice is not null && _visitedList[vertice].Item1.Equals(false))
                    {
                        foreach (var item in _weightedVerticesList[currentVertice][vertice])
                        {
                            // Check if route is available(currently such an option did not implemented, but infrastructure existed is UI)
                            if (item.Key.Equals(true))
                            {
                                int calculated = 0;
                                // If existed comapre it
                                if (_heap.ContainsKey(vertice))
                                {

                                    calculated = item.Value.GetValueOrDefault() + currentVisitingVerticeTotalDistanceToInceptionVertice;
                                    if (calculated < _heap[vertice].Item1)
                                    {
                                        _heap[vertice] = Tuple.Create(calculated, currentVertice);
                                    }
                                }
                                // Else add to heap
                                else
                                {
                                    calculated = item.Value.GetValueOrDefault() + currentVisitingVerticeTotalDistanceToInceptionVertice;
                                    _heap.Add(vertice, Tuple.Create(calculated, currentVertice));
                                }
                            }
                        }
                    } // end if visited and not null
                }// end weited


                (currentVertice, currentVisitingVerticeTotalDistanceToInceptionVertice) = FindMinimum(_heap);
                _visitedList[currentVertice] = Tuple.Create(true);

            }
        }


        /// <summary>
        /// Find shortest path from visited edge to all neighbour
        /// </summary>
        /// <param name="neighbourVertice">Dictionary of that contain all neighbour edges to visiting edge with their distance and availbility</param>
        /// <returns>The closest edge name.</returns>
        private static (string, int) FindMinimum(Dictionary<string, Tuple<int, string>> neighbourVertice)
        {
            int minValue = int.MaxValue;
            string selectedVertice = "";

            foreach (var vertice in neighbourVertice)
            {
                // null here means 0 which mean shortest path
                if (vertice.Value is not null && !vertice.Value.Item1.Equals(0) && _visitedList[vertice.Key].Item1.Equals(false))
                {
                    if ((vertice.Value.Item1) < minValue)
                    {
                        minValue = vertice.Value.Item1;
                        selectedVertice = vertice.Key;
                    }
                }
            }
            return (selectedVertice, minValue);
        }

        //----------------------------------------------------------------------------------------------------------------------------\\

        /// <summary>
        /// Create random distance for all vertices
        /// </summary>
        private void OnRandomDataButtonClick(object sender, RoutedEventArgs e)
        {
            Random random = new();
            foreach (RoundedTextBox item in PanelStackPanel.Children.OfType<RoundedTextBox>())
            {
                if (item.IsAvailble)
                {
                    item.Text = random.Next(1, 999).ToString();
                }
            }
        }
        #endregion

        #region Credits

        private void OnCreatorsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mohammad Baqer Haeri");
        }

        #endregion


    }
}
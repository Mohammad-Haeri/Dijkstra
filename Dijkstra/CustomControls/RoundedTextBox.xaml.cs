using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dijkstra.CustomControls
{
    /// <summary>
    /// Interaction logic for RoundedTextBox.xaml
    /// </summary>
    /// 
    public partial class RoundedTextBox : UserControl
    {

        #region TextBoxs Dependencys

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(RoundedTextBox), new PropertyMetadata(string.Empty));

        public double TextBoxOpacity
        {
            get { return (double)GetValue(TextBoxOpacityProperty); }
            set { SetValue(TextBoxOpacityProperty, value); }
        }

        public static readonly DependencyProperty TextBoxOpacityProperty =
            DependencyProperty.Register("TextBoxOpacity", typeof(double), typeof(RoundedTextBox), new PropertyMetadata(1.0));

        public Brush TextBoxBackground
        {
            get { return (Brush)GetValue(TextBoxBackgroundProperty); }
            set { SetValue(TextBoxBackgroundProperty, value); }
        }

        public static readonly DependencyProperty TextBoxBackgroundProperty =
            DependencyProperty.Register("TextBoxBackground", typeof(Brush), typeof(RoundedTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public Thickness TextBoxsPadding
        {
            get { return (Thickness)GetValue(TextBoxsPaddingProperty); }
            set { SetValue(TextBoxsPaddingProperty, value); }
        }

        public static readonly DependencyProperty TextBoxsPaddingProperty =
            DependencyProperty.Register("TextBoxsPadding", typeof(Thickness), typeof(RoundedTextBox), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public Thickness TextBoxsMargin
        {
            get { return (Thickness)GetValue(TextBoxsMarginProperty); }
            set { SetValue(TextBoxsMarginProperty, value); }
        }

        public static readonly DependencyProperty TextBoxsMarginProperty =
            DependencyProperty.Register("TextBoxsMargin", typeof(Thickness), typeof(RoundedTextBox), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public TextAlignment TextBoxsTextAlignment
        {
            get { return (TextAlignment)GetValue(TextBoxsTextAlignmentProperty); }
            set { SetValue(TextBoxsTextAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextBoxsTextAlignmentProperty =
            DependencyProperty.Register("TextBoxsTextAlignment", typeof(TextAlignment), typeof(RoundedTextBox), new PropertyMetadata(TextAlignment.Left));

        public VerticalAlignment TextBoxVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(TextBoxVerticalAlignmentProperty); }
            set { SetValue(TextBoxVerticalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextBoxVerticalAlignmentProperty =
            DependencyProperty.Register("TextBoxVerticalAlignment", typeof(VerticalAlignment), typeof(RoundedTextBox), new PropertyMetadata(VerticalAlignment.Stretch));

        public HorizontalAlignment TextBoxHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(TextBoxHorizontalAlignmentProperty); }
            set { SetValue(TextBoxHorizontalAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextBoxHorizontalAlignmentProperty =
            DependencyProperty.Register("TextBoxHorizontalAlignment", typeof(HorizontalAlignment), typeof(RoundedTextBox), new PropertyMetadata(HorizontalAlignment.Stretch));

        public bool IsNumeric
        {
            get { return (bool)GetValue(IsNumericProperty); }
            set { SetValue(IsNumericProperty, value); }
        }

        public static readonly DependencyProperty IsNumericProperty =
            DependencyProperty.Register("IsNumeric", typeof(bool), typeof(RoundedTextBox), new PropertyMetadata(false));

        public int TextMaxLenght
        {
            get { return (int)GetValue(TextMaxLenghtProperty); }
            set { SetValue(TextMaxLenghtProperty, value); }
        }

        public static readonly DependencyProperty TextMaxLenghtProperty =
            DependencyProperty.Register("TextMaxLenght", typeof(int), typeof(RoundedTextBox), new PropertyMetadata(int.MaxValue));

        public int MaxLines
        {
            get { return (int)GetValue(MaxLineProperty); }
            set { SetValue(MaxLineProperty, value); }
        }

        public static readonly DependencyProperty MaxLineProperty =
            DependencyProperty.Register("MaxLines", typeof(int), typeof(RoundedTextBox), new PropertyMetadata(int.MaxValue));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(RoundedTextBox), new PropertyMetadata(int.MaxValue));


        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(RoundedTextBox), new PropertyMetadata(int.MinValue));

        //TextWrapping

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(RoundedTextBox), new PropertyMetadata(false));

        

        #endregion


        #region TextBlocks Dependencys

        public Thickness TextBlocksPadding
        {
            get { return (Thickness)GetValue(TextBlocksPaddingProperty); }
            set { SetValue(TextBlocksPaddingProperty, value); }
        }

        public static readonly DependencyProperty TextBlocksPaddingProperty =
            DependencyProperty.Register("TextBlocksPadding", typeof(Thickness), typeof(RoundedTextBox), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public Thickness TextBlocksMargin
        {
            get { return (Thickness)GetValue(TextBlocksMarginProperty); }
            set { SetValue(TextBlocksMarginProperty, value); }
        }

        public static readonly DependencyProperty TextBlocksMarginProperty =
            DependencyProperty.Register("TextBlocksMargin", typeof(Thickness), typeof(RoundedTextBox), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public TextAlignment TextBlocksTextAlignment
        {
            get { return (TextAlignment)GetValue(TextBlocksTextAlignmentProperty); }
            set { SetValue(TextBlocksTextAlignmentProperty, value); }
        }

        public static readonly DependencyProperty TextBlocksTextAlignmentProperty =
            DependencyProperty.Register("TextBlocksTextAlignment", typeof(TextAlignment), typeof(RoundedTextBox), new PropertyMetadata(TextAlignment.Left));

        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(RoundedTextBox), new PropertyMetadata(string.Empty));

        public Brush HintBrush
        {
            get { return (Brush)GetValue(HintBrushProperty); }
            set { SetValue(HintBrushProperty, value); }
        }

        public static readonly DependencyProperty HintBrushProperty =
            DependencyProperty.Register("HintBrush", typeof(Brush), typeof(RoundedTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));






        #endregion


        #region CheckBox Dependencys

        public bool IsAvailble
        {
            get { return (bool)GetValue(IsAvailbleProperty); }
            set { SetValue(IsAvailbleProperty, value); }
        }

        public static readonly DependencyProperty IsAvailbleProperty =
            DependencyProperty.Register("IsAvailble", typeof(bool), typeof(RoundedTextBox), new PropertyMetadata(true));



        #endregion


        #region General Dependencys


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(RoundedTextBox), new PropertyMetadata(new CornerRadius(0, 0, 0, 0)));

        public Brush ControlBorderBrush
        {
            get { return (Brush)GetValue(ControlBorderBrushProperty); }
            set { SetValue(ControlBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty ControlBorderBrushProperty =
            DependencyProperty.Register("ControlBorderBrush", typeof(Brush), typeof(RoundedTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public Thickness ControlBorderThickness
        {
            get { return (Thickness)GetValue(ControlBorderThicknessProperty); }
            set { SetValue(ControlBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty ControlBorderThicknessProperty =
            DependencyProperty.Register("ControlBorderThickness", typeof(Thickness), typeof(RoundedTextBox), new PropertyMetadata(new Thickness(0, 0, 0, 0)));

        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(RoundedTextBox), new PropertyMetadata(TextWrapping.NoWrap));

        public event EventHandler ValueChanged;

        public event EventHandler IsAvailbleChanged;

        #endregion



        public RoundedTextBox()
        {
            InitializeComponent();
            baseTextBox.TextChanged += (s, e) =>
            {
                ValueChanged?.Invoke(this, e);
            };

            baseTextBox.IsEnabledChanged += (s, e) =>
            {
                IsAvailbleChanged?.Invoke(this, new EventArgs());
            };
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string? input = ((TextBox)sender).Text;

            if (input != null && input != "" && IsNumeric)
            {
                if (!IsValidNumber(input))
                {
                    ((TextBox)sender).TextChanged -= OnTextChanged;
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).TextChanged += OnTextChanged;
                    ValueChanged?.Invoke(this, e); 
                    return;
                }

                if (int.Parse(input) < MinValue)
                {
                    ((TextBox)sender).TextChanged -= OnTextChanged;
                    ((TextBox)sender).Text = MinValue.ToString();
                    ((TextBox)sender).TextChanged += OnTextChanged;
                    ValueChanged?.Invoke(this, e); 
                    return;
                }

                if (int.Parse(input) > MaxValue)
                {
                    ((TextBox)sender).TextChanged -= OnTextChanged;
                    ((TextBox)sender).Text = MaxValue.ToString();
                    ((TextBox)sender).TextChanged += OnTextChanged;
                    ValueChanged?.Invoke(this, e);
                    return;
                }

                ValueChanged?.Invoke(this, e);
            }

        }


        private bool IsValidNumber(string input)
        {
            foreach (char character in input)
            {
                if (!char.IsNumber(character)) { return false; }
            }

            return true;
        }

        private void baseControl_GotFocus(object sender, RoutedEventArgs e)
        {
            baseTextBox.Focus();
        }


        //private void Grid_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    IsAvailbleChanged?.Invoke(sender, new EventArgs());

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// The search box is a text box that display a label when no text is 
    /// entered and offers the options to display a result label.
    /// </summary>
    [TemplatePart(Name = "PART_Text", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_Status", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_EmptyText", Type = typeof(TextBlock))]
    public class SearchBox : Control
    {
        /// <summary>
        /// Static constructor.
        /// </summary>
        static SearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchBox), new FrameworkPropertyMetadata(typeof(SearchBox)));
        }

        /// <summary>
        /// Text property.
        /// </summary>
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// Status text. (i.e. 3 result(s))
        /// </summary>
        public String StatusText
        {
            get { return (String)GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        /// <summary>
        /// Empty text label.
        /// </summary>
        public String EmptyText
        {
            get { return (String)GetValue(EmptyTextProperty); }
            set { SetValue(EmptyTextProperty, value); }
        }

        /// <summary>
        /// Trigger to be notified of text changes.
        /// </summary>
        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        /// <summary>
        /// Text property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(String), typeof(SearchBox),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnTextChanged),
                                          new CoerceValueCallback(OnCoerceText)));

        /// <summary>
        /// Status text property.
        /// </summary>
        public static readonly DependencyProperty StatusTextProperty =
            DependencyProperty.Register("StatusText", typeof(String), typeof(SearchBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Empty text property.
        /// </summary>
        public static readonly DependencyProperty EmptyTextProperty =
            DependencyProperty.Register("EmptyText", typeof(String), typeof(SearchBox), new UIPropertyMetadata("search..."));

        /// <summary>
        /// Text change event property.
        /// </summary>
        public static readonly RoutedEvent TextChangedEvent = EventManager.RegisterRoutedEvent("TextChanged",
          RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchBox));

        /// <summary>
        /// Coerce callback when the text value changes.
        /// </summary>
        private static object OnCoerceText(DependencyObject o, Object value)
        {
            SearchBox searchBox = o as SearchBox;
            if (searchBox != null)
                return searchBox.OnCoerceText((String)value);
            else
                return value;
        }

        /// <summary>
        /// Called when the text property changes.
        /// </summary>
        private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            SearchBox searchBox = o as SearchBox;
            if (searchBox != null)
                searchBox.OnTextChanged((String)e.OldValue, (String)e.NewValue);
        }

        /// <summary>
        /// Called to coerces value.
        /// </summary>
        protected virtual String OnCoerceText(String value)
        {
            return value;
        }

        /// <summary>
        /// Called when the text property changes.
        /// </summary>
        protected virtual void OnTextChanged(String oldValue, String newValue)
        {
            // Fire text changed event
            this.RaiseEvent(new RoutedEventArgs(SearchBox.TextChangedEvent, this));

            // Update the status text visibility based on the user text.
            UpdateStatusTextVisibility(newValue);
        }

        /// <summary>
        /// Handles key down events. Clears current text if escape is pressed.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Clear the text search if escape is pressed.
            if (e.Key == Key.Escape)
            {
                this.Text = "";
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        /// <summary>
        /// Shows or hide the result label if user's text is displayed under it.
        /// </summary>
        /// <param name="newValue"></param>
        private void UpdateStatusTextVisibility(string newValue)
        {
            // Hide status if in the way
            TextBox textBox = GetTemplateChild("PART_Text") as TextBox;
            TextBlock statusText = GetTemplateChild("PART_Status") as TextBlock;
            if (textBox != null && statusText != null)
            {
                // Compute the text width.
                FormattedText output = new FormattedText(newValue, CultureInfo.CurrentCulture, textBox.FlowDirection,
                  new Typeface(textBox.FontFamily, textBox.FontStyle, textBox.FontWeight, textBox.FontStretch),
                  textBox.FontSize, textBox.Foreground);

                // Get where the status text is displayed.
                Point relativePoint = statusText.TransformToAncestor((Visual)statusText.Parent).Transform(new Point(0, 0));

                // Set a custom bias.
                relativePoint.X -= textBox.FontSize;

                if (output.Width >= relativePoint.X)
                {
                    statusText.Visibility = Visibility.Hidden;
                }
                else
                {
                    statusText.Visibility = Visibility.Visible;
                }
            }
        }
    }
}

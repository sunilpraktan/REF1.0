using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Reflection.Presentation.Services
{
    public class SearchEventArgs : RoutedEventArgs
    {
        private string m_keyword = "";

        public string Keyword
        {
            get { return m_keyword; }
            set { m_keyword = value; }
        }
        private List<string> m_sections = new List<string>();

        public List<string> Sections
        {
            get { return m_sections; }
            set { m_sections = value; }
        }
        public SearchEventArgs()
            : base()
        {

        }
        public SearchEventArgs(RoutedEvent routedEvent)
            : base(routedEvent)
        {

        }
    }

    public class SearchTextBox : TextBox
    {

        public static DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(SearchTextBox));

        public static DependencyProperty LabelTextColorProperty =
            DependencyProperty.Register(
                "LabelTextColor",
                typeof(Brush),
                typeof(SearchTextBox));

        private static DependencyPropertyKey HasTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "HasText",
                typeof(bool),
                typeof(SearchTextBox),
                new PropertyMetadata());
        public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        private static DependencyPropertyKey IsMouseLeftButtonDownPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsMouseLeftButtonDown",
                typeof(bool),
                typeof(SearchTextBox),
                new PropertyMetadata());
        public static DependencyProperty IsMouseLeftButtonDownProperty = IsMouseLeftButtonDownPropertyKey.DependencyProperty;

        public static readonly RoutedEvent SearchEvent =
            EventManager.RegisterRoutedEvent(
                "Search",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(SearchTextBox));

        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SearchTextBox),
                new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        public SearchTextBox()
            : base()
        {

        }


        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            HasText = Text.Length != 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected override void OnMouseDown(MouseButtonEventArgs e)
        ///
        /// @brief  Override the default method. 
        ///
        /// @author Le Duc Anh
        /// @date   8/14/2010
        ///
        /// @param  e   Event information to send to registered event handlers. 
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Border iconBorder = GetTemplateChild("PART_SearchIconBorder") as Border;
            if (iconBorder != null)
            {
                iconBorder.MouseLeftButtonDown += new MouseButtonEventHandler(IconBorder_MouseLeftButtonDown);
                iconBorder.MouseLeftButtonUp += new MouseButtonEventHandler(IconBorder_MouseLeftButtonUp);
                iconBorder.MouseLeave += new MouseEventHandler(IconBorder_MouseLeave);
            }

            int size = 0;
            if (ShowSectionButton)
            {
                iconBorder = GetTemplateChild("PART_SpecifySearchType") as Border;
                size = 15;
            }
            Image iconChoose = GetTemplateChild("SpecifySearchType") as Image;
            if (iconChoose != null)
                iconChoose.Width = iconChoose.Height = size;

            iconBorder = GetTemplateChild("PART_PreviousItem") as Border;

            //////////////////////////////////////////////////////////////////////////
        }

        private void IconBorder_MouseLeftButtonDown(object obj, MouseButtonEventArgs e)
        {
            IsMouseLeftButtonDown = true;

        }

        private void IconBorder_MouseLeftButtonUp(object obj, MouseButtonEventArgs e)
        {
            if (!IsMouseLeftButtonDown) return;

            if (HasText)
            {
                RaiseSearchEvent();
            }

            IsMouseLeftButtonDown = false;
        }

        private void IconBorder_MouseLeave(object obj, MouseEventArgs e)
        {
            IsMouseLeftButtonDown = false;

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Text = "";
            }
            else if ((e.Key == Key.Return || e.Key == Key.Enter))
            {
                RaiseSearchEvent();
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void RaiseSearchEvent()
        {
            if (this.Text == "")
                return;

            SearchEventArgs args = new SearchEventArgs(SearchEvent);
            args.Keyword = this.Text;
            RaiseEvent(args);
        }

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public Brush LabelTextColor
        {
            get { return (Brush)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            private set { SetValue(HasTextPropertyKey, value); }
        }

        public bool IsMouseLeftButtonDown
        {
            get { return (bool)GetValue(IsMouseLeftButtonDownProperty); }
            private set { SetValue(IsMouseLeftButtonDownPropertyKey, value); }
        }

        public event RoutedEventHandler OnSearch
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }

        #region Stuff added by Le Duc Anh

        public static DependencyProperty SectionsListProperty =
            DependencyProperty.Register(
                "SectionsList",
                typeof(List<string>),
                typeof(SearchTextBox),
                new FrameworkPropertyMetadata(null,
                                                FrameworkPropertyMetadataOptions.None)
             );

        public List<string> SectionsList
        {
            get { return (List<string>)GetValue(SectionsListProperty); }
            set
            {
                SetValue(SectionsListProperty, value);

            }
        }

        private bool m_showSectionButton = true;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @property   public bool ShowSectionButton
        ///
        /// @brief  Gets or sets a value indicating whether the choose section button is shown. 
        ///
        /// @return true if show choose section button, false if not. 
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ShowSectionButton
        {
            get { return m_showSectionButton; }
            set
            {
                m_showSectionButton = value;
            }
        }

        public enum SectionsStyles
        {
            NormalStyle,
            CheckBoxStyle,
            RadioBoxStyle
        }
        private SectionsStyles m_itemStyle = SectionsStyles.CheckBoxStyle;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @property   public SectionsStyles ItemStyle
        ///
        /// @brief  Gets or sets the style's of each displayed section. This property is valid when
        ///         ShowSectionButton is set to true. 
        ///
        /// @return The item style. 
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SectionsStyles SectionsStyle
        {
            get { return m_itemStyle; }
            set { m_itemStyle = value; }
        }




        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (!HasText)
                this.LabelText = "Search";
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (!HasText)
                this.LabelText = "";
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
        }




        #endregion
    }
}

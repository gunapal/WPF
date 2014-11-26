namespace WpfAssignment.Behaviors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Captures the button behaviors
    /// </summary>
    public class ButtonBehavior
    {
        private static DependencyProperty _property;
        private static readonly RoutedEvent _buttonClickedEvent = Button.ClickEvent;

        /// <summary>
        /// The button clicked command property
        /// </summary>
        public static readonly DependencyProperty ButtonClickedCommandProperty =
            DependencyProperty.RegisterAttached("ButtonClickedCommand",
            typeof(ICommand), typeof(ButtonBehavior),
            new PropertyMetadata(new PropertyChangedCallback(ButtonClickedCallBack)));

        /// <summary>
        /// Sets the button clicked command.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        public static void SetButtonClickedCommand(UIElement obj, ICommand value)
        {
            obj.SetValue(ButtonClickedCommandProperty, value);
        }

        /// <summary>
        /// Gets the button clicked command.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static ICommand GetButtonClickedCommand(UIElement obj)
        {
            return (ICommand)obj.GetValue(ButtonClickedCommandProperty);
        }

        /// <summary>
        /// Buttons the clicked call back.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        static void ButtonClickedCallBack(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            UIElement element = obj as UIElement;
            _property = args.Property;

            if (element != null)
            {
                if (args.OldValue != null)
                {
                    element.AddHandler(_buttonClickedEvent, new RoutedEventHandler(ClickEventHandler));
                }

                if (args.NewValue != null)
                {
                    element.AddHandler(_buttonClickedEvent, new RoutedEventHandler(ClickEventHandler));
                }
            }
        }

        /// <summary>
        /// Invokes the handler tied to the click command in the view model.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public static void ClickEventHandler(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = sender as DependencyObject;

            if (obj != null)
            {
                ICommand command = obj.GetValue(_property) as ICommand;

                if (command != null)
                {
                    if (command.CanExecute(e))
                    {
                        Button button = e.OriginalSource as Button;

                        if (button != null)
                        {
                            command.Execute(button);
                        }
                    }
                }
            }
        }

    }
}

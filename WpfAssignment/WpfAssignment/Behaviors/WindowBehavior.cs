namespace WpfAssignment.Behaviors
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Window behavior
    /// </summary>
    public class WindowBehavior
    {
        private static DependencyProperty _property;
        private static readonly RoutedEvent _windowsLoadedEvent = Window.LoadedEvent;

        /// <summary>
        /// The window loaded command property
        /// </summary>
        public static readonly DependencyProperty WindowLoadedCommandProperty =
            DependencyProperty.RegisterAttached("WindowLoadedCommand",
            typeof(ICommand), typeof(WindowBehavior),
            new PropertyMetadata(new PropertyChangedCallback(WindowLoadedCallBack)));

        /// <summary>
        /// Sets the window loaded command.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        public static void SetWindowLoadedCommand(UIElement obj, ICommand value)
        {
            obj.SetValue(WindowLoadedCommandProperty, value);
        }

        /// <summary>
        /// Gets the window loaded command.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static ICommand GetWindowLoadedCommand(UIElement obj)
        {
            return (ICommand)obj.GetValue(WindowLoadedCommandProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        static void WindowLoadedCallBack(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            UIElement element = obj as UIElement;
            _property = args.Property;

            if (element != null)
            {
                if (args.OldValue != null)
                {
                    element.AddHandler(_windowsLoadedEvent, new RoutedEventHandler(LoadedEventHandler));
                }

                if (args.NewValue != null)
                {
                    element.AddHandler(_windowsLoadedEvent, new RoutedEventHandler(LoadedEventHandler));
                }
            }
        }

        /// <summary>
        /// Invokes the handler tied to the load command in the view model.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public static void LoadedEventHandler(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = sender as DependencyObject;

            if (obj != null)
            {
                ICommand command = obj.GetValue(_property) as ICommand;

                if (command != null)
                {
                    if (command.CanExecute(e))
                    {
                        Window window = e.OriginalSource as Window;

                        if (window != null)
                        {
                            command.Execute(window);
                        }
                    }
                }
            }
        }
    }
}

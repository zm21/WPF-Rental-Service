using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using JetBrains.Annotations;

namespace Scar.Common.WPF.Controls.Behaviors
{
    public static class KeyboardFocusBehavior
    {
        public static readonly DependencyProperty OnProperty;

        static KeyboardFocusBehavior()
        {
            OnProperty = DependencyProperty.RegisterAttached("On", typeof(FrameworkElement),
                typeof(KeyboardFocusBehavior), new PropertyMetadata(OnSetCallback));
        }

        [CanBeNull]
        public static FrameworkElement GetOn([NotNull] UIElement element)
        {
            return (FrameworkElement) element.GetValue(OnProperty);
        }

        private static void OnSetCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var frameworkElement = (FrameworkElement) dependencyObject;
            var target = GetOn(frameworkElement);

            if (target == null) return;

            frameworkElement.Loaded += (s, e) =>
            {
                var parent = VisualTreeHelper.GetParent(frameworkElement);
                while (parent != null && !(parent is Window)) parent = VisualTreeHelper.GetParent(parent);

                var window = parent as Window;
                if (window?.ShowActivated == true || window == null) Keyboard.Focus(target);
            };
        }

        public static void SetOn([NotNull] UIElement element, FrameworkElement value)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            element.SetValue(OnProperty, value);
        }
    }
}
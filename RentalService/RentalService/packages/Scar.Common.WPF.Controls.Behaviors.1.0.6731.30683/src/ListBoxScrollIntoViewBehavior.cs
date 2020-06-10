using System;
using System.Windows.Controls;
using System.Windows.Interactivity;
using JetBrains.Annotations;

namespace Scar.Common.WPF.Controls.Behaviors
{
    public sealed class ListBoxScrollIntoViewBehavior : Behavior<ListBox>
    {
        /// <summary>
        ///     On Selection Changed
        /// </summary>
        private static void AssociatedObject_SelectionChanged([NotNull] object sender,
            [NotNull] SelectionChangedEventArgs e)
        {
            if (!(sender is ListBox listBox)) return;

            if (listBox.SelectedItems.Count > 1) return;

            if (listBox.SelectedItem == null) return;

            listBox.Dispatcher.BeginInvoke(
                (Action) (() =>
                {
                    listBox.UpdateLayout();
                    if (listBox.SelectedItem != null) listBox.ScrollIntoView(listBox.SelectedItem);
                }));
        }

        /// <summary>
        ///     When Behavior is attached
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        /// <summary>
        ///     When behavior is detached
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }
    }
}
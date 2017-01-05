using System;
using System.Collections;
using Xamarin.Forms;

namespace HO.Apps.Renderers
{
    public class BindablePicker : Picker
    {
        /// <summary>Event that is raised when a new item is selected.</summary>
        /// <remarks>To be added.</remarks>
        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IEnumerable>(t => t.ItemsSource, null, propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create<BindablePicker, object>(t => t.SelectedItem, null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        public BindablePicker()
        {
            SelectedIndexChanged += (o, e) =>
            {
                if (SelectedIndex < 0 || ItemsSource == null || !ItemsSource.GetEnumerator().MoveNext())
                {
                    SelectedItem = null;
                    return;
                }

                var index = 0;
                foreach (var item in ItemsSource)
                {
                    if (index == SelectedIndex)
                    {
                        SelectedItem = item;
                        break;
                    }
                    index++;
                }
            };
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public Object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                if (SelectedItem != value)
                {
                    SetValue(SelectedItemProperty, value);
                    InternalUpdateSelectedIndex();
                }
            }
        }

        private void InternalUpdateSelectedIndex()
        {
            var selectedIndex = -1;
            if (ItemsSource != null)
            {
                var index = 0;
                foreach (var item in ItemsSource)
                {
                    if (item != null && item.Equals(SelectedItem))
                    {
                        selectedIndex = index;
                        break;
                    }
                    index++;
                }
            }
            SelectedIndex = selectedIndex;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
        {
            var boundPicker = (BindablePicker)bindable;

            if (Equals(newValue, null) && !Equals(oldValue, null))
                return;

            boundPicker.Items.Clear();

            if (!Equals(newValue, null))
            {
                foreach (var item in newValue)
                    boundPicker.Items.Add(item.ToString());
            }

            boundPicker.InternalUpdateSelectedIndex();
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var boundPicker = (BindablePicker)bindable;
            if (boundPicker.ItemSelected != null)
            {
                boundPicker.ItemSelected(boundPicker, new SelectedItemChangedEventArgs(newValue));
            }
            boundPicker.InternalUpdateSelectedIndex();
        }
    }
}
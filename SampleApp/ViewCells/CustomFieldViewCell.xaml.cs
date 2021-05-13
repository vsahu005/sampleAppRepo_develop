using System;
using System.Collections.Generic;
using System.Globalization;
using SampleApp.Models;
using Xamarin.Forms;

namespace SampleApp.ViewCells
{
    public partial class CustomFieldViewCell : ContentView
    {
        public event EventHandler ValueChaged;
        public CustomFieldViewCell()
        {
            InitializeComponent();
            BindingContextChanged += OnBindingContextChanged;
        }


        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            var field = (Field)BindingContext;
            AddFields(field);
        }

        #region Private methods
        void AddFields(Field field)
        {
            if (field is null)
            {
                return;
            }

            var view = GetField(field);
            slParentView.Children.Add(view);
        }

        View GetField(Field field)
        {
            switch (field.Type)
            {
                case "textbox":
                    return GetEntry(field, false);
                case "dropdown":
                    Picker picker = new Picker { HeightRequest = Constants.Constant.FieldHeight, ItemsSource = field.DropdownValues, Title = $"Select {field.Label}" };
                    picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
                    return picker;
                case "numericTextBox":
                    return GetEntry(field, true);
                default:
                    return default;

            }
        }
        #endregion


        /// <summary>
        /// we can also create a method which will take entry type
        /// and will return keyboard
        /// e.g. numericTextBox=>Keyboard.Numeric
        /// </summary>
        private Entry GetEntry(Field field, bool isNumeric)
        {
            Entry textEntry = new Entry
            {
                HeightRequest = Constants.Constant.FieldHeight,
                Placeholder = $"Enter {field.Label}",
                Keyboard = isNumeric ? Keyboard.Numeric : default,
                MaxLength = isNumeric ? Constants.Constant.NumberInputLength : int.MaxValue,

            };
            textEntry.TextChanged += OnTextChanged;

            return textEntry;
        }

        #region Event handlers
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry.Keyboard == Keyboard.Numeric && !string.IsNullOrEmpty(e.NewTextValue))
            {
                var intValue = Convert.ToInt32(e.NewTextValue);
                if (intValue >= Constants.Constant.MinRating && intValue <= Constants.Constant.MaxRating)
                {
                    ((Field)BindingContext).Value = e.NewTextValue;
                    ValueChaged?.Invoke(sender, e);
                }
                else
                {
                    entry.Text = default;
                    return;
                }
            }
            else
            {
                ((Field)BindingContext).Value = e.NewTextValue;
                ValueChaged?.Invoke(sender, e);
            }
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            ((Field)BindingContext).Value = picker.SelectedItem.ToString();
            ValueChaged?.Invoke(sender, e);
        }
        #endregion
    }
}

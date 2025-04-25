using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StoreManager.Converters
{
    // Конвертер для отображения placeholder'ов в TextBox
    public class BooleanToVisibilityConverter : IValueConverter
    {
        // Преобразует boolean (IsEmpty) в Visibility для TextBlock
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool isEmpty && isEmpty ? Visibility.Visible : Visibility.Collapsed;
        }

        // Обратное преобразование не используется
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
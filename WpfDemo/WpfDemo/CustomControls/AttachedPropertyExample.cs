using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfDemo {
    static class AttachedPropertyExample {


        public static bool GetAllowOnlyString(DependencyObject obj) {
            return (bool)obj.GetValue(AllowOnlyStringProperty);
        }

        public static void SetAllowOnlyString(DependencyObject obj, bool value) {
            obj.SetValue(AllowOnlyStringProperty, value);
        }

        // Using a DependencyProperty as the backing store for AllowOnlyString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowOnlyStringProperty =
            DependencyProperty.RegisterAttached("AllowOnlyString", typeof(bool), typeof(AttachedPropertyExample), new PropertyMetadata(false, MakeAlphaStringYellow));

        private static void MakeAlphaStringYellow(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (d is TextBlock) {
                TextBlock txtObj = (TextBlock)d;
                if (Regex.IsMatch(txtObj.Text, @"^([a-zA-Z]| )*$")) {
                    txtObj.Foreground = Brushes.DarkGoldenrod;
                };
            }
        }
    }
}

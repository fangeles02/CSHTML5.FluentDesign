using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Fluent
{
    public class ProgressBar : UserControl
    {
        public double Maximum
        {
            get; set;

        }
        public double Value
        {
            get; set;
        }


        public new Brush Foreground
        {
            get; set;
        } = (Brush)Colors.DodgerBlue;


        public new Brush Background
        {
            get; set;
        } = (Brush)Colors.LightGray;


        public bool RoundedCorners
        {
            get; set;
        } = false;




        double d_progress;
        double d_computed_maximum;

        int d_new_progress_width;

        Border InnerControl;
        Border OuterControl;


        public ProgressBar()
        {
            this.Height = 8;
             OuterControl = new Border { Background = Background, ClipToBounds = true };

      

            InnerControl = new Border { Background = Foreground, Width = 100, HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left };

            OuterControl.Child = InnerControl;
            this.Content = OuterControl;

            this.Loaded += ProgressBar2_Loaded;


            Window.Current.SizeChanged += Current_SizeChanged;
        }






        private void ProgressBar2_Loaded(object sender, RoutedEventArgs e)
        {
            compute_percentage();
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            compute_percentage();
        }

        private void compute_percentage()
        {
            if (RoundedCorners == true)
            {
                OuterControl.CornerRadius = new CornerRadius(this.Height);
                InnerControl.CornerRadius = new CornerRadius(this.Height);
            }
            else
            {
                OuterControl.CornerRadius = new CornerRadius(0);
                InnerControl.CornerRadius = new CornerRadius(0);
            }

            OuterControl.Background = Background;
            InnerControl.Background = Foreground;

            try
            {
                d_computed_maximum = this.ActualWidth;

                if (Maximum == 0)
                {
                    d_progress = 0;
                }
                else
                {
                    d_progress = Value / Maximum;
                }



                d_new_progress_width = Convert.ToInt32(d_computed_maximum * d_progress);

                InnerControl.Width = d_new_progress_width;
            }
            catch (Exception)
            {
                InnerControl.Width = 0;
            }



        }


        public void SetValue(double NewValue)
        {
            Value = NewValue;
            compute_percentage();
        }
    }
}

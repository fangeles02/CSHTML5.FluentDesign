using CSHTML5.Native.Html.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Fluent
{

    public enum ProgressRing_Size
    {
        PROGRESS_SMALL,
        PROGRESS_MEDIUM,
        PROGRESS_LARGE
    }


    public enum ProgressRing_Color
    {
        PROGRESS_BLACK,
        PROGRESS_WHITE,
        PROGRESS_THEME
    }



    public partial class ProgressRing : UserControl
    {




        private ProgressRing_Size SelectedSize;
        ProgressRing_Color ProgressColor = ProgressRing_Color.PROGRESS_THEME;



        public ProgressRing_Size RingSize
        {
            get { return SelectedSize; }
            set
            {
                SelectedSize = value;
                RaisePropertyChanged("RingSize");
            }
        }


        public ProgressRing_Color RingColor
        {
            get { return ProgressColor; }
            set
            {
                ProgressColor = value;
                RaisePropertyChanged("RingColor");
            }
        }



        public ProgressRing()
        {
            this.InitializeComponent();

        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            var res_color = Application.Current.Resources["ImmersiveSystemAccentBrushBrush"] as SolidColorBrush;
            string s_colour = res_color.ToString().Replace("#FF", "#");


            string s_selected_color_mode;

            if (ProgressColor == ProgressRing_Color.PROGRESS_BLACK)
            {
                s_selected_color_mode = " progress-black";
            }
            else if (ProgressColor == ProgressRing_Color.PROGRESS_WHITE)
            {
                s_selected_color_mode = " progress-white";
            }
            else
            {
                s_selected_color_mode = "";
            }




            string s_size = "";

            if (SelectedSize == ProgressRing_Size.PROGRESS_SMALL)
            {
                s_size = "";
            }
            else if (SelectedSize == ProgressRing_Size.PROGRESS_MEDIUM)
            {
                s_size = " progress-medium";
            }
            else if (SelectedSize == ProgressRing_Size.PROGRESS_LARGE)
            {
                s_size = " progress-large";
            }



            HTML1.Html = @"
<head>
                            <style type='text/css'>
                                .progress-ring {
  position: relative;
  width: 20px;
  height: 20px;
  text-align: left;
  display: inline-block; }
  .progress-ring .progress-circle {
    position: absolute;
    top: 0;
    left: 0;
    width: 20px;
    height: 20px;
    opacity: 0;
    -webkit-transform: rotate(225deg);
    -ms-transform: rotate(225deg);
    -o-transform: rotate(225deg);
    transform: rotate(225deg);
    -webkit-animation: progress-ring-animation 5s infinite;
    -o-animation: progress-ring-animation 5s infinite;
    animation: progress-ring-animation 5s infinite; }
    .progress-ring .progress-circle:after {
      content: ""\2022"";
      position: absolute;
      font-size: 10px;
      color: " + s_colour + @"; }
    .progress-ring .progress-circle:nth-child(2) {
      -webkit-animation-delay: 300ms;
      animation-delay: 300ms; }
    .progress-ring .progress-circle:nth-child(3) {
      -webkit-animation-delay: 600ms;
      animation-delay: 600ms; }
    .progress-ring .progress-circle:nth-child(4) {
      -webkit-animation-delay: 900ms;
      animation-delay: 900ms; }
    .progress-ring .progress-circle:nth-child(5) {
      -webkit-animation-delay: 1200ms;
      animation-delay: 1200ms; }


  .progress-ring.progress-medium {
    width: 40px;
    height: 40px; }
  .progress-ring.progress-large {
    width: 60px;
    height: 60px; }
	
  .progress-ring.progress-white{
	color: #FFFFFF; }

  .progress-ring.progress-black{
	color: #000000; }
	
	
  .progress-ring.progress-medium .progress-circle {
    width: 40px;
    height: 40px; }
    .progress-ring.progress-medium .progress-circle:after {
      font-size: 16px; }
	  
	  
  .progress-ring.progress-large .progress-circle {
    width: 60px;
    height: 60px; }
    .progress-ring.progress-large .progress-circle:after {
      font-size: 20px; }
	  
	
	
   .progress-ring.progress-white .progress-circle:after{
      color: #FFFFFF;   }

   .progress-ring.progress-black .progress-circle:after{
      color: #000000;   }





@-webkit-keyframes progress-ring-animation {
  0% {
    -webkit-transform: rotate(225deg);
    -ms-transform: rotate(225deg);
    -o-transform: rotate(225deg);
    transform: rotate(225deg);
    opacity: 1;
    -webkit-animation-timing-function: ease-out;
    animation-timing-function: ease-out; }
  7% {
    -webkit-transform: rotate(345deg);
    -ms-transform: rotate(345deg);
    -o-transform: rotate(345deg);
    transform: rotate(345deg);
    -webkit-animation-timing-function: linear;
    animation-timing-function: linear; }
  30% {
    -webkit-transform: rotate(455deg);
    -ms-transform: rotate(455deg);
    -o-transform: rotate(455deg);
    transform: rotate(455deg);
    -webkit-animation-timing-function: ease-in-out;
    animation-timing-function: ease-in-out; }
  39% {
    -webkit-transform: rotate(690deg);
    -ms-transform: rotate(690deg);
    -o-transform: rotate(690deg);
    transform: rotate(690deg);
    -webkit-animation-timing-function: linear;
    animation-timing-function: linear; }
  70% {
    -webkit-transform: rotate(815deg);
    -ms-transform: rotate(815deg);
    -o-transform: rotate(815deg);
    transform: rotate(815deg);
    opacity: 1;
    -webkit-animation-timing-function: ease-out;
    animation-timing-function: ease-out; }
  75% {
    -webkit-transform: rotate(945deg);
    -ms-transform: rotate(945deg);
    -o-transform: rotate(945deg);
    transform: rotate(945deg);
    -webkit-animation-timing-function: ease-out;
    animation-timing-function: ease-out; }
  76% {
    -webkit-transform: rotate(945deg);
    -ms-transform: rotate(945deg);
    -o-transform: rotate(945deg);
    transform: rotate(945deg);
    opacity: 0; }
  100% {
    -webkit-transform: rotate(945deg);
    -ms-transform: rotate(945deg);
    -o-transform: rotate(945deg);
    transform: rotate(945deg);
    opacity: 0; } }

@keyframes progress-ring-animation {
  0% {
    -webkit-transform: rotate(225deg);
    -ms-transform: rotate(225deg);
    -o-transform: rotate(225deg);
    transform: rotate(225deg);
    opacity: 1;
    -webkit-animation-timing-function: ease-out;
    animation-timing-function: ease-out; }
  7% {
    -webkit-transform: rotate(345deg);
    -ms-transform: rotate(345deg);
    -o-transform: rotate(345deg);
    transform: rotate(345deg);
    -webkit-animation-timing-function: linear;
    animation-timing-function: linear; }
  30% {
    -webkit-transform: rotate(455deg);
    -ms-transform: rotate(455deg);
    -o-transform: rotate(455deg);
    transform: rotate(455deg);
    -webkit-animation-timing-function: ease-in-out;
    animation-timing-function: ease-in-out; }
  39% {
    -webkit-transform: rotate(690deg);
    -ms-transform: rotate(690deg);
    -o-transform: rotate(690deg);
    transform: rotate(690deg);
    -webkit-animation-timing-function: linear;
    animation-timing-function: linear; }
  70% {
    -webkit-transform: rotate(815deg);
    -ms-transform: rotate(815deg);
    -o-transform: rotate(815deg);
    transform: rotate(815deg);
    opacity: 1;
    -webkit-animation-timing-function: ease-out;
    animation-timing-function: ease-out; }
  75% {
    -webkit-transform: rotate(945deg);
    -ms-transform: rotate(945deg);
    -o-transform: rotate(945deg);
    transform: rotate(945deg);
    -webkit-animation-timing-function: ease-out;
    animation-timing-function: ease-out; }
  76% {
    -webkit-transform: rotate(945deg);
    -ms-transform: rotate(945deg);
    -o-transform: rotate(945deg);
    transform: rotate(945deg);
    opacity: 0; }
  100% {
    -webkit-transform: rotate(945deg);
    -ms-transform: rotate(945deg);
    -o-transform: rotate(945deg);
    transform: rotate(945deg);
    opacity: 0; } }
                            </style>
                        </head>


                        <div class=""progress-ring" + s_size + @"" + s_selected_color_mode + @""">
                            <div class=""progress-circle""></div>
                            <div class=""progress-circle""></div>
                            <div class=""progress-circle""></div>
                            <div class=""progress-circle""></div>
                            <div class=""progress-circle""></div>
                        </div>
";

        }
    }
}
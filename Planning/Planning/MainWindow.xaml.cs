using System;
using System.Windows;

namespace Planning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            start();
        }

        public void start()
        {
            Route route = new Route("aalborg", "odense", "århus", "vodskov");
            route.CalculateRoute();


            Console.WriteLine(route.CreateRequestURL());

            Console.WriteLine("Distance : " + route.distance.ToString() + " km");
            Console.WriteLine("Duration : " + route.duration + " (hh:mm:ss)");



            Console.ReadKey();
        }
    }
}

using System;
using System.Windows;
using Planning.Modules;

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
            Route route = new Route(10, "aalborg", "odense", "århus", "vodskov");
            route.CalculateRoute();


            Console.WriteLine(route.CreateRequestURL());

            Console.WriteLine("Distance : " + route.Distance.ToString() + " km");
            Console.WriteLine("Duration : " + route.Duration + " (hh:mm:ss)");



            Console.ReadKey();
        }
    }
}

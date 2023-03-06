using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp13.Commands;
using WpfApp13.Models;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string SomeText
        {
            get { return (string)GetValue(SomeTextProperty); }
            set { SetValue(SomeTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SomeText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SomeTextProperty =
            DependencyProperty.Register("SomeText", typeof(string), typeof(MainWindow));





        public User User
        {
            get { return (User)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for User.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(User), typeof(MainWindow));



        public MessageCommand MessageCommand { get; set; }
        public DisplayCommand DisplayTimeCommand { get; set; }
        public SubmitCommand SubmitCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            SomeText = "Enter Name";

            User = new User();

            MessageCommand = new MessageCommand(() =>
            {
                MessageBox.Show($@"Data : {SomeText}
                                    You clicked to Message Button");
            });

            DisplayTimeCommand = new DisplayCommand(() =>
            {
                MessageBox.Show($"Welcome {SomeText} , Now Time is {DateTime.Now}");
            });

            SubmitCommand = new SubmitCommand(() =>
            {
                File.WriteAllText($"{User.Name}.txt",$"{User.Name} {User.Surname}");
            });

            this.DataContext = this;
        }

        //private void Help_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (SomeText.Length < 10)
        //        {
        //            e.CanExecute = false;
        //        }
        //        else
        //        {
        //            e.CanExecute = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    Process.Start("calc.exe");
        //}
    }
}

using Milicija.Database;
using Milicija.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace Milicija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            //PoliceContainer pc = new PoliceContainer();
            //var cop = new Cop
            //{
            //    JMBG = "0302999790034",
            //    Name = "Nikola",
            //    LastName = "Zivanovic",
            //    Station = new Station(),
            //    Rank = new Rank() { Name = "Lieutenant" },
            //    Warrants = new List<Warrant>()
            //};
            //try
            //{
            //    pc.Employees.Add(cop);
            //    pc.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}

            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = new MainWindowViewModel(); };
        }
    }
}

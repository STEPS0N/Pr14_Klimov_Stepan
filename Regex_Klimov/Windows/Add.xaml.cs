using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Regex_Klimov.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Classes.Passport EditPassport;
        
        public Add(Classes.Passport EditPassport)
        {
            InitializeComponent();

            if (EditPassport != null)
            {
                Name.Text = EditPassport.Name;

                Firstname.Text = EditPassport.Firstname;

                Lastname.Text = EditPassport.Lastname;

                Issued.Text = EditPassport.Issued;

                DateOfIssued.Text = EditPassport.DateOfIssued;

                DepartmentCode.Text = EditPassport.DepartmentCode;

                SeriesAndNumber.Text = EditPassport.SeriesAndNumber;

                DateOfBirth.Text = EditPassport.DateOfBirth;

                PlaceOfBirth.Text = EditPassport.PlaceOfBirth;

                this.EditPassport = EditPassport;

                BtnAdd.Content = "Изменить";
            }
        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Name.Text))
            {
                MessageBox.Show("Неправильно указано имя пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(Firstname.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Firstname.Text))
            {
                MessageBox.Show("Неправильно указана фамилия пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(Lastname.Text) || !Classes.Common.CheckRegex.Match("^[а-яА-я]*$", Lastname.Text))
            {
                MessageBox.Show("Неправильно указано отчество пользователя!");
                return;
            }

            if (EditPassport == null)
            {
                EditPassport = new Classes.Passport();
                MainWindow.init.Passports.Add(EditPassport);
            }

            EditPassport.Name = Name.Text;
            EditPassport.Firstname = Firstname.Text;
            EditPassport.Lastname = Lastname.Text;
            EditPassport.Issued = Issued.Text;
            EditPassport.DateOfIssued = DateOfIssued.Text;
            EditPassport.DepartmentCode = DepartmentCode.Text;
            EditPassport.SeriesAndNumber = SeriesAndNumber.Text;
            EditPassport.DateOfBirth = DateOfBirth.Text;
            EditPassport.PlaceOfBirth = PlaceOfBirth.Text;

            MainWindow.init.Passports.LoadPassport();
            this.Close();
        }
    }
}

using Microsoft.Win32;
using Regex_Klimov.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Regex_Klimov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Passport> Passports = new List<Passport>();
        public static MainWindow init;
        
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            LoadSampleData();
        }

        public void LoadPassport()
        {
            lv_passport.Items.Clear();
            foreach (Passport Passport in Passports)
            {
                lv_passport.Items.Add(Passport);
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            new Windows.Add(null).ShowDialog();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedItem is Passport selectedPassport)
            {
                new Windows.Add(selectedPassport).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (lv_passport.SelectedIndex > -1)
            {
                Passports.Remove(lv_passport.SelectedItem as Classes.Passport);
                LoadPassport();
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }

        private void ChangeText(object sender, TextChangedEventArgs e)
        {
            string search = Search.Text.Trim().ToLower();
            List<Passport> filteredPassport;

            if (string.IsNullOrEmpty(search))
            {
                filteredPassport = Passports;
            }
            else
            {
                filteredPassport = Passports.Where(x =>x.Name.ToLower().Contains(search) || x.Firstname.ToLower().Contains(search) || x.Lastname.ToLower().Contains(search)).ToList();
            }

            lv_passport.Items.Clear();
            
            foreach (Passport passport in filteredPassport)
            {
                lv_passport.Items.Add(passport);
            }
        }

        private void LoadSampleData()
        {
            Passports.Add(new Passport
            {
                Name = "Иван",
                Firstname = "Иванов",
                Lastname = "Иванович",
                Issued = "ОУФМС России по г. Москве",
                DateOfIssued = "15.05.2020",
                DepartmentCode = "770-101",
                SeriesAndNumber = "4510 123456",
                DateOfBirth = "12.03.1985",
                PlaceOfBirth = "г. Москва",
                Picture = "pack://application:,,,/Images/passport.jpg"
            });

            Passports.Add(new Passport
            {
                Name = "Мария",
                Firstname = "Петрова",
                Lastname = "Сергеевна",
                Issued = "ОУФМС России по г. Санкт-Петербургу",
                DateOfIssued = "20.08.2019",
                DepartmentCode = "780-102",
                SeriesAndNumber = "4611 654321",
                DateOfBirth = "25.07.1990",
                PlaceOfBirth = "г. Санкт-Петербург",
                Picture = "pack://application:,,,/Images/passport.jpg"
            });

            Passports.Add(new Passport
            {
                Name = "Алексей",
                Firstname = "Сидоров",
                Lastname = "Владимирович",
                Issued = "ОУФМС России по г. Екатеринбургу",
                DateOfIssued = "10.12.2021",
                DepartmentCode = "660-103",
                SeriesAndNumber = "5012 789012",
                DateOfBirth = "03.11.1988",
                PlaceOfBirth = "г. Екатеринбург",
                Picture = "pack://application:,,,/Images/passport.jpg"
            });

            Passports.Add(new Passport
            {
                Name = "Елена",
                Firstname = "Козлова",
                Lastname = "Андреевна",
                Issued = "ОУФМС России по г. Новосибирску",
                DateOfIssued = "05.03.2018",
                DepartmentCode = "540-104",
                SeriesAndNumber = "5213 345678",
                DateOfBirth = "18.09.1992",
                PlaceOfBirth = "г. Новосибирск",
                Picture = "pack://application:,,,/Images/passport.jpg"
            });

            Passports.Add(new Passport
            {
                Name = "Дмитрий",
                Firstname = "Смирнов",
                Lastname = "Олегович",
                Issued = "ОУФМС России по г. Казани",
                DateOfIssued = "22.11.2022",
                DepartmentCode = "160-105",
                SeriesAndNumber = "5314 987654",
                DateOfBirth = "30.01.1987",
                PlaceOfBirth = "г. Казань",
                Picture = "pack://application:,,,/Images/passport.jpg"
            });

            LoadPassport();
        }
    }
}
using System.Windows;

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

                BtnAdd.Content = "Сохранить";
            }
        }

        private void AddPassport(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || !Classes.Common.CheckRegex.Match("^[А-ЯЁ][а-яё]*$", Name.Text))
            {
                MessageBox.Show("Неправильно указано имя пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(Firstname.Text) || !Classes.Common.CheckRegex.Match("^[А-ЯЁ][а-яё]*$", Firstname.Text))
            {
                MessageBox.Show("Неправильно указана фамилия пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(Lastname.Text) || !Classes.Common.CheckRegex.Match("^[А-ЯЁ][а-яё]*$", Lastname.Text))
            {
                MessageBox.Show("Неправильно указано отчество пользователя!");
                return;
            }

            if (string.IsNullOrEmpty(Issued.Text) || !Classes.Common.CheckRegex.Match("^[А-ЯЁ0-9\\s]*$", Issued.Text))
            {
                MessageBox.Show("Неправильно указано кем выдан паспорт!");
                return;
            }

            if (string.IsNullOrEmpty(DateOfIssued.Text) || !Classes.Common.CheckRegex.Match("^\\d{2}[.]\\d{2}[.]\\d{4}$", DateOfIssued.Text))
            {
                MessageBox.Show("Неправильно указана дата выдачи паспорта!");
                return;
            }

            if (string.IsNullOrEmpty(DepartmentCode.Text) || !Classes.Common.CheckRegex.Match("^\\d{3}[-]\\d{3}$", DepartmentCode.Text))
            {
                MessageBox.Show("Неправильно указан код подразделения!");
                return;
            }

            if (string.IsNullOrEmpty(SeriesAndNumber.Text) || !Classes.Common.CheckRegex.Match("^\\d{4}[- ]\\d{6}$", SeriesAndNumber.Text))
            {
                MessageBox.Show("Неправильно указаны серия и номер паспорта!");
                return;
            }

            if (string.IsNullOrEmpty(DateOfBirth.Text) || !Classes.Common.CheckRegex.Match("^\\d{2}[.]\\d{2}[.]\\d{4}$", DateOfBirth.Text))
            {
                MessageBox.Show("Неправильно указана дата рождения гражданина!");
                return;
            }

            if (string.IsNullOrEmpty(PlaceOfBirth.Text) || !Classes.Common.CheckRegex.Match("^[А-Яа-яЁё0-9.\\-, ]*$", PlaceOfBirth.Text))
            {
                MessageBox.Show("Неправильно указано место рождения гражданина!");
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

            MainWindow.init.LoadPassport();
            this.Close();
        }
    }
}

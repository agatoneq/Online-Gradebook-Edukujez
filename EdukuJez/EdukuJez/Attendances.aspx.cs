using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using EdukuJez.Model.ServerAccess.Repositories;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EdukuJez
{
    public partial class Attendances : System.Web.UI.Page
    {
        User currentuser = UserSession.GetSession()?.user;
        DataTable dataTable = new DataTable();
        AttendancesRepository attendancesRepo = new AttendancesRepository();
        ScheduleRepository scheduleRepository = new ScheduleRepository();
        ClassUsersRepository classUsersRepository = new ClassUsersRepository();
       
        string dayOfWeek;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                
                   // LoadAttendanceData();
            }
        }
       //zaznaczenie dnia w kalendarzu
        protected void Calendar1_SelectionChanged(object sender, EventArgs e) 
        {
            switch (Calendar1.SelectedDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayOfWeek = "Poniedzialek";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "Wtorek";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "Sroda";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "Czwartek";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "Piatek";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "Sobota";
                    break;
                case DayOfWeek.Sunday:
                    dayOfWeek = "Niedziela";
                    break;
                default:
                    dayOfWeek = "Wystąpił problem z dniem tyg.";
                    break;
            }
            dataTable.Clear();

            //wiersz z data i dniem tyg:
            var date = Calendar1.SelectedDate.ToString().Substring(0, 10); //wybrana data bez godziny

            dataTable.Columns.Add(date + " " + dayOfWeek); //pierwszy wiersz to data i dzien tygodnia
            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == true) //jesli zalogowany jest adminem
            {
                SelectedDateAdmin();
            }
            else if (UserSession.CheckPermission(UserSession.STUDENT_GROUP) == true) //jesli zalogowany jest uczniem
            {
                SelectedDateStudent(currentuser);
            }
            else if (UserSession.CheckPermission(UserSession.PARENT_GROUP) == true) //jesli zalogowany jest rodzicem
            {
                SelectedDateStudent(UserSession.GetSession().checkedChild);
            }
            else if (UserSession.CheckPermission(UserSession.TEACHER_GROUP) == true)
            {
                SelectedDateTeacher();
            }
            
            AttendanceGridView.DataSource = dataTable;
            AttendanceGridView.DataBind();
            AttendanceGridView.Visible = true;
        }
        void SelectedDateStudent(User uczen) 
        {
            List<ClassC> classes  = classUsersRepository.Table.Include(x=>x.Class.Attendances).Include(x=>x.Class.Subject).Include(x => x.Class.Group).Where(x => x.Class.Day == dayOfWeek && x.Class.Group.Users.Any(y=>y.User == currentuser)).Select(x => x.Class).ToList();  //zajecia w ktorych bierze udzial zalogowany uzytkownik, ktore odbywaja sie dnia zaznaczonego w kalendarzu

            //wiersze z zajeciami:
            if (classes.Count == 0) //jesli nie ma zajec wybranego dnia
            {
                DataRow row = dataTable.NewRow();
                row[0] = "Brak zajęć do wyświetlenia";
                dataTable.Rows.Add(row);
            }
            else //jesli sa jakies zajecia wybranego dnia
            {
                int numClass = 0;
                foreach (var c in classes) //uzupelnianie tabeli
                {
                    var attendance = c.Attendances.Select(x => x.Presence).ToString(); //obecnosc na zajeciach c
                    if (attendance == "" || c.Attendances.Count == 0)
                    {
                        attendance = "brak wpisu";
                    }
                    DataRow row = dataTable.NewRow();
                    row[0] =c.Subject.SubjectName + "\n" + attendance; //wiersz z nazwą przedmiotu i obecnoscia

                    if (attendance == "+") //jesli obecny na zielono
                    {
                        AttendanceGridView.Rows[numClass].ForeColor = Color.Green;
                    }
                    else if (attendance == "-") //jesli nieobecny na czerwono
                    {
                        AttendanceGridView.Rows[numClass].BackColor = Color.Red;
                    }
                    //INNE OPCJE DO DOPISANIA

                    dataTable.Rows.Add(row);
                    numClass++;
                }
            }
        }
        void SelectedDateTeacher()
        {
            List<ClassC> classes = classUsersRepository.Table.Include(x=>x.Class.Subject).Where(x=>x.Class.Day == dayOfWeek && x.Class.Warden == currentuser).Select(x=>x.Class).ToList(); //zajecia ktore ma (uczy) zalogowany
            if (classes.Count == 0) //jesli nie ma zajec wybranego dnia
            {
                DataRow row = dataTable.NewRow();
                row[0] = "Brak zajęć do wyświetlenia";
                dataTable.Rows.Add(row);
            }
            else //jesli ma jakies zajecia
            {
                foreach(var c in classes){ //wyswietlenie zajec wybranego dnia
                    DataRow row = dataTable.NewRow();

                    LinkButton linkButton = new LinkButton();
                    linkButton.ID = c.Subject.SubjectName;
                    linkButton.Text = c.Subject.SubjectName;
                    linkButton.CommandArgument = c.Subject.SubjectName;
                    linkButton.Click += new EventHandler(AttendancesInSubject); //metoda po kliknięciu w nazwę przedmiotu - wyświetlenie listy uczniow i ich obecnosci
                    //AttendanceGridView.Rows[AttendanceGridView.Rows.Count - 1].Controls.Add(linkButton);
                    row[0] = "TO DO";

                    dataTable.Rows.Add(row);
                }
            }
        }
        void SelectedDateAdmin()
        {

        }
        //wyswietlenie listy uczniow i ich obecnosci z wybranego przez nauczyciela przedmiotu w wybranym dniu
        void AttendancesInSubject(object sender, EventArgs e) 
        {
            LinkButton clickedButton = (LinkButton)sender;
            string subjectName = clickedButton.Text; //nazwa przedmiotu

            var students = attendancesRepo.Table //lista studentow ktorzy danego dnia maja zajecia o danej nazwie
                .Where(x => x.Class.Subject.SubjectName == subjectName && x.Date == Calendar1.SelectedDate) //przedmiot wybrany przez nauczyciela w konkretnym dniu
                .Select(y => y.Student).ToList();

            DataTable teachersDataTable = new DataTable();
            foreach(var s in students) //uzupelnienie tabeli imionami, nazwiskami i obecnoscia ucznia na wybranym przedmiocie w wybranej dacie
            {
                DataRow row = teachersDataTable.NewRow();
                row[0] = s.UserName + " " + s.UserSurname;
                row[1] = s.Attendance.Where(x=>x.Date == Calendar1.SelectedDate &&  x.Class.Subject.SubjectName == subjectName).Select(x => x.Presence).First(); //obecnosc ucznia
                teachersDataTable.Rows.Add(row);
            }

            TeacherGridView.DataSource = teachersDataTable;
            TeacherGridView.DataBind();
            TeacherGridView.Visible = true;
        }
    }
}

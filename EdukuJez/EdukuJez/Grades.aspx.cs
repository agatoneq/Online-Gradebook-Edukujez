using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using System.Data;

namespace EdukuJez
{
    public partial class Grades : System.Web.UI.Page
    {
        public DataTable dataTable = new DataTable(); //do gradegridview
        String permission;

        protected void Page_Load(object sender, EventArgs e)
        {
            //permission = UserSession.GetSession().UserGroup; //jest nullem
            permission = "nauczyciel";

            switch (permission)
            {
                case "uczen":
                    GroupDropDownList.Visible = false;
                    EditButton.Visible = false;
                    if (!IsPostBack)
                    {
                        //wybor przedmiotu:
                        var subjView_repo = new SubjViewRepository("Login = " + UserSession.GetSession().UserLogin);
                        for (int i = 0; i < subjView_repo.GetAll().Count; ++i)
                        {
                            SubjectsDropDownList.Items.Add(subjView_repo.GetAll()[i].SubjectName);
                        }
                    }
                    //kolumny tabeli:
                    dataTable.Columns.Add("Ocena", typeof(int));
                    dataTable.Columns.Add("Waga", typeof(int));
                    dataTable.Columns.Add("Aktywność", typeof(String));
                    var subject_repo = new SubjectsRepository("Subject = " + SubjectsDropDownList.SelectedValue);
                    try
                    {
                        var grades_repo = new GradesRepository("ID_Student = " + UserSession.GetSession().UserLogin + "and ID_Subject = " + subject_repo.GetAll().First().Id);
                        //wiersze tabeli:
                        foreach (var grade in grades_repo.Table) 
                        {
                            DataRow newRow = dataTable.NewRow();
                            newRow["Ocena"] = grade.GradeValue;
                            newRow["Waga"] = grade.GradeWeight;
                           // newRow["Aktywność"] = "Sprawdzian " + i; //jeszcze nie ma w bazie aktywnosci
                            dataTable.Rows.Add(newRow);
                        }
                    }
                    catch (InvalidOperationException exc) //jesli subject_repo.GetAll() jest puste
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["Aktywność"] = "Brak przypisanych przedmiotow";
                        dataTable.Rows.Add(newRow);
                    }
                    break;
                case "nauczyciel":

                    //wybor klasy/grupy ktora porowadzi dany nauczyciel:
                    //to do - tymczasowo statycznie
                    GroupDropDownList.Items.Add("1a");
                    GroupDropDownList.Items.Add("1b");
                    GroupDropDownList.Items.Add("2");
                    GroupDropDownList.Items.Add("3a");
                    GroupDropDownList.Items.Add("3b");
                    if (!IsPostBack)
                    {
                        //wybor przedmiotu danej klasy jesli zalogowany nauczyciel uczy ich wielec niz 1 przedmiotu
                        //to do - tymczasowo statycznie:
                        SubjectsDropDownList.Items.Add("Przedmiot1");
                        SubjectsDropDownList.Items.Add("Przedmiot2");
                        SubjectsDropDownList.Items.Add("Przedmiot3");
                    }
                    //kolumny:
                    dataTable.Columns.Add("Imię", typeof(String));
                    dataTable.Columns.Add("Nazwisko", typeof(String));
                    //kolumny:
                    for (int i = 1; i < 3; i++)
                    { //nazwy aktywnosci - tymczasowo statycznie
                        dataTable.Columns.Add("Aktywność" + i, typeof(int));  //jeszcze nie ma w bazie aktywnosci
                    }

                    //wiersze:
                    for (int i = 1; i < 6; i++) //tymczasowo statycznie
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow["Imię"] = "Imię" + i;
                        newRow["Nazwisko"] = "Nazwisko" + i;
                        newRow["Aktywność1"] = 5;
                        newRow["Aktywność2"] = 4;

                        dataTable.Rows.Add(newRow);
                    }
                    break;
                default:
                    //to do
                    break;
            }

            UserSession.CheckPermission("a", "b");

            //wrzucenie danych do tabeli:
            GradesGridView.DataSource = dataTable;
            GradesGridView.DataBind();

            /*
                //SubjectsDropDownList.SelectedValue;
                for (int i = 0; i < grades_repo.GetAll().Count; ++i) //wyswietlenie ocen //jeszcze nie - z wybranego przedmiotu
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["Grade"] = grades_repo.GetAll()[i].GradeValue;
                    newRow["Grade weight"] = grades_repo.GetAll()[i].GradeWeight;
                    dataTable.Rows.Add(newRow);
                }
            */
            /*
            //GradesGridView
            dataTable.Columns.Add("Grade", typeof(int));
            dataTable.Columns.Add("Grade weight", typeof(int));
            dataTable.Columns.Add("Name", typeof(String));
            dataTable.Columns.Add("Surname", typeof(String));
            for (int i = 1; i < 6; i++) 
            {
                DataRow newRow = dataTable.NewRow();
                newRow["Grade"] = i;
                newRow["Grade weight"] = 3;
                newRow["Name"] = "Jezy";
                newRow["Surname"] = "Jezowicz";
                dataTable.Rows.Add(newRow);
            }
            GradesGridView.DataSource = dataTable;
            GradesGridView.DataBind(); 
            */

        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {

            GradesGridView.Visible = true;
            if (permission == "nauczyciel")
            {
                EditButton.Visible = true;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //tryb edycji:
            //to do
            /* for()
             TextBox textBox1 = new TextBox();
             textBox1.ID = "TextBox1"; // Unikalny identyfikator dla kontrolki
             textBox1.Text = "Wartość początkowa"; // Domyślna wartość
             AddButton.Visible = true;
             SaveButton.Visible = true;*/
        }
    }
}
//for (int i = 0; i < tablica.Count; ++i)
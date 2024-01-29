using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace EdukuJez
{
    public partial class Grades : System.Web.UI.Page
    {
        public DataTable dataTable = new DataTable();
        public GradesRepository repoGrades = new GradesRepository();
        public SubjectsRepository repoSubj = new SubjectsRepository();
        public SubjViewRepository View = new SubjViewRepository();
        public GroupsRepository repoGroups = new GroupsRepository();
        String permission;
        User currentuser = UserSession.GetSession()?.user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == true || UserSession.CheckPermission(UserSession.TEACHER_GROUP) == true)
            {
                permission = "nauczyciel";
                ActivityButton.Visible = true;
            }
            else if (UserSession.CheckPermission(UserSession.PARENT_GROUP) == true)
            {
                permission = "uczen";
                currentuser = UserSession.GetSession().checkedChild;
            }
            else
                permission = "uczen";

            GroupDropDownList.Items.Clear();
            switch (permission)
            {
                case "uczen":
                    if (currentuser == null)
                    {
                        SubjectsDropDownList.Items.Add("Wybierz dziecko");
                    }
                    else
                    {
                        GroupDropDownList.Visible = false;
                        EditButton.Visible = false;
                        if (!IsPostBack)
                        {
                            var subjects = repoSubj.Table.Where(x => x.StudentGroup.Users.Any(y => y.User.Id == currentuser.Id)).Select(x => x.SubjectName).ToList();

                            if (subjects.Any())
                            {
                                SubjectsDropDownList.DataSource = subjects;
                                SubjectsDropDownList.DataBind();
                            }
                            else
                            {
                                SubjectsDropDownList.Items.Add("Brak przedmiotów do wyświetlenia");
                            }
                        }
                    }
                    break;
                case "nauczyciel":
                    var lista = repoGroups.Table.Include(x => x.Classes)
                        .Where(x => x.Classes.Any(c => c.Warden.Id == currentuser.Id))
                        .Select(x => x.Name)
                        .ToList();

                    SubjectsDropDownList.Items.Add("Najpierw wybierz grupę");

                    if (lista.Count() != 0)
                    {
                        foreach (var i in lista)
                        {
                            GroupDropDownList.Items.Add(i);
                        }
                        GroupDropDownList_SelectedIndexChanged(GroupDropDownList, new EventArgs());
                    }
                    else
                    {
                        GroupDropDownList.Items.Add("Brak przypisanych grup");
                    }
                    break;
                default:
                    //to do
                    break;
            }
        }

        protected void ShowButton_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            switch (permission)
            {
                case "uczen":
                    //kolumny tabeli:
                    dataTable.Columns.Add("Ocena", typeof(int));
                    dataTable.Columns.Add("Waga", typeof(int));
                    dataTable.Columns.Add("Aktywność", typeof(String));

                    var subject_repo = new SubjectsRepository("Subjects.Subject = '" + SubjectsDropDownList.SelectedValue + "'");
                    if (UserSession.GetSession() != null)
                    {
                        if (SubjectsDropDownList.SelectedValue == "Wybierz dziecko")
                        {
                            return;
                        }
                        var list = repoGrades.Table.Include(x => x.Users).Include(x => x.Activity)
                            .Where(x => x.Users.Id == currentuser.Id && x.Subject.SubjectName == SubjectsDropDownList.Text);
                        //wiersze tabeli:
                        if (list.Count() != 0)
                        {
                            Grade finalGrade = null;
                            foreach (var i in list)
                            {
                                if (i.Activity.IsFinalGrade == false) //jesli ta aktywnosc nie jest ocena koncowa
                                {
                                    DataRow newRow = dataTable.NewRow();
                                    newRow["Ocena"] = i.GradeValue;
                                    newRow["Waga"] = i.GradeWeight;
                                    newRow["Aktywność"] = i.Activity?.Name;
                                    dataTable.Rows.Add(newRow);
                                }
                                else
                                    finalGrade = i;
                            }
                            if (finalGrade != null) //ocena koncowa na koncu tabeli
                            {
                                DataRow newRow = dataTable.NewRow();
                                newRow["Ocena"] = finalGrade.GradeValue;
                                newRow["Aktywność"] = finalGrade.Activity?.Name;
                                dataTable.Rows.Add(newRow);
                            }
                        }
                        else
                        {
                            DataRow newRow = dataTable.NewRow();
                            newRow["Aktywność"] = "Brak przypisanych przedmiotow";
                            dataTable.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                    GradesGridView.DataSource = dataTable;
                    GradesGridView.DataBind();
                    GradesGridView.Visible = true;
                    break;
                case "nauczyciel":
                    BindGridView();
                    GradesGridView.Visible = true;
                    ActivityButton.Visible = true;
                    break;
                default:
                    //to do
                    break;
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //tryb edycji:

            for (int i = 2; i < dataTable.Columns.Count; ++i)
            { //edycja mozliwa dla kolumn zawiarajacych oceny
                dataTable.Columns[i].ReadOnly = false;
            }
            GradesGridView.DataSource = dataTable;
            GradesGridView.DataBind();
            EditButton.Visible = false;
        }

        //nauczyciel wybral grupe:
        protected void GroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubjectsDropDownList.Items.Clear();
            var lista = repoSubj.Table.Include(x => x.Classes)
                        .ThenInclude(x => x.Group)
                        .Where(x => x.Classes.Any(c => c.Group.Name == GroupDropDownList.SelectedValue))
                        .ToList();

            if (lista.Count() != 0)
            {
                foreach (var i in lista)
                {
                    SubjectsDropDownList.Items.Add(i.SubjectName);
                }
            }
            else
            {
                SubjectsDropDownList.Items.Add("Brak przedmiotów dla tej grupy");
            }
            SubjectsDropDownList_SelectedIndexChanged(SubjectsDropDownList, new EventArgs());
        }
        //nauczyciel/uczen wybral przedmiot:
        protected void SubjectsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowButton.Enabled = true; //moze wyswietlic
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            EditButton.Visible = true;
            GradesGridView.DataBind(); //powrot wartosci tabeli
        }


        protected void GradesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GradesGridView.Rows[e.NewEditIndex];
            GradesGridView.EditIndex = e.NewEditIndex;
            BindGridView();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (i == 1) // Zmień 1 na odpowiednią pozycję kolumny (numeracja od zera)       
                {
                    var textBox = row.Cells[i].Controls;
                    var c = 1 + 1;
                }
            }
        }
        private void AddEditButtonToGridView()
        {
            CommandField editField = new CommandField();
            editField.ButtonType = ButtonType.Button; // Możesz dostosować typ przycisku
            editField.ShowEditButton = true;

            GradesGridView.Columns.Add(editField);
        }

        protected void GradesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView gv = (GridView)sender;
            GridViewRow row = gv.Rows[e.RowIndex];
            var changeList = new List<int>();
            for (int i = 3; i < row.Cells.Count; i++)
            {
                var textBox = (TextBox)row.Cells[i].Controls[0];
                changeList.Add(Convert.ToInt32(textBox.Text));
            }
            var name = ((TextBox)row.Cells[1].Controls[0]).Text;
            var surname = ((TextBox)row.Cells[2].Controls[0]).Text;


            var grades = repoGrades.Table.Include(x => x.Users).Include(x => x.Activity).Include(x => x.Subject)
                .Where(x => x.Subject.SubjectName == SubjectsDropDownList.SelectedValue).ToList();
            var activities = grades.Select(x => x.Activity).Distinct();
            //kolumny tabeli:
            if (activities.Count() != 0)
            {
                foreach (var i in activities)
                {
                    dataTable.Columns.Add(i.Name, typeof(int));
                    dataTable.Columns[i.Name].ReadOnly = false;
                }
            }

            int j = 0;
            foreach (var a in activities)
            {
                var grade = repoGrades.Table
                    .First(u => u.Users.UserName == name && u.Users.UserSurname == surname && u.Activity.Id == a.Id);
                grade.GradeValue = changeList[j];
                j++;

                grade.GradeWeight = changeList[j];
                j++;

            }
            repoGrades.Update();
        }

        private void BindGridView()
        {
            GradesGridView.Columns.Clear();
            AddEditButtonToGridView();
            //kolumny:
            dataTable.Columns.Add("Imię", typeof(String));
            dataTable.Columns["Imię"].ReadOnly = true;
            dataTable.Columns.Add("Nazwisko", typeof(String));
            dataTable.Columns["Nazwisko"].ReadOnly = true;

            var grades = repoGrades.Table.Include(x => x.Users).Include(x => x.Activity).Include(x => x.Subject)
                .Where(x => x.Subject.SubjectName == SubjectsDropDownList.SelectedValue).ToList();
            var activities = grades.Select(x => x.Activity).Distinct();
            //kolumny tabeli:
            if (activities.Count() > 0)
            {
                foreach (var i in activities)
                {
                    dataTable.Columns.Add(i.Name, typeof(int));
                    dataTable.Columns[i.Name].ReadOnly = false;
                    dataTable.Columns.Add("Waga " + i.Name, typeof(int)).ReadOnly = false;
                }
            }
            dataTable.Columns.Add("Ocena automatyczna", typeof(int)).ReadOnly = true; //kolumna oceny koncowej

            grades = grades.OrderBy(x => x.Users.UserSurname).OrderBy(x => x.Users.UserName).ToList();
            //wiersze:
            foreach (var grade in grades.Select(x => x.Users).Distinct())
            {
                var userGrades = grades.Where(x => x.Users == grade);
                DataRow newRow = dataTable.NewRow();
                newRow["Imię"] = grade.UserName;
                newRow["Nazwisko"] = grade.UserSurname;
                int suma = 0;
                int liczba = 0;
                foreach (var act in activities)
                {
                    var ocena = userGrades.FirstOrDefault(x => x.Activity == act).GradeValue;
                    var waga = userGrades.FirstOrDefault(x => x.Activity == act).GradeWeight;

                    newRow[act.Name] = ocena;
                    newRow["Waga " + act.Name] = waga;
                    suma += ocena * waga; //do sredniej wazonej
                    liczba += waga; //do sredniej wazonej
                }
                newRow["Ocena automatyczna"] = suma / liczba; //do sredniej wazonej
                dataTable.Rows.Add(newRow);
            }

            GradesGridView.DataSource = dataTable;
            GradesGridView.DataBind();
        }

        protected void GradesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GradesGridView.EditIndex = -1; // Anuluj tryb edycji
            BindGridView();
        }

        protected void PowrotButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void AktywnoscButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Activities.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class Activities : System.Web.UI.Page
    {
        SubjectsRepository repoSubj = new SubjectsRepository();
        GroupsRepository repoGroups = new GroupsRepository();
        ActivitiesRepository repoActivities = new ActivitiesRepository();
        GradesRepository repoGrades = new GradesRepository();
        GroupUsersRepository repoGroupUser = new GroupUsersRepository();
        UsersRepository repoUsers = new UsersRepository();
        //  FormulasRepository formulasRepo = new FormulasRepository(); //odkomentowac 1/3
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
<<<<<<< HEAD
                if(SubjectDropDownList.Items.Count==0)
                    SubjectDropDownList.Items.Add("Najpierw wybierz grupę");
=======

                SubjectDropDownList.Items.Add("Najpierw wybierz grupę");
>>>>>>> 891bf7b254ce81df1dddb91a1662e9bf4a3275da
                List<String> grupy = repoGroups.Table.Include(x => x.Classes)
                            .Where(x => x.Classes.Any(c => c.Warden.Id == UserSession.GetSession().UserId))
                            .Select(x => x.Name)
                            .ToList();

                if (grupy.Count() != 0)
                {
                    foreach (var g in grupy)
                    {
                        GroupDropDownList.Items.Add(g);
                    }
<<<<<<< HEAD
                }
                if (GroupDropDownList.Items.Count != 0)
                {
                    GroupDropDownList.SelectedValue = GroupDropDownList.Items[0].Value;
                    var przedmioty = repoSubj.Table.Include(x => x.Classes)
                     .ThenInclude(x => x.Group)
                     .Where(x => x.Classes.Any(c => c.Group.Name == GroupDropDownList.SelectedValue))
                     .ToList();

                    if (przedmioty.Count() != 0)
                    {
                        SubjectDropDownList.Items.Clear();
                        foreach (var p in przedmioty)
                        {
                            SubjectDropDownList.Items.Add(p.SubjectName);
                        }
                    }
                    else
                    {
                        SubjectDropDownList.Items.Clear();
                        SubjectDropDownList.Items.Add("Brak przedmiotów");
                    }
=======
>>>>>>> 891bf7b254ce81df1dddb91a1662e9bf4a3275da
                }
            }
        }

        protected void FormulaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx"); //przekierowanie na strone tworzenia formul - tymczasowo main
        }

        protected void AnulujButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grades.aspx");
        }

        protected void DodajButton_Click(object sender, EventArgs e)
        {
            Activity activity = new Activity();
            if (NameTextBox.Text.Length == 0) //jesli nie podano nazwy
            {
                NameLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
                activity.Name = NameTextBox.Text;
            if (SubjectDropDownList.SelectedValue != "Najpierw wybierz grupę")
            {
                activity.Subject = repoSubj.Table.First(x => x.SubjectName == SubjectDropDownList.SelectedValue);
            }
            else
            {
                SubjectLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ISFinalCheckBox1.Checked)
            {
                activity.IsFinalGrade = true;
                // activity.formula = formulasRepo.Table.First(x => x.Name == FormulaDropDownList.SelectedValue); //odkomentowac 2/3
            }
            else
                activity.IsFinalGrade = false;

            //dodanie ocen:
            Grade grade = new Grade();
            grade.GradeValue = 0; //value
            int waga;
            if (int.TryParse(WeightTextBox.Text, out waga) == true)
            {
                grade.GradeWeight = waga; //weight
            }
            else
            {
                WeightLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            grade.TeacherId = UserSession.GetSession().UserId; //teacher

            if (SubjectDropDownList.SelectedValue != "Brak przedmiotow")
                grade.Subject = repoSubj.Table.First(x => x.SubjectName == SubjectDropDownList.SelectedValue); //subject
            else
            {
                SubjectLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            grade.Activity = activity; //activity
            if (TypeDropDownList.SelectedValue == "Skala nominalna")
                grade.GradeType = "nominalna"; //grade type
            else
                grade.GradeType = "procentowa"; //grade type

            int idGroup = repoGroups.Table.First(x => x.Name == GroupDropDownList.SelectedValue).Id;
           // var users = repoGroups.Table.Where(x => x.Name == GroupDropDownList.SelectedValue).Select(x => x.Users);// repoUsers.Table.Select(x => x).Where(x => x.Groups.Any(y => y.Id == idGroup)).ToList();// repoGroupUser.Table.Select(x => x).Where(x => x.User.Groups.Any(y => y.Id == idGroup)).ToList();
            var users = repoUsers.Table.Where(x => x.Groups.Any(y => y.Id == idGroup)).Select(x => x).ToList();
            repoActivities.Insert(activity);
            foreach (var u in users)
            {
                grade.StudentId = u.Id; //student
                repoGrades.Insert(grade);
            }
            
        }

        protected void ISFinalCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ISFinalCheckBox1.Checked)
            {
                if (FormulaDropDownList.Items.Count == 0)
                {
                    /*                                                              //odkomentowac 3/3
                    var list= formulasRepo.Table.Select(x => x.Name);
                    foreach (var f in list)
                    {
                        FormulaDropDownList.Items.Add(f);
                    }
                    */
                }
                else
                {
                    FormulaDropDownList.Items.Add("Brak formuł");
                }
                FormulaButton.Visible = true;
                FormulaDropDownList.Visible = true;
            }
            else
            {
                FormulaButton.Visible = false;
                FormulaDropDownList.Visible = false;
            }
        }
        //wybrano grupe:
        protected void GroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GroupDropDownList.SelectedValue == "" && GroupDropDownList.Items.Count != 0)
            {
                GroupDropDownList.SelectedValue = GroupDropDownList.Items[0].Value;
            }
            var przedmioty = repoSubj.Table.Include(x => x.Classes)
                    .ThenInclude(x => x.Group)
                    .Where(x => x.Classes.Any(c => c.Group.Name == GroupDropDownList.SelectedValue))
                    .ToList();

            if (przedmioty.Count() != 0)
            {
                foreach (var p in przedmioty)
                {
                    SubjectDropDownList.Items.Add(p.SubjectName);
                }
            }
            else
            {
                SubjectDropDownList.Items.Clear();
                SubjectDropDownList.Items.Add("Brak przedmiotów");
            }

        }
    }
}
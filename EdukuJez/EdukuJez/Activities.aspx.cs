using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Model.Main;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class Activities : System.Web.UI.Page
    {
        const String ADD_FORM_SITE = "AddGradeFormula.aspx";
        SubjectsRepository repoSubj = new SubjectsRepository();
        GroupsRepository repoGroups = new GroupsRepository();
        ActivitiesRepository repoActivities = new ActivitiesRepository();
        GradesRepository repoGrades = new GradesRepository();
        GroupUsersRepository repoGroupUser = new GroupUsersRepository();
        UsersRepository repoUsers = new UsersRepository();
        User currentuser;
        //  FormulasRepository formulasRepo = new FormulasRepository(); //odkomentowac 1/3
        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = UserSession.GetSession().user;
            if (!IsPostBack)
            {
                if(SubjectDropDownList.Items.Count==0)
                    SubjectDropDownList.Items.Add("Najpierw wybierz grupę");

                SubjectDropDownList.Items.Add("Najpierw wybierz grupę");
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
                }
            }

            if (SubjectManager.ActivtyTransferFlag)
            {

                var s = repoSubj.Table.Include(x => x.StudentGroup).Include(x => x.Formulas).First(x => x.SubjectName == SubjectManager.Subject.SubjectName);
                GroupDropDownList.Items.Clear();
                GroupDropDownList.Items.Add(s.StudentGroup.Name);
                SubjectDropDownList.Items.Clear();
                SubjectDropDownList.Items.Add(s.SubjectName);
                FormulaDropDownList.Items.Clear();
                foreach (var f in s.Formulas)
                {
                    FormulaDropDownList.Items.Add(new ListItem() {Value=f.Id.ToString(), Text = f.Name});
                }

            }
        }

        protected void FormulaButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(ADD_FORM_SITE); //przekierowanie na strone tworzenia formul - tymczasowo main
        }

        protected void AnulujButton_Click(object sender, EventArgs e)
        {
            SubjectManager.ActivtyTransferFlag = false;
            Response.Redirect("Grades.aspx");
        }

        protected void DodajButton_Click(object sender, EventArgs e)
        {
            SubjectManager.ActivtyTransferFlag = false;
            Activity activity = new Activity();
            if (repoActivities.IsNameInDatabase(NameTextBox.Text))
            {
                InfoLabel.Text = "Aktywność o tej nazwie już istnieje!";
                NameLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else if (NameTextBox.Text.Length == 0) //jesli nie podano nazwy
            {
                InfoLabel.Text = "Nazwa nie może być pusta!";
                NameLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
                activity.Name = NameTextBox.Text;
            if (ISFinalCheckBox1.Checked)
            {
                activity.IsFinalGrade = true;
                activity.formula = repoSubj.Table.Include(x=>x.Formulas)
                    .First(x => x.SubjectName == SubjectDropDownList.SelectedValue).Formulas.First(x=>x.Id==int.Parse(FormulaDropDownList.SelectedItem.Value)); 
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
            if (SubjectDropDownList.SelectedValue != "Najpierw wybierz grupę")
            {
                repoSubj.Table.First(x => x.SubjectName == SubjectDropDownList.SelectedValue).Activites.Add(activity);
            }
            else
            {
                SubjectLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            grade.Activity = activity; //activity
            if (TypeDropDownList.SelectedValue == "Skala nominalna")
                grade.GradeType = "nominalna"; //grade type
            else
            {
                grade.GradeType = "procentowa"; //grade type
                activity.Name += " [%]";
            }
            int idGroup = repoGroups.Table.First(x => x.Name == GroupDropDownList.SelectedValue).Id;
           // var users = repoGroups.Table.Where(x => x.Name == GroupDropDownList.SelectedValue).Select(x => x.Users);// repoUsers.Table.Select(x => x).Where(x => x.Groups.Any(y => y.Id == idGroup)).ToList();// repoGroupUser.Table.Select(x => x).Where(x => x.User.Groups.Any(y => y.Id == idGroup)).ToList();
            var usersId = repoUsers.Table.Where(x => x.Groups.Any(y => y.Id == idGroup)).Select(x => x.Id).ToList();
                repoSubj.Update();

            foreach (var u in usersId)
            {
                if (ISFinalCheckBox1.Checked)
                {
                    var gr = repoUsers.Table.Include(x => x.Grades).ThenInclude(x => x.Activity).First(x => x.Id == u);
                    var i = (int)FormulaDecoder.ParseForUser(activity.formula.Formula, gr);
                    grade.GradeValue = i;
                }
                repoUsers.Table.FirstOrDefault(x => x.Id == currentuser.Id).SubmittedGrades.Add(grade);
                repoUsers.Table.FirstOrDefault(x => x.Id == u).Grades.Add(grade);
                repoUsers.Update();
                repoGrades.Update();
            }


            InfoLabel.Text = "Dodałeś aktywność o nazwie " + NameTextBox.Text + ". Możesz kontynuować.";
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
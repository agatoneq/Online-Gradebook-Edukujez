using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class AddGradeFormula : Page
    {
        SubjectsRepository repoSubj = new SubjectsRepository();
        const String ADD_ACTIVITY_SITE = "Activities.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach(var s in repoSubj.Table)
                    SubjectDropDownList.Items.Add(s.SubjectName);
                ActivtyDropDownList.Items.Clear();
                var activities = repoSubj.Table.Include(x => x.Activites).FirstOrDefault(x => x.SubjectName == SubjectDropDownList.SelectedValue).Activites;
                foreach (var a in activities)
                    ActivtyDropDownList.Items.Add(new ListItem { Value = a.Id.ToString(), Text = a.Name + " = $" + a.Id.ToString() });
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Length == 0)
                return;

            var f = new GradeFormula() { Name = NameTextBox.Text, Formula= MainTextBox.Text };
            repoSubj.Table.FirstOrDefault(x => x.SubjectName == SubjectDropDownList.SelectedValue).Formulas.Add(f);
            repoSubj.Update();
            Response.Redirect(ADD_ACTIVITY_SITE);
        }

        protected void ButtonActivity_Click(object sender, EventArgs e)
        {
            var id ="$"+ActivtyDropDownList.SelectedItem.Value;
            MainTextBox.Text += id;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ADD_ACTIVITY_SITE);
        }

        protected void SubjectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivtyDropDownList.Items.Clear();
            var activities = repoSubj.Table.Include(x => x.Activites).FirstOrDefault(x => x.SubjectName == SubjectDropDownList.SelectedValue).Activites;
            foreach (var a in activities)
                ActivtyDropDownList.Items.Add(new ListItem {Value=a.Id.ToString(), Text=a.Name+" = $"+ a.Id.ToString() });
            
        }
    }
}
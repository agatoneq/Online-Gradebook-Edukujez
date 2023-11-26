using EdukuJez.Model.ServerAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class EditClasses : System.Web.UI.Page
    {

    // Deklaracja zmiennych do przechowywania DropDownList jako zmiennych klasy
    private DropDownList DropDownListDay;
        private DropDownList DropDownListHour;
        private DropDownList DropDownListTeacher;
        private DropDownList DropDownListGroup;
        private DropDownList DropDownListSubject;

        protected void Page_Load(object sender, EventArgs e)
        {
 
                CreateDynamicControls();
            
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            string dzien = DropDownListDay.SelectedValue;
            string godzina = DropDownListHour.SelectedValue;
            int nauczycielId = Convert.ToInt32(DropDownListTeacher.SelectedValue);
            int grupaId = Convert.ToInt32(DropDownListGroup.SelectedValue);
            int przedmiotId = Convert.ToInt32(DropDownListSubject.SelectedValue);


            ClassesDataBaseAdd dataBaseAdd = new ClassesDataBaseAdd();
            dataBaseAdd.AddData(dzien,godzina,nauczycielId,grupaId,przedmiotId);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string dzien = DropDownListDay.SelectedValue;
            string godzina = DropDownListHour.SelectedValue;
            int nauczycielId = Convert.ToInt32(DropDownListTeacher.SelectedValue);
            int grupaId = Convert.ToInt32(DropDownListGroup.SelectedValue);
            int przedmiotId = Convert.ToInt32(DropDownListSubject.SelectedValue);


            ClassesDataBaseDelete dataBaseDelete = new ClassesDataBaseDelete();
            dataBaseDelete.DeleteData(dzien, godzina, nauczycielId, grupaId, przedmiotId);
        }


        private void CreateDynamicControls()
        {
            string[] dropdownNames = { "Dzien", "Godzina", "Nauczyciel", "Grupa", "Przedmiot" };

            // Zakładając, że masz listy wartości dla każdego DropDownList
            List<string> days = new List<string> { "Poniedzialek", "Wtorek", "Sroda", "Czwartek", "Piatek" };
            List<string> hours = new List<string> { "8:00 – 8:45", "8:50 – 9:35", "9:45 – 10:30", "10:35 – 11:20", "11:40 – 12:25", "12:45 – 13:30", "13:35 – 14:20", "14:25 – 15:10" };
            List<string> teachers = new List<string> { "1", "2", "3" };
            List<string> groups = new List<string> { "1", "2", "3" };
            List<string> subjects = new List<string> { "1", "2", "3" };

            List<List<string>> values = new List<List<string>> { days, hours, teachers, groups, subjects };

            for (int i = 0; i < dropdownNames.Length; i++)
            {
                DropDownList dropdown = new DropDownList();
                dropdown.ID = "DropDownList" + i;
                dropdown.CssClass = "form-control";

                // Dodawanie wartości do DropDownList
                foreach (var value in values[i])
                {
                    dropdown.Items.Add(new ListItem(value, value)); // Tutaj 'value' zostanie ustawione jako Value i Text dla ListItem
                }
                // Dodanie utworzonego DropDownList do zmiennej klasy
                switch (i)
                {
                    case 0:
                        DropDownListDay = dropdown;
                        break;
                    case 1:
                        DropDownListHour = dropdown;
                        break;
                    case 2:
                        DropDownListTeacher = dropdown;
                        break;
                    case 3:
                        DropDownListGroup = dropdown;
                        break;
                    case 4:
                        DropDownListSubject = dropdown;
                        break;
                }

                TableCell cell = new TableCell();
                cell.Controls.Add(dropdown);

                Label label = new Label();
                label.Text = dropdownNames[i] + ": ";
                label.AssociatedControlID = dropdown.ID;

                TableCell labelCell = new TableCell();
                labelCell.Controls.Add(label);

                TableRow row = new TableRow();
                row.Cells.Add(labelCell);
                row.Cells.Add(cell);

                MainTable.Rows.Add(row);
            }

            Button AddButton = new Button();
            AddButton.ID = "AddButton";
            AddButton.Text = "Add";
            AddButton.Click += new EventHandler(AddButton_Click);


            Button DeleteButton = new Button();
            DeleteButton.ID = "DeleteButton";
            DeleteButton.Text = "Delete";
            DeleteButton.Click += new EventHandler(DeleteButton_Click);

            TableCell submitCell = new TableCell();
            submitCell.ColumnSpan = 2;

            submitCell.Controls.Add(AddButton);
            submitCell.Controls.Add(DeleteButton);

            TableRow submitRow = new TableRow();
            submitRow.Cells.Add(submitCell);

            MainTable.Rows.Add(submitRow);
        }
    }
}

using System;
using EdukuJez.Repositories;
using System.Linq;

namespace EdukuJez
{
    public partial class CalendarAdminPanel : System.Web.UI.Page
    {
        CalendarRepository Calend = new CalendarRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicjalizacja strony
                RefreshListBox();
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(TextBoxDate.Text, out date))
            {
                string desc = TextBoxDescription.Text;

                // Dodaj nowy wpis do kalendarza
                Calend.AddNewEntry(new Repositories.Calendar { Date = date, Desc = desc });

                // Odśwież dane i przekształć kalendarz
                RefreshListBox();
            }
            else
            {
                // Informacja o błędnej dacie
                LabelInfo.Text = "Wprowadź poprawną datę.";
                LabelInfo.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (ListBoxAllDates.SelectedIndex >= 0)
            {
                DateTime selectedDate;
                if (DateTime.TryParse(ListBoxAllDates.SelectedItem.Text, out selectedDate))
                {
                    // Pobierz zaznaczony wpis do edycji na podstawie daty
                    var selectedEntry = Calend.Table.FirstOrDefault(entry => entry.Date == selectedDate);

                    if (selectedEntry != null)
                    {
                        // Zaktualizuj dane z formularza
                        DateTime date;
                        if (DateTime.TryParse(TextBoxDate.Text, out date))
                        {
                            string desc = TextBoxDescription.Text;

                            // Ustaw nowe wartości
                            selectedEntry.Date = date;
                            selectedEntry.Desc = desc;

                            // Zapisz zmiany
                            Calend.EditEntry(selectedEntry);                   

                            // Odśwież dane i przekształć kalendarz
                            RefreshListBox();
                        }
                        else
                        {
                            // Informacja o błędnej dacie
                            LabelInfo.Text = "Wprowadź poprawną datę.";
                            LabelInfo.Visible = true;
                        }
                    }
                }
                else
                {
                    // Obsługa błędu parsowania daty
                    LabelInfo.Text = "Nieprawidłowy format daty.";
                    LabelInfo.Visible = true;
                }
            }
        }


        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxAllDates.SelectedIndex >= 0)
            {
                DateTime selectedDate;
                if (DateTime.TryParse(ListBoxAllDates.SelectedItem.Text, out selectedDate))
                {
                    // Pobierz zaznaczony wpis do usunięcia na podstawie daty
                    var selectedEntry = Calend.Table.FirstOrDefault(entry => entry.Date == selectedDate);

                    if (selectedEntry != null)
                    {
                        // Usuń zaznaczony wpis
                        Calend.RemoveEntry(selectedEntry);
                        // Odśwież dane i przekształć kalendarz
                        RefreshListBox();
                    }
                }
                else
                {
                    // Obsługa błędu parsowania daty
                    LabelInfo.Text = "Nieprawidłowy format daty.";
                    LabelInfo.Visible = true;
                }
            }
        }


        private void RefreshListBox()
        {
            // Pobierz dane z kalendarza i przypisz do ListBox
            var calendarE = Calend.Table.OrderBy(a => a.Date).ToList();
            ListBoxAllDates.DataSource = calendarE;
            ListBoxAllDates.DataTextField = "Date"; // Dostosuj do rzeczywistej właściwości daty
            ListBoxAllDates.DataBind();
        }
    }
}

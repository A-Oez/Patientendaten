using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientenDaten
{
    public partial class Patienten_Verwaltung : MetroForm
    {
        Patienten CachePatient = new Patienten();
        Termine CacheTermin = new Termine();
        BusinessPatient patient = new BusinessPatient();
        BusinessTermin termin = new BusinessTermin();
        bool SelectPatient = true; // Kontrolle, ob ein Patient ausgewählt wurde / Steuerelement für Click event. Gibt an ob Patient oder Termin geclickt wurde
        bool PatientLoaded = false; // Kontrolle, ob Patient in die Textboxen geladen wurde


        //-------------------------------------------------------------------------//
        //1. Form- Allgemein --> Steuerelemente ausblenden usw., Form Größe anpassen, Panel farben anpassen

        public Patienten_Verwaltung()
        {
            InitializeComponent();
            LoadGridPatienten();
            HideControls();                      
        }

        private void HideControls()
        {         
            lbSpeichern.Visible = false;
            lbClear.Visible = false;
            lbTerminHinzufügen.Visible = false;
            lbAnweisungGeburtsdatum.Visible = false;
            lbAktualisieren.Visible = false;
            lbBearbeiten.Visible = false;
            lbLöschenGrid.Visible = false;
            lbAnweisungPLZOrt.Visible = false;
            lbAnweisungStraßeHN.Visible = false;
            lbKrankenkasse.Visible = false;
            lbVersicherungsNr.Visible = false;
            txtKrankenkasse.Visible = false;
            txtVersicherungsnummer.Visible = false;
            btnCreateTermin.Visible = false;
        }

        private void PanelTermin() 
        {
            panelGrid1.BackColor = Color.LimeGreen;
            panelGrid2.BackColor = Color.LimeGreen;
            panelMitte.BackColor = Color.LimeGreen;
            panelSenkrecht.BackColor = Color.LimeGreen;
            panelHeader.BackColor = Color.LimeGreen;
        }

        private void PanelPatient() 
        {
            panelGrid1.BackColor = Color.Red;
            panelGrid2.BackColor = Color.Red;
            panelMitte.BackColor = Color.Red;
            panelSenkrecht.BackColor = Color.Red;
            panelHeader.BackColor = Color.Red;
        }

        //-------------------------------------------------------------------------//
        //2. Patienten Speichern + Textinhalt leeren

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (CheckMandatory()) 
            {
                Patienten newPatient = new Patienten()
                {
                    Id = patient.createId(),
                    Vorname = txtVorname.Text,
                    Nachname = txtNachname.Text,
                    Geschlecht = txtGeschlecht.SelectedItem.ToString(),
                    Geburtsdatum = Convert.ToDateTime(txtGeburtsdatum.Text),
                    Krankenkasse = txtKrankenkasse.Text,
                    Versicherungsnummer = Convert.ToInt32(txtVersicherungsnummer.Text),
                    PLZ_Ort = txtPlzOrt.Text,
                    Straße_HausNr = txtStrasseHausNr.Text,
                    Telefon = txtTelefon.Text,
                    Besonderheiten = txtBesonderheiten.Text,
                };

                bool UniqueId = false;

                while (UniqueId == false)
                {
                    var patientUnique = patient.GetPatient(newPatient.Id);
                    if (patientUnique == null)
                    {
                        UniqueId = true;
                    }
                }

                try
                {
                    patient.AddPatient(newPatient);
                    LoadGridPatienten();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.InnerException.Message.Contains("Violation of PRIMARY KEY constraint 'PK_Patienten'"))
                    {
                        MessageBox.Show("Es ist ein Fehler aufgetreten bitte drücken Sie erneut auf Anlegen");
                    }
                    else
                    {
                        MessageBox.Show("Es ist ein Fehler aufgetreten! Bitte kontaktieren Sie ihren Systemadministrator!");
                    }
                }
            }
        }

        private void btnClearTextboxes_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtVorname.Text = "";
            txtNachname.Text = "";
            txtGeburtsdatum.Text = "";
            txtKrankenkasse.Text = "";
            txtVersicherungsnummer.Text = "";
            txtGeschlecht.Text = "";
            txtPlzOrt.Text = "";
            txtStrasseHausNr.Text = "";
            txtTelefon.Text = "";
            txtBesonderheiten.Text = "";

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = patient.GetAllPatienten();
            dataGridView1.Columns[0].Visible = false;
            PanelPatient();

            SelectPatient = true;
            PatientLoaded = false;

            btnSpeichern.Enabled = true;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnCreateTermin.Enabled = false;
            txtFilterSuche.Visible = false;
            txtFIlterToken.Visible = false;
        }


        private void CbCheckKrankenversichert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCheckKrankenversichert.Text == "Ja") 
            {
                txtKrankenkasse.Text = "";
                txtVersicherungsnummer.Text = "";
                lbVersicherungsNr.Visible = true;
                lbKrankenkasse.Visible = true;
                txtKrankenkasse.Visible = true;
                txtVersicherungsnummer.Visible = true;
            }
            else
            {
                lbVersicherungsNr.Visible = false;
                lbKrankenkasse.Visible = false;
                txtKrankenkasse.Visible = false;
                txtVersicherungsnummer.Visible = false;
                Convert.ToInt32(txtVersicherungsnummer.Text = "0");
                txtKrankenkasse.Text = "Keine Krankenversicherung";
            }
        }


        //-------------------------------------------------------------------------//
        //3. DataGrid --> Daten aus der Datenbank in die Tabelle laden, einmal Tabelle für alle Patienten, sowie Tabelle für alle Termine für jeweilligen Patienten
        //--> Ebenso Buttons für die Aktualisierung, Löschen, sowie Bearbeiten
        //--> Filter


        private void LoadGridPatienten()
        {
            //Check DB exist
            if (CheckDatabaseExists())
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

                try
                {
                    var x = patient.GetAllPatienten();
                    dataGridView1.DataSource = x;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Es ist ein Fehler beim Laden der Daten aus der Datenbank aufgetreten! Bitte kontaktieren Sie ihren Systemadministrator!\n " + ex.Message.ToString());
                }

                dataGridView1.Columns[0].Visible = false;
            }
            else
            {
                this.Close();
            }



        }

        public void LoadGridTermine()
        {
            //Check DB exist
            if (CheckDatabaseExists())
            {
                List<Termine> termine = termin.GetTermine(CachePatient.Id).OrderBy(x => x.Datum).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = termine;

                //Makieren der Termine die in der Vergangenheit liegen
                DateTime dateToday = DateTime.Today;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (Convert.ToDateTime(row.Cells[2].Value.ToString()) < dateToday)
                    {
                        dataGridView1.Rows[row.Index].DefaultCellStyle.BackColor = Color.Gray;
                    }
                }

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                this.Close();
            }

        }

        private bool CheckDatabaseExists()
        {
            bool result = false;
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PatientenDaten;Integrated Security=True"))
                {
                    SqlConn.Open();
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.ToString());
            }
            return result;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int currentid = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                PanelTermin();
                btnCreateTermin.Visible = true;

                if (SelectPatient)
                {
                    CachePatient = patient.GetPatient(currentid);

                    if (CachePatient.Krankenkasse == "Keine Krankenkasse" || CachePatient.Versicherungsnummer.ToString() == "0")
                    {
                        cbCheckKrankenversichert.Text = "Nein";
                    }
                    else
                    {
                        cbCheckKrankenversichert.Text = "Ja";
                        lbKrankenkasse.Visible = true;
                        lbVersicherungsNr.Visible = true;
                        txtKrankenkasse.Visible = true;
                        txtVersicherungsnummer.Visible = true;
                    }
                    //Patient in Textboxen laden
                    txtVorname.Text = CachePatient.Vorname;
                    txtNachname.Text = CachePatient.Nachname;
                    txtGeburtsdatum.Text = CachePatient.Geburtsdatum.ToString("dd-MM-yyyy");
                    txtKrankenkasse.Text = CachePatient.Krankenkasse;
                    txtVersicherungsnummer.Text = CachePatient.Versicherungsnummer.ToString();
                    txtGeschlecht.Text = CachePatient.Geschlecht;
                    txtPlzOrt.Text = CachePatient.PLZ_Ort;
                    txtStrasseHausNr.Text = CachePatient.Straße_HausNr;
                    txtTelefon.Text = CachePatient.Telefon;
                    txtBesonderheiten.Text = CachePatient.Besonderheiten;




                    //Termine für Patient in Grid laden
                    LoadGridTermine();

                    btnSpeichern.Enabled = false;
                    btnDelete.Enabled = true;
                    btnChange.Enabled = true;
                    btnAktualisieren.Enabled = true;
                    btnCreateTermin.Enabled = true;

                    PatientLoaded = true;  //Patient in Textbox geladen 
                    SelectPatient = false; //Patient wurde ausgewählt also muss kein Patient beim nächsten Klick erfasst werden.
                }
                else
                {
                    PatientLoaded = false; //Patient wurde nicht ausgewählt, also nicht in die Textbox geladen
                    this.dataGridView1.CurrentRow.Selected = true;

                    txtFilterSuche.Visible = false;
                    txtFIlterToken.Visible = false;

                    CacheTermin = termin.GetTermin(currentid);

                    btnSpeichern.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnAktualisieren_Click(object sender, EventArgs e)
        {
            if (SelectPatient) // Wenn ein Patient ausgewählt werden soll befindet man sich noch in der Übersicht über die Patienten sprich die Patienten Grid soll aktualisiert werden
            {
                LoadGridPatienten();
            }
            else
            {
                LoadGridTermine();
                PatientLoaded = true;
            }

        }


        private void btnChange_Click(object sender, EventArgs e)
        {

            if (PatientLoaded) 
            {
                //Patient
                try
                {
                    Patienten newPatient = new Patienten()
                    {
                        Id = CachePatient.Id,
                        Vorname = txtVorname.Text,
                        Nachname = txtNachname.Text,
                        Geburtsdatum = Convert.ToDateTime(txtGeburtsdatum.Text),
                        Krankenkasse = txtKrankenkasse.Text,
                        Versicherungsnummer = Convert.ToInt32(txtVersicherungsnummer.Text),
                        Geschlecht = txtGeschlecht.SelectedItem.ToString(),
                        PLZ_Ort = txtPlzOrt.Text,
                        Straße_HausNr = txtStrasseHausNr.Text,
                        Telefon = txtTelefon.Text,
                        Besonderheiten = txtBesonderheiten.Text,
                    };

                    patient.ChangePatient(CachePatient, newPatient);
                    Clear();
                    PanelPatient();
                    LoadGridPatienten();
                }
                catch
                {
                    MessageBox.Show("Fehler! Bitte überprüfen Sie ihre Angaben");
                }

            }
            else
            {
                //Termin
                TerminVerwaltung terminForm = new TerminVerwaltung(CachePatient, CacheTermin);
                terminForm.Show();
                PatientLoaded = true;
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (PatientLoaded)
            {
                patient.RemovePatient(CachePatient);
                Clear();
                PanelPatient();
            }
            else
            {
                try
                {
                    if (CacheTermin != null)
                    {
                        termin.RemoveTermin(CacheTermin);
                        LoadGridTermine();
                    }
                    else
                    {
                        MessageBox.Show("Der gewünschte Termin könnte nicht richtig geladen werden! Bitte versuchen Sie es erneut");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
                PatientLoaded = true;
            }

        }

        private void btnCreateTermin_Click(object sender, EventArgs e)
        {
            TerminVerwaltung terminAnlegen = new TerminVerwaltung(CachePatient);
            terminAnlegen.Show();
        }

        private void txtFilterSuche_TextChanged(object sender, EventArgs e)
        {

            List<Patienten> patienten = new List<Patienten>();
            List<Patienten> filteredPatienten = new List<Patienten>();

            string Token = txtFIlterToken.Text;
            string Filter = txtFilterSuche.Text;

            try
            {
                patienten = patient.GetAllPatienten();
                foreach (var patient in patienten)
                {
                    if (Token == "")
                    {
                        MessageBox.Show("Filter Kriterium konnte nicht zugeordnet werden!");
                    }
                    else
                    {
                        if (Token == "Vorname")
                        {
                            if (patient.Vorname.Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                        else if (Token == "Nachname")
                        {
                            if (patient.Nachname.Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                        else if (Token == "Straße+HN")
                        {
                            if (patient.Straße_HausNr.Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                        else if (Token == "PLZ+Ort")
                        {
                            if (patient.PLZ_Ort.Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                        else if (Token == "Krankenkasse")
                        {
                            if (patient.Krankenkasse.Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                        else if (Token == "Versicherungsnummer")
                        {
                            if (patient.Versicherungsnummer.ToString().Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                        else if (Token == "Geburtsdatum")
                        {
                            if (patient.Geburtsdatum.ToString().Contains(Filter))
                            {
                                filteredPatienten.Add(patient);
                            }
                        }
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = filteredPatienten;
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //-------------------------------------------------------------------------//

        //4. Beschriftung der Buttons//
        //Mouse Enter bzw. Enter= Falls die Maus auf das Steuerelement kommt, wird eine beliebige Anweisung ausgeführt

        //Patienten -> Button
        private void BtnSpeichern_MouseEnter(object sender, EventArgs e)
        {
            lbSpeichern.Visible = true;
        }

        private void BtnClearTextboxes_MouseEnter(object sender, EventArgs e)
        {
            lbClear.Visible = true;
        }


        //Grid --> Button
        private void BtnAktualisieren_MouseEnter(object sender, EventArgs e)
        {
            lbAktualisieren.Visible = true;
        }

        private void BtnChange_MouseEnter(object sender, EventArgs e)
        {
            lbBearbeiten.Visible = true;
        }
        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            lbLöschenGrid.Visible = true;
        }

        private void BtnCreateTermin_MouseEnter(object sender, EventArgs e)
        {
            lbTerminHinzufügen.Visible = true;
        }

        //Label Anweisungen bzw. Format
        private void TxtGeburtsdatum_Enter(object sender, EventArgs e)
        {
            lbAnweisungGeburtsdatum.Visible = true;
        }


        private void TxtPlzOrt_Enter(object sender, EventArgs e)
        {
            lbAnweisungPLZOrt.Visible = true;
        }

        private void TxtStrasseHausNr_Enter(object sender, EventArgs e)
        {
            lbAnweisungStraßeHN.Visible = true;
        }


        //Mouse Leave bzw. Leave = Wenn die Maus das Steuerelement verlässt, wird eine beliebige Anweisung ausgeführt

        //Patienten --> Button
        private void BtnSpeichern_MouseLeave(object sender, EventArgs e)
        {
            lbSpeichern.Visible = false;
        }

        private void BtnClearTextboxes_MouseLeave(object sender, EventArgs e)
        {
            lbClear.Visible = false;
        }


        //Grid --> Button
        private void BtnAktualisieren_MouseLeave(object sender, EventArgs e)
        {
            lbAktualisieren.Visible = false;
        }

        private void BtnChange_Leave(object sender, EventArgs e)
        {
            lbBearbeiten.Visible = false;
        }

        private void BtnDelete_Leave(object sender, EventArgs e)
        {
            lbLöschenGrid.Visible = false;
        }

        private void BtnCreateTermin_MouseLeave(object sender, EventArgs e)
        {
            lbTerminHinzufügen.Visible = false;
        }

        //Label Anweisungen bzw. Format Label

        private void TxtGeburtsdatum_Leave(object sender, EventArgs e)
        {
            lbAnweisungGeburtsdatum.Visible = false;
        }

        private void TxtPlzOrt_Leave(object sender, EventArgs e)
        {
            lbAnweisungPLZOrt.Visible = false;
        }

        private void TxtStrasseHausNr_Leave(object sender, EventArgs e)
        {
            lbAnweisungStraßeHN.Visible = false;
        }


        //-------------------------------------------------------------------------//
        //5. Valiidierung der Textboxen, Pflichtfelder festlegen//

        //Pflichtfelder: Vorname, Nachname, PLZ + Ort, Geburtsdatum, Krankenkasse, Geschlecht , Versichertennummer, checkKrankenversichert  
        //CheckKrankenversichert 
        //Validität Textbox

        private bool CheckMandatory()
        {
            bool check = true; 
            //Vorname
            if(txtVorname.Text == "")
            {
                check = false;
                errorProvider.SetError(txtVorname, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(txtVorname, default(string));
            }

            //Nachname
            if(txtNachname.Text == "")
            {
                check = false;
                errorProvider.SetError(txtNachname, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(txtNachname, default(string));
            }

            //Geschlecht
            if (txtGeschlecht.Text == "")
            {
                check = false;
                errorProvider.SetError(txtGeschlecht, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(txtGeschlecht, default(string));
            }

            //Geburtsdatum
            if (txtGeburtsdatum.Text == "")
            {
                check = false;
                errorProvider.SetError(txtGeburtsdatum, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(txtGeburtsdatum, default(string));
            }

            if(cbCheckKrankenversichert.Text == "Ja")
            {
                if(txtKrankenkasse.Text == "")
                {
                    check = false;
                    errorProvider.SetError(txtKrankenkasse, "Angabe ist erforderlich!");
                }
                else
                {
                    errorProvider.SetError(txtKrankenkasse, default(string));
                }

                if(txtVersicherungsnummer.Text == "")
                {
                    check = false;
                    errorProvider.SetError(txtVersicherungsnummer, "Angabe ist erforderlich!");
                }
            }
            else if(cbCheckKrankenversichert.Text == "")
            {
                check = false;
                errorProvider.SetError(cbCheckKrankenversichert, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(cbCheckKrankenversichert, default(string));

            }


            //PLZOrt 
            if (txtPlzOrt.Text == "")
            {
                check = false;
                errorProvider.SetError(txtPlzOrt, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(txtPlzOrt, default(string));
            }

            return check;

        }


        //Festlegung Textboxen ob Zahlen/Buchstaben
        //Nur Buchstaben(IsLetter)
        //Nur Zahlen(IsDigit)
        private void TxtVorname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtNachname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtVersicherungsnummer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtPlzOrt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtStrasseHausNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}

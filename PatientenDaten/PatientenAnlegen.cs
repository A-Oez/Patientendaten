using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientenDaten
{
    //Geschlecht!!!
    //Try Catch muss überall noch eingebaut werden!
    public partial class PatientenAnlegen : MetroForm
    {
        Patienten ZwischenspeicherPatient = new Patienten();

        public PatientenAnlegen()
        {
            InitializeComponent();
            //LoadGrid();
            btnDelete.Enabled = false;
            btnChange.Enabled = false;
            btnCreateTermin.Enabled = false;
            btnDeleteTermin.Enabled = false;
        }

        //private void LoadGrid()
        //{
        //    dataGridView1.DataSource = null;
        //    dataGridView1.Rows.Clear();

        //    Business business = new Business();
        //    try
        //    {
        //        var x = business.GetAllPatienten();
        //        dataGridView1.DataSource = x;
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Es ist ein Fehler beim Laden der Daten aus der Datenbank aufgetreten! Bitte kontaktieren Sie ihren Systemadministrator!\n " + ex.Message.ToString());
        //    }

        //    dataGridView1.Columns[0].Visible = false;

        //}

        private void btnAnlegen_Click(object sender, EventArgs e)
        {
            Business business = new Business();

            Patienten newPatient = new Patienten()
            {
                Id = createId(),
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text,
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
                var patient = business.GetPatient(newPatient.Id);
                if (patient == null)
                {
                    UniqueId = true;
                }
            }
            
            try
            {
                business.AddPatient(newPatient);
                //LoadGrid();
            }
            catch(Exception ex)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Business business = new Business();
            business.RemovePatient(ZwischenspeicherPatient);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentid = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            Business business = new Business();
            ZwischenspeicherPatient = business.GetPatient(currentid);

            //Patient in Textboxen laden
            txtVorname.Text = ZwischenspeicherPatient.Vorname;
            txtNachname.Text = ZwischenspeicherPatient.Nachname;
            txtGeburtsdatum.Text = ZwischenspeicherPatient.Geburtsdatum.ToString();
            txtKrankenkasse.Text = ZwischenspeicherPatient.Krankenkasse;
            txtVersicherungsnummer.Text = ZwischenspeicherPatient.Versicherungsnummer.ToString();
            txtPlzOrt.Text = ZwischenspeicherPatient.PLZ_Ort;
            txtStrasseHausNr.Text = ZwischenspeicherPatient.Straße_HausNr;
            txtTelefon.Text = ZwischenspeicherPatient.Telefon;
            txtBesonderheiten.Text = ZwischenspeicherPatient.Besonderheiten;

            //Termine für Patient in Grid laden
            List<Termine> termine = business.GetTermine(ZwischenspeicherPatient.Id);
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = termine;
            dataGridView1.Columns[0].Visible = false;

            btnAnlegen.Enabled = false;
            btnDelete.Enabled = true;
            btnChange.Enabled = true;
            btnCreateTermin.Enabled = true;
            btnDeleteTermin.Enabled = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Business business = new Business();
            business.RemovePatient(ZwischenspeicherPatient);

            Patienten newPatient = new Patienten()
            {
                Id = ZwischenspeicherPatient.Id,
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text,
                Geburtsdatum = Convert.ToDateTime(txtGeburtsdatum.Text),
                Krankenkasse = txtKrankenkasse.Text,
                Versicherungsnummer = Convert.ToInt32(txtVersicherungsnummer.Text),
                PLZ_Ort = txtPlzOrt.Text,
                Straße_HausNr = txtStrasseHausNr.Text,
                Telefon = txtTelefon.Text,
                Besonderheiten = txtBesonderheiten.Text,
            };

            business.AddPatient(newPatient);

            btnDelete.Enabled = true;
            btnChange.Enabled = true;
        }

        private void btnClearTextboxes_Click(object sender, EventArgs e)
        {
            Business business = new Business();
            List<Patienten> patienten = business.GetAllPatienten();

            txtVorname.Text = "";
            txtNachname.Text = "";
            txtGeburtsdatum.Text = "";
            txtKrankenkasse.Text = "";
            txtVersicherungsnummer.Text = "";
            txtPlzOrt.Text = "";
            txtStrasseHausNr.Text = "";
            txtTelefon.Text = "";
            txtBesonderheiten.Text = "";

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = patienten;
            dataGridView1.Columns[0].Visible = false;

            btnAnlegen.Enabled = true;
            btnChange.Enabled = false;
            btnDelete.Enabled = false;
            btnCreateTermin.Enabled = false;
            btnDeleteTermin.Enabled = false;
        }

        private int createId()
        {
            string Id = "";

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                Id += random.Next(0, 9);
            }

            return Convert.ToInt32(Id);
        }

        private void btnCreateTermin_Click(object sender, EventArgs e)
        {
            //Form "Termin Anlegen" öffnen
            TerminAnlegen terminAnlegen = new TerminAnlegen(ZwischenspeicherPatient);
            terminAnlegen.Show();
        }

        private void btnDeleteTermin_Click(object sender, EventArgs e)
        {
            
        }
    }
}


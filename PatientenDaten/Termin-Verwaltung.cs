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
    public partial class TerminVerwaltung : MetroForm
    {
        private Patienten CachePatient = new Patienten();
        private Termine CacheTermin = new Termine();
        private BusinessTermin termin = new BusinessTermin();
        private BusinessPatient patient = new BusinessPatient();
        private bool ChangeTermin = false;

        //-------------------------------------------------------------------------//
        //1.Übertragung der Daten in die Form TerminAnlegen (Patienten Name)

        public TerminVerwaltung(Patienten patient) //Konstruktor für das Anlegen eines Termines
        {
            InitializeComponent();
            CachePatient = patient;
            lblAusgabePatientenName.Text = $"{patient.Vorname}, {patient.Nachname}";
        }

        public TerminVerwaltung(Patienten patient, Termine termin) //Konstruktor für das Bearbeiten eines Termines
        {
            InitializeComponent();
            CachePatient = patient;
            CacheTermin = termin;
            lblAusgabePatientenName.Text = $"{patient.Vorname}, {patient.Nachname}";
            dTPDatum.Value = Convert.ToDateTime(termin.Datum);
            txtUhrzeit.Text = termin.Uhrzeit;
            txtBeschreibung.Text = termin.Beschreibung;
            ChangeTermin = true;
        }

        private void TerminVerwaltung_Load(object sender, EventArgs e)
        {
            lbZurück.Visible = false;
            lbTerminErstellen.Visible = false;
            lbAnweisungUhrzeit.Visible = false;
        }

        //-------------------------------------------------------------------------//
        //2. Buttons Create und Back

        private void btnCreateTermin_Click(object sender, EventArgs e)
        {
            if (CheckFormat())
            {
                try
                {

                    if (!ChangeTermin)
                    {
                        //Termin anlegen

                        Termine newTermin = new Termine()
                        {
                            Id = termin.createId(),
                            PatientenId = CachePatient.Id,
                            Datum = Convert.ToDateTime(dTPDatum.Value.ToString("yyyy-MM-dd")),
                            Uhrzeit = txtUhrzeit.Text,
                            Beschreibung = txtBeschreibung.Text,
                        };

                        bool UniqueId = false;

                        while (UniqueId == false)  //Kontrolle, falls Random ID doppelt generiert wird
                        {
                            var termin = patient.GetPatient(newTermin.Id);
                            if (termin == null)
                            {
                                UniqueId = true;
                            }
                        }

                        try
                        {
                            termin.AddTermin(newTermin);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }
                    else
                    {
                        //Termin Ändern

                        Termine updatedTermine = new Termine()
                        {
                            Id = CacheTermin.Id,
                            PatientenId = CacheTermin.PatientenId,
                            Datum = Convert.ToDateTime(dTPDatum.Value.ToString("yyyy-MM-dd")),
                            Beschreibung = txtBeschreibung.Text,
                            Uhrzeit = txtUhrzeit.Text,
                        };

                        termin.ChangeTermin(CacheTermin, updatedTermine);

                    }

                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }


        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool CheckFormat()
        {
            bool check = true;

            //Uhrzeit
            if (txtUhrzeit.Text == "")
            {
                check = false;
                errorProvider.SetError(txtUhrzeit, "Angabe ist erforderlich!");
            }
            else
            {
                errorProvider.SetError(txtUhrzeit, default(string));
            }

            //Uhrzeit Format Check
            if (txtUhrzeit.Text.Count<char>() == 5 && txtUhrzeit.Text[2] == ':')
            {
                errorProvider.SetError(txtUhrzeit, default(string));
            }
            else
            {
                check = false;
                errorProvider.SetError(txtUhrzeit, "Uhrzeit im falschen Format XX::YY !");
            }

            return check;
        }

        //-------------------------------------------------------------------------//
        //3.Beschriftung der Labels über  Buttons

        //MouseEnter 
        private void BtnBack_MouseEnter(object sender, EventArgs e)
        {
            lbZurück.Visible = true;
        }

        private void BtnCreateTermin_MouseEnter(object sender, EventArgs e)
        {
            lbTerminErstellen.Visible = true;
        }


        //MouseLeave
        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            lbZurück.Visible = false;
        }

        private void BtnCreateTermin_MouseLeave(object sender, EventArgs e)
        {
            lbTerminErstellen.Visible = false;
        }


        //Uhrzeit Format
        private void TxtUhrzeit_Enter(object sender, EventArgs e)
        {
            lbAnweisungUhrzeit.Visible = true;
        }


        private void TxtUhrzeit_Leave(object sender, EventArgs e)
        {
            lbAnweisungUhrzeit.Visible = false;
          
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientenDaten
{
    class BusinessTermin
    {
        public List<Termine> GetTermine(int PatientenId) //Termine von einem Patient -> gefiltert bei PatientenID
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            List<Termine> filteredTermine = new List<Termine>();

            using (context)
            {
                List<Termine> termine = context.Termine.ToList<Termine>();
                foreach (var item in termine)
                {
                    if (item.PatientenId == PatientenId)
                    {
                        filteredTermine.Add(item);
                    }
                }

                return filteredTermine;
            }
        }
        public Termine GetTermin(int Id)
        {
            PatientenDatenEntities context = new PatientenDatenEntities();//AdressverwaltungEntities is representing the database
            using (context)
            {
                Termine termin = context.Termine.FirstOrDefault(r => r.Id == Id);
                return termin;
            }
        }
        public void AddTermin(Termine termin)
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            using (context)
            {
                context.Termine.Add(termin);
                context.SaveChanges();
            }
        }
        public void ChangeTermin(Termine oldTermin, Termine newTermin)
        {
            try
            {
                RemoveTermin(oldTermin);

                try
                {
                    AddTermin(newTermin);
                }
                catch(Exception ex)
                {
                    try
                    {
                        AddTermin(oldTermin);
                    }
                    catch
                    {
                        throw new Exception("Ein Fehler ist beim Verarbeiten aufgetreten! Bitte kontaktieren Sie Ihren Systemadministrator! Fehler ist aufgetreten in PatientenDaten/Business/ChangeTermin beim Versuch den BackUp Patienten einzuspielen da der Versuch die Daten zu updaten fehlgeschlagen ist!");
                    }

                    MessageBox.Show(ex.ToString());
                }
            }
            catch
            {
                throw new Exception("Ein Fehler ist beim Verarbeiten aufgetreten! Bitte kontaktieren Sie Ihren Systemadministrator! Fehler ist aufgetreten in PatientenDaten/Business/ChangeTermin");
            }
        }

        public void RemoveTermin(Termine termin)
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            using (context)
            {
                Termine removedTermin = context.Termine.FirstOrDefault(r => r.Id == termin.Id);
                context.Termine.Remove(removedTermin);
                context.SaveChanges();
            }
        }

        public int createId()
        {
            string Id = "";

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                Id += random.Next(0, 9);
            }

            return Convert.ToInt32(Id);
        }
    }

}

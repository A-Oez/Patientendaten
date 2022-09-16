using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientenDaten
{
    class BusinessPatient
    {

        public List<Patienten> GetAllPatienten() // Aus DataModel
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            using (context)
            {
                List<Patienten> patienten = context.Patienten.ToList<Patienten>();
                return patienten;
            }
        }

        public Patienten GetPatient(int id) //Patient nach ID filtern
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            using (context)
            {
                Patienten patient = context.Patienten.FirstOrDefault(r => r.Id == id);
                return patient;
            }

        }

        public void AddPatient(Patienten patient)
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            using (context)
            {
                context.Patienten.Add(patient);
                context.SaveChanges();
            }
        }

        public void ChangePatient(Patienten oldPatient, Patienten newPatient)
        {
            try
            {
                RemovePatient(oldPatient);

                try
                {
                    AddPatient(newPatient);
                }
                catch
                {
                    try
                    {
                        AddPatient(oldPatient);
                    }
                    catch
                    {
                        throw new Exception("Ein Fehler ist beim Verarbeiten aufgetreten! Bitte kontaktieren Sie Ihren Systemadministrator! Fehler ist aufgetreten in PatientenDaten/Business/ChangePatient beim Versuch den BackUp Patienten einzuspielen da der Versuch die Daten zu updaten fehlgeschlagen ist!");
                    }
                }
            }
            catch
            {
                throw new Exception("Ein Fehler ist beim Verarbeiten aufgetreten! Bitte kontaktieren Sie Ihren Systemadministrator! Fehler ist aufgetreten in PatientenDaten/Business/ChangePatient");
            }

        }
        public void RemovePatient(Patienten patient)
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            using (context)
            {
                Patienten removecontact = context.Patienten.FirstOrDefault(r => r.Id == patient.Id);
                context.Patienten.Remove(removecontact);
                context.SaveChanges();
            }
        }
        public void RemoveAllPatienten()
        {
            PatientenDatenEntities context = new PatientenDatenEntities();
            List<Patienten> contacts = new List<Patienten>();
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Contacts");
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

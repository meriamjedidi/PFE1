using PFE1.Data;
using PFE1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PFE1.Repository
{
    public class PersonnelRepository : IPersonnelRepository
    {

        private readonly ApplicationDbContext _context;
        public PersonnelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Add(Personnel entity)
        {
            _context.Personnel.Add(entity);
            _context.SaveChanges();
            return "Employé ajouté avec succés";

        }

        public string Delete(int id)
        {
            Personnel etudiant = Get(id);
            if (etudiant == null)
            {
                return "l'Employé n'existe pas ";
            }
            else
            {
                _context.Personnel.Remove(etudiant);
                _context.SaveChanges();
                return "Employé supprimé avec succés";
            }
        }

        public Personnel Get(int id)
        {
            return _context.Personnel.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Personnel> GetAll()
        {
            return _context.Personnel.ToList();
        }

        public string Update(int id, Personnel entity)
        {
            Personnel etudiant = _context.Personnel.Find(id);
            if (etudiant == null)
            {
                return "nn trouve";
            }
            else
            {
                etudiant.Nom = entity.Nom;
                etudiant.Prenom = entity.Prenom;
                _context.SaveChanges();
                return "succeful update ";
            }
        }


    }
}

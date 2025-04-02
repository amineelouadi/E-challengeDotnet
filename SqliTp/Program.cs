using SqliTp;
using SqliTp.Models;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new MyContext())
        {
            // Création de la base de données si elle n'existe pas
            context.Database.EnsureCreated();

            // 1. Création des matières
            var mathematiques = new Subject
            {
                Name = "Mathématiques",
                Description = "Algèbre et géométrie"
            };

            var physique = new Subject
            {
                Name = "Physique",
                Description = "Mécanique classique"
            };

            var informatique = new Subject
            {
                Name = "Informatique",
                Description = "Programmation C#"
            };

            context.Subjects.AddRange(mathematiques, physique, informatique);
            context.SaveChanges();

            // 2. Création des personnes (professeurs et étudiants)
            // Professeurs
            var profAmina = new Person { FirstName = "Amina", LastName = "Alaoui" };
            var profMehdi = new Person { FirstName = "Mehdi", LastName = "Benjelloun" };

            // Étudiants
            var amine = new Person { FirstName = "Amine", LastName = "El Ouadi" };
            var anass = new Person { FirstName = "Anass", LastName = "Chakir" };
            var ayoub = new Person { FirstName = "Ayoub", LastName = "Bennis" };
            var hamza = new Person { FirstName = "Hamza", LastName = "Mourad" };

            context.Persons.AddRange(profAmina, profMehdi, amine, anass, ayoub, hamza);
            context.SaveChanges();

            // 3. Création des professeurs avec leurs matières
            var profMaths = new Teacher
            {
                Personal = profAmina,
                HireDate = new DateTime(2018, 9, 1), // Date d'embauche
                Subject = mathematiques
            };

            var profInfo = new Teacher
            {
                Personal = profMehdi,
                HireDate = new DateTime(2020, 3, 15),
                Subject = informatique
            };

            context.Teachers.AddRange(profMaths, profInfo);
            context.SaveChanges();

            // 4. Création des classes
            var classeMathsAvance = new Class
            {
                Name = "Maths Avancées",
                Level = "Avancé",
                Teacher = profMaths
            };

            var classeInfoDebutant = new Class
            {
                Name = "Programmation Débutant",
                Level = "Débutant",
                Teacher = profInfo
            };

            context.Classes.AddRange(classeMathsAvance, classeInfoDebutant);
            context.SaveChanges();

            // 5. Création des étudiants avec numéros d'étudiant
            var etudiantAmine = new Student { StudentNumber = "ET2023001", Personal = amine };
            var etudiantAnass = new Student { StudentNumber = "ET2023002", Personal = anass };
            var etudiantAyoub = new Student { StudentNumber = "ET2023003", Personal = ayoub };
            var etudiantHamza = new Student { StudentNumber = "ET2023004", Personal = hamza };

            context.Students.AddRange(etudiantAmine, etudiantAnass, etudiantAyoub, etudiantHamza);
            context.SaveChanges();

            // 6. Inscription des étudiants aux classes
            var inscriptions = new[]
            {
                new Enrollment { Student = etudiantAmine, Class = classeMathsAvance, EnrollmentDate = DateTime.Now.AddDays(-30) },
                new Enrollment { Student = etudiantAnass, Class = classeMathsAvance, EnrollmentDate = DateTime.Now.AddDays(-25) },
                new Enrollment { Student = etudiantAyoub, Class = classeInfoDebutant, EnrollmentDate = DateTime.Now.AddDays(-20) },
                new Enrollment { Student = etudiantHamza, Class = classeInfoDebutant, EnrollmentDate = DateTime.Now.AddDays(-15) },
                new Enrollment { Student = etudiantAmine, Class = classeInfoDebutant, EnrollmentDate = DateTime.Now.AddDays(-10) }
            };

            context.Enrollments.AddRange(inscriptions);
            context.SaveChanges();

            // Affichage des résultats
            Console.WriteLine("Base de données scolaire créée avec succès !");
            Console.WriteLine("\nDétails de la base :");
            Console.WriteLine($"- Professeurs: {context.Teachers.Count()}");
            Console.WriteLine($"- Étudiants: {context.Students.Count()}");
            Console.WriteLine($"- Classes: {context.Classes.Count()}");
            Console.WriteLine($"- Inscriptions: {context.Enrollments.Count()}");

            // Requête d'exemple : étudiants en maths
            var etudiantsMaths = context.Enrollments
                .Where(e => e.ClassId == classeMathsAvance.Id)
                .Select(e => e.Student.Personal.FirstName)
                .ToList();

            Console.WriteLine($"\nÉtudiants en Maths Avancées: {string.Join(", ", etudiantsMaths)}");

            // Requête : professeur d'informatique
            var profInfoQuery = context.Teachers
                .Where(t => t.Subject.Name == "Informatique")
                .Select(t => t.Personal.FirstName)
                .FirstOrDefault();

            Console.WriteLine($"Professeur d'Informatique: {profInfoQuery}");
        }
    }
}
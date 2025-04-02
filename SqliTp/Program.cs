using SqliTp;
using SqliTp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SqliTp.Data.Interfaces;
using SqliTp.Data.Repositories;


class Program
{
    static void Main(string[] args)
    {
        // Configuration des services
        var services = new ServiceCollection();

        // Configuration de DbContext
        services.AddDbContext<MyContext>(options =>
            options.UseSqlServer("VotreChaîneDeConnexion"));

        // Enregistrement des repositories
        services.AddScoped(typeof(IReadOnlyRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        // Construction du provider
        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            // Récupération des services
            var studentRepo = scope.ServiceProvider.GetRequiredService<IRepository<Student>>();
            var teacherRepo = scope.ServiceProvider.GetRequiredService<IRepository<Teacher>>();

            Console.WriteLine("Ajout d'un nouvel étudiant...");
            var newStudent = new Student
            {
                StudentNumber = "ET2024001",
                Personal = new Person { FirstName = "Karim", LastName = "Benzema" }
            };

            studentRepo.Add(newStudent);
            var changes = studentRepo.SaveChanges();
            Console.WriteLine($"{changes} enregistrement(s) modifié(s)");

            // Lecture des données
            Console.WriteLine("\nListe des étudiants:");
            var students = studentRepo.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentNumber}: {s.Personal.FirstName} {s.Personal.LastName}");
            }
        }
    }
}
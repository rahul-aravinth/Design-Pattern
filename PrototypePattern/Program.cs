using System;

namespace PrototypePattern
{
    class ApplicationLaunchInDifferentCountry
    {
        // Client
        static void Main()
        {
            GitHub gitHub = new GitHub();
            gitHub["CandyCrush"] = new Repository("CandyCrush", "SomeCompany", "androidstudio", "Amazon Ad");
            CreateClone(gitHub["CandyCrush"], "India", "Flipkart Ad");
            CreateClone(gitHub["CandyCrush"], "China", "Alibaba Ad");
            CreateClone(gitHub["CandyCrush"], "Dubai", "JamesEdition Ad");
            Console.ReadKey();
        }
        private static void CreateClone(GitHubRepsitoryPrototype App, string Country, string OtherAd){
            Repository AppCloned = App.Fork(Country, OtherAd) as Repository;
        }
    }

    // Prototype
    abstract class GitHubRepsitoryPrototype{
        public abstract GitHubRepsitoryPrototype Fork(string Country, string OtherAd);
    }

    // Concreate Prototype
    class Repository : GitHubRepsitoryPrototype{
        private string ProjectName;
        private string Author;
        private string Language;
        private string Ad;
        public Repository(string name, string author, string lang, string ad){
            ProjectName = name;
            Author = author;
            Language = lang;
            Ad = ad;
            Console.WriteLine("Creating Repository for Global Release: ");
            Console.WriteLine(" ProjectName - " + ProjectName);
            Console.WriteLine(" Author - " + Author);
            Console.WriteLine(" Language - " + Language);
            Console.WriteLine(" Ad - " + Ad);
        }
        public override GitHubRepsitoryPrototype Fork(string Country, string OtherAd)
        {
            string projectDetails = GetProjectDeails(OtherAd);
            Console.WriteLine("Cloning Repository for Country: \"{0}\": ", Country);
            Console.WriteLine(" ProjectName - " + ProjectName);
            Console.WriteLine(" Author - " + Author);
            Console.WriteLine(" Language - " + Language);
            Console.WriteLine(" Ad - " + OtherAd);
            return MemberwiseClone() as GitHubRepsitoryPrototype;
        }
        private string GetProjectDeails(string OtherAd)
        {
            var projectDetails = string.Empty;
            if (!string.IsNullOrWhiteSpace(ProjectName))
            {
                projectDetails += ProjectName + ", ";
            }
            if (!string.IsNullOrWhiteSpace(Author))
            {
                projectDetails += Author + ", ";
            }
            if (!string.IsNullOrWhiteSpace(Language))
            {
                projectDetails += Language + ", ";
            }
            if (!string.IsNullOrWhiteSpace(OtherAd))
            {
                projectDetails += OtherAd + ", ";
            }
            return projectDetails;
        }
    }

    // Prototype Manager
    class GitHub{
        private Dictionary<string, GitHubRepsitoryPrototype> repo = new Dictionary<string, GitHubRepsitoryPrototype>();
        public GitHubRepsitoryPrototype this[string name]{
            get { return repo[name]; }
            set { repo.Add(name, value); }
        }
    }
}
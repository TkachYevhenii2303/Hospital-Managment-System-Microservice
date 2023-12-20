using Bogus;
using HospitalManagementSystem.Domains.Entities.Structures;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.SeedingOperations.Bogus
{
    public class Seeding
    {
        private static List<Employee> Employees { get; set; } = new();

        private static List<Position> Positions { get; set; } = new();

        private static List<HasPosition> HasRoles { get; set; } = new();

        private static List<Hospital> Hospitals { get; set; } = new();

        private static List<Department> Departments { get; set; } = new();

        private static List<InDepartments> InDepartments { get; set; } = new();

        private static List<Shedules> Shedules { get; set; } = new();

        public static List<Employee> SeedEmployees()
        {
            Employees = new Faker<Employee>(locale: "en")
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Email, (f, o) => f.Internet.Email(o.FirstName, o.LastName))
                .RuleFor(x => x.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Password, f => f.Internet.Password())
                .RuleFor(x => x.ActiveIs, f => f.Random.Bool())
                .Generate(20);

            return Employees;
        }

        public static List<Position> SeedPositions()
        {
            Positions = new Faker<Position>().Generate(6);

            var types = Enum.GetNames(typeof(PositionTypesEnum));

            for (int i = 0; i < types.Count(); i++) { Positions[i].Title = types[i]; }

            return Positions;
        }

        public static List<HasPosition> SeedHasRoles()
        {
            HasRoles = new Faker<HasPosition>()
                .RuleFor(x => x.EmployeesId, f => f.PickRandom(Employees).Id)
                .RuleFor(x => x.PositionId, f => f.PickRandom(Positions).Id)
                .Generate(30);

            return HasRoles;
        }

        public static List<Hospital> SeedHospitals()
        {
            Hospitals = new Faker<Hospital>()
                .RuleFor(x => x.Title, f => f.Company.CompanyName())
                .RuleFor(x => x.Details, f => f.Company.CatchPhrase())
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .Generate(10);

            return Hospitals;
        }

        public static List<Department> SeedDepartments()
        {
            Departments = new Faker<Department>()
                .RuleFor(x => x.Title, f => f.Commerce.Department())
                .RuleFor(x => x.HospitalId, f => f.PickRandom(Hospitals).Id)
                .Generate(20);

            return Departments;
        }

        public static List<InDepartments> SeedInDepartments()
        {
            InDepartments = new Faker<InDepartments>()
                .RuleFor(x => x.TimeFrom, f => f.Date.Past())
                .RuleFor(x => x.TimeTo, f => f.Date.Future())
                .RuleFor(x => x.ActiveIs, f => f.Random.Bool())
                .RuleFor(x => x.EmployeesId, f => f.PickRandom(Employees).Id)
                .RuleFor(x => x.DepartmentsId, f => f.PickRandom(Departments).Id)
                .Generate(100);

            return InDepartments;
        }

        public static List<Shedules> SeedShedules()
        {
            Shedules = new Faker<Shedules>()
                .RuleFor(x => x.TimeStart, f => f.Date.Past())
                .RuleFor(x => x.TimeEnd, f => f.Date.Future())
                .RuleFor(x => x.InDepartmentsId, f => f.PickRandom(InDepartments).Id)
                .Generate(100);

            return Shedules;
        }
    }
}

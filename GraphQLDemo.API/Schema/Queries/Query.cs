using Bogus;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        public IEnumerable<CourseType> GetCourses()
        {
            var courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, _ => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>());

            var courses = courseFaker.Generate(5);
            return courses;
        }

        [GraphQLDeprecated("This query is deprecated.")]
        public string Instructions => "Hello World";
    }
}

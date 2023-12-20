using System.Data;

namespace HospitalManagementSystem.Configurations.Configurations
{
    public class Configurations<TRepository, TEntity>
        where TRepository : class
    {
        private readonly Func<List<TEntity>> _seeding;

        private readonly TRepository _repository;

        private readonly IDbTransaction _transaction;

        public Configurations(Func<List<TEntity>> Seeding_Bogus, TRepository Repository, IDbTransaction transaction)
        {
            _seeding = Seeding_Bogus;

            _repository = Repository;

            _transaction = transaction;
        }

        public async Task SeedRepository()
        {
            try
            {
                var entities = _seeding.Invoke();

                var inserting = _repository.GetType().GetMethod("InsertEntityAsync");

                foreach (var entity in entities)
                {
                    await (Task)inserting.Invoke(_repository, new object[] { entity });
                }

                await Console.Out.WriteLineAsync($"The seeding for {typeof(TEntity).Name} is complete!!!");
            }
            catch (Exception exception)
            {
                throw new Exception($"Something went wrong while seeding Database!!! {exception.Message}");
            }
        }
    }
}

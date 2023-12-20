using AutoMapper;

namespace Hospital_Management_System_Applications.Common.Mapping.Interfaces
{
    public interface IMappingFrom<TEntity>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TEntity), GetType());
    }
}

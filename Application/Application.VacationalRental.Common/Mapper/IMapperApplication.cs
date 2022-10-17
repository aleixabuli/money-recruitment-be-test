
namespace Application.VacationalRental.Common.Mapper
{
    public interface IMapperApplication<TSource, TResponse>
        where TResponse : class
        where TSource : class
    {
        TResponse Map(TSource source);
    }
}

namespace SuperFunElection.DtoMappers
{
    public interface IMap<TSource, TResult>
    {
        TResult MapFrom(TSource sourceObject);
    }
}

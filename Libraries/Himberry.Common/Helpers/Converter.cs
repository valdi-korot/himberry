using AutoMapper;

namespace Himberry.Common.Helpers
{
    public static class Converter
    {
        public static TTarget Convert<TTarget, TSource>(TSource source)
        {
            var result = Mapper.Map<TSource, TTarget>(source);
            return result;
        }
    }
}
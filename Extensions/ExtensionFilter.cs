namespace api.Controllers;
public static class ExtensionFilter{
    public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Exception ex){
        try{
            return source.First(predicate);
        }
        catch{
            throw ex;
        }
    }
}
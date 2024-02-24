namespace Arc.Utiliy
{
    public static class ArrayUtility<T>
    {
        public static void ArrayToList(T[] source, List<T> target)
        {
            foreach (T item in source)
            {
                target.Add(item);
            }
        }
    }
}

namespace Arc.Utiliy
{
    public static class StreamUtility
    {
        public static bool HasNext(Stream stream)
        {
            return stream.Position < stream.Length;
        }
    }
}

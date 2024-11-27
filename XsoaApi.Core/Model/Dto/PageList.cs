namespace XsoaApi.Core
{
    public class PageList<T>
    {
        public List<T> Records { get; set; }
        public int Current { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}

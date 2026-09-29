namespace WebApplication1.Exceptions
{
    public class DuplicateProductNameException : Exception
    {
        public DuplicateProductNameException(string name)
            : base($"Ya existe un producto con el nombre \"{name}\".")
        {
        }
    }
}

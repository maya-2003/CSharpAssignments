using EFCoreAssignment01.Data;

namespace EFCoreAssignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ItiDbContext context = new ItiDbContext()) ;
        }
    }
}

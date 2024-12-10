namespace CasoPractico2.Services
{
    public class ScopedServices : IScopedServices
    {
        Guid ID;

        public ScopedServices()
        {
            ID = Guid.NewGuid();
        }
        public Guid ObtenerID()
        {
            return ID;
        }
    }

}

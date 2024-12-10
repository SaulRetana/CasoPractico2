
namespace CasoPractico2.Services
{
    public class TransientServices : ITrasientServices
    {
        Guid ID;

        public TransientServices()
        {
            ID = Guid.NewGuid();
        }
        public Guid ObtenerID()
        {
            return ID;
        }
    }
}

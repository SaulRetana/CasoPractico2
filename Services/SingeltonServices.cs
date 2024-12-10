﻿namespace CasoPractico2.Services
{
    public class SingeltonServices : ISingeltonServices
    {
        Guid ID;

        public SingeltonServices()
        {
            ID = Guid.NewGuid();
        }
        public Guid ObtenerID()
        {
            return ID;
        }
    }
}

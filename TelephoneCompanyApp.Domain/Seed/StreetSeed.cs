﻿using TelephoneCompanyApp.Domain.Entities;
using TelephoneCompanyApp.Domain.Repositories.Streets;

namespace TelephoneCompanyApp.Domain.Seed
{
    public class StreetSeed : BaseSeed
    {
        private readonly IStreetRepository _streetRepository;
        public StreetSeed(IStreetRepository streetRepository)
        {
            _streetRepository = streetRepository;
        }

        public override void Initialize()
        {
            var streetNames = new string[] {"Pushkinskaya", "Kashtanovaya", "Leninskaya" };
            foreach (var streetName in streetNames)
            {
                _streetRepository.Add(new Street(streetName));
            }

            var streets = _streetRepository.GetAll();
        }
    }
}
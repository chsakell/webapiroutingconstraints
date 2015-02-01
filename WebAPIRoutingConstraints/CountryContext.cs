using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.Concurrent;

namespace WebAPIRoutingConstraints
{
    public class CountryContext
    {
        private readonly ConcurrentDictionary<int, Country> _countries; 
        public CountryContext()
        {
            _countries = new ConcurrentDictionary<int, Country>();
            _countries.TryAdd(1, new Country { Name = "GREECE", Abbreviation = "GR"  });
            _countries.TryAdd(2, new Country { Name = "France", Abbreviation = "FR" });
            _countries.TryAdd(3, new Country { Name = "United Kingdom",Abbreviation = "UK" });
            _countries.TryAdd(4, new Country { Name = "India", Abbreviation = "IN" });
            _countries.TryAdd(5, new Country { Name = "Canada", Abbreviation = "CA" });
        }

        public IEnumerable<Country> All
        {
            get { return _countries.Values; }
        }

        public Country GetCountry(string abbreviation)
        {
            return _countries.FirstOrDefault(p => 
                string.Equals(p.Value.Abbreviation,abbreviation, StringComparison.OrdinalIgnoreCase)).Value;
        }
    }
}
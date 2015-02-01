using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIRoutingConstraints
{
    public class CountriesController : ApiController
    {
        public static CountryContext context = new CountryContext();

        // GET api/<products>
        public IEnumerable<Country> Get()
        {
            return context.All;
        }

        // GET api/<products>/5
        public Country Get(string abbreviation)
        {
            return context.GetCountry(abbreviation);
        }
    }
}
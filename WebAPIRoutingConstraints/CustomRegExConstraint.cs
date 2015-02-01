using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebAPIRoutingConstraints
{
    public class CustomRegExConstraint : IHttpRouteConstraint
    {
        private readonly string _regEx;

        public CustomRegExConstraint(string regEx)
        {
            if (string.IsNullOrEmpty(regEx))
            {
                throw new ArgumentNullException("regEx");
            }

            _regEx = regEx;
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {

            if (values[parameterName] != RouteParameter.Optional)
            {

                object value;
                values.TryGetValue(parameterName, out value);
                string pattern = "^(" + _regEx + ")$";
                string input = Convert.ToString(
                    value, CultureInfo.InvariantCulture);

                return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            }

            return true;
        }
    }
}
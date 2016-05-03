using Nancy;

namespace Server
{
    /// <summary>
    /// Serves cross-domain policy so we can run locally.
    /// </summary>
    public class CrossDomainService : NancyModule
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public CrossDomainService()
        {
            Get["/crossdomain.xml"] = _ => "<?xml version=\"1.0\"?>" +
                                           "<!DOCTYPE cross-domain-policy SYSTEM \"http://www.adobe.com/xml/dtds/cross-domain-policy.dtd\">" +
                                           "<cross-domain-policy>" +
                                           "    <site-control permitted-cross-domain-policies=\"master-only\"/>" +
                                           "    <allow-access-from domain=\"*\"/>" +
                                           "    <allow-http-request-headers-from domain=\"*\" headers=\"*\"/>" +
                                           "</cross-domain-policy>";
        }
    }
}
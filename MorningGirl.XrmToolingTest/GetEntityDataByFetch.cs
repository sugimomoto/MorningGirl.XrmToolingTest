using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningGirl.XrmToolingTest
{
    public class CrmConnect
    {
        public static void GetEntityDataByFetch()
        {
            var crmSvc = new CrmServiceClient("AuthType=Office365;Username=***@***.onmicrosoft.com; Password=***;Url=https://***.crm7.dynamics.com");

            if (!crmSvc.IsReady)
            {
                Console.WriteLine("Error");
                return;
            }

            var fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
  <entity name='account'>
    <attribute name='name' />
    <attribute name='primarycontactid' />
    <attribute name='telephone1' />
    <attribute name='accountid' />
    <order attribute='name' descending='false' />
  </entity>
</fetch>";

            var result = crmSvc.GetEntityDataByFetchSearch(fetchXml);

            foreach (var entity in result.Values)
            {
                Console.WriteLine(entity["name"]);
            }

            Console.ReadKey();
        }
    }
}

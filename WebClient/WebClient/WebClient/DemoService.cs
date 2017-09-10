using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    public class TestA
    {
        public string PropA { get; set; }
    }

    class DemoService:DataService<TestA>
    {
        public static void Iniacilizeservice
            (DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("TestMethodA", ServiceOperationRights.All);
        }

        [WebGet]
        [SingleResult]
        public TestA TestMethodA() {
            return new TestA() { PropA = "hola Mundo" };
        }
    }
}

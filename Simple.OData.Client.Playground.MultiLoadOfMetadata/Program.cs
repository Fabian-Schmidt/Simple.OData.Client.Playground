using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.OData.Client.Playground.MultiLoadOfMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example Application to test multiple load of Metadata document.");
            Console.WriteLine("Run Fiddler to check calls.");
            //Example Fiddler trace in FiddlerExample.saz.

            //Init the Client
            var client = new Simple.OData.Client.ODataClient("http://services.odata.org/V4/TripPinServiceRW");

            //Init two task to load Photos and People entities.
            var photosTask = client.For("Photos").FindEntriesAsync();
            var peopleTask = client.For("People").FindEntriesAsync();

            //Wait for the Tasks.
            System.Threading.Tasks.Task.WaitAll(photosTask, peopleTask);
        }
    }
}

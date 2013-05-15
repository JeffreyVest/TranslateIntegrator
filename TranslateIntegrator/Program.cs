using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft;

namespace TranslateIntegrator
{
    class Program
    {
        private static void Main()
        {
            var serviceRootUri = new Uri("https://api.datamarket.azure.com/Bing/MicrosoftTranslator/v1/Translate");
            string accountKey = Secrets.AccountInfo.Instance.AccountKey;
            var tc = new TranslatorContainer(serviceRootUri) {Credentials = new NetworkCredential(accountKey, accountKey)};

            const string origin = "I'm going to feed the dogs then take them out for a walk.";
            const string @from = "en";
            const string to = "es";

            string start = origin;
            int i = 0;
            for (; i < 10; i++)
            {
                string trans = Translate(tc, start, to, @from);
                string backTrans = Translate(tc, trans, @from, to);

                string currentState = string.Format("Iteration {0}: {1} - {2}", i + 1, start, trans);
                Console.WriteLine(currentState);
                Debug.WriteLine(currentState);
                
                if (backTrans == start)
                    break;
                start = backTrans;
            }

            Console.ReadKey();
        }

        private static string Translate(TranslatorContainer tc, string text, string to, string from)
        {
            var query = tc.Translate(text, to, from);
            var results = query.Execute().ToList();
            var result = results.First();
            return result.Text;
        }
    }
}

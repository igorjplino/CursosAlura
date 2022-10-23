using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace csharp7.R10.depois
{
    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            //obs: O método acima seria o Main do programa: static void Main(string[] args)
            WriteLine(csharp7.R10.antes.MenuItem.GetGoogleAsync().GetAwaiter().GetResult());
        }

        public static async Task<string> GetGoogleAsync()
        {
            return await new HttpClient().GetStringAsync("http://www.google.com");
        }
    }
}

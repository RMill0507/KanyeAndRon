using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanyeVsRon
{
    public class QuoteGen
    {
        public static void KanyeQuotes()
        {
            var client = new HttpClient();//Allows to send requests with Http--making a new object
            var kanyeURL = "https://api.kanye.rest/";//stores kanye api url in a variable

            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;//we send a GET request to the specified URL and return the response
            //body as a string in an asynchronous operation. Basically, we get a string of JSON back
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();//Kanye quote looks neater and prettier
            //Now we can parse through our JSON response and grab
            //the values we are interested in. In this case, we grab the VALUE associated with the “quote” NAME.
            //Remember, JSON uses a NAME : VALUE pairing system.
            Console.WriteLine($"Kanye: \'{kanyeQuote}\'");
        }
        public static void RonQuotes()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine($"Ron: {ronQuote}");
        }
    }
}

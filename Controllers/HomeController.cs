using System.Diagnostics;
using coremvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

namespace coremvc.Controllers
{
    //public class Configuration
    //{
    //    public static void MapRoutes(IRouteBuilder builder)
    //    {
    //        // Register the route here
    //        builder.MapRoute(
    //            name: "Get",
    //            template: "{area:person}/{controller=Contact}/{action=Index}/{id?}");
    //        builder.MapRoute(
    //            name: "Post",
    //            template: "{area:person}/{controller=Contact}/{action=phone}/{id?}");

    //    }
    //}
    public class HomeController : Controller
    {
        //[RequireHttps]
        ////cross site request forgeries
        //[ValidateAntiForgeryToken]
        ////below routing should be like this: action should accept the path parameter and a Book object from the request body.
        //[Route]
        //[Route("/book/{genre}")]
        public IActionResult Create(Item item)
        {
            string msg = "";
            if ((item.Name.Length>=3 && item.Name.Length<=15) && (item.Count>=0 && item.Count<=1000))
            {
                msg = "Created!";
            }
            else
            {
                msg = "Item";
            }

                return View(msg);
        }

        //[Route("/book/{genre, book}")]
        //public IActionResult AddBook(string genre, Book book)
        //{
        //    return Content($"General genre: {genre}, "
        //                    + $"name: {book.Name}, page count: {book.PageCount}, "
        //                    + $"book genre: {book.Genre}");
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Student st = new Student()
            {
                roll = 1,
                gender = "Male",
                name = "raagalu",
                age = 100,
                course = "Computers",
                fee = 1,
            };

            Product p = new Product()
            {
                prodName = "Dragon Fruits",
                prodId = 485,
                prodPrice = 8000,
                prodQty = 2
            };

            //First non repeat character in a given string
            string input = "swiss";
            char result = FirstNonRepeatingChar(input);
            ViewData["FirstNoneRepeatChar"] = result;

            string x = "Rapidi";
            string reversed = ReverseString(x);
            ViewData["dd"] = reversed;

            string rev_sent = "where is poola rangadu";
            string reversed_sent = ReverseSentence(rev_sent);
            ViewData["rev_sen"] = reversed_sent;

            string palstring = "Race Car";
            ViewData["pal"] = ispalindrome(palstring);

            string firstRep_str = "swiss";
            ViewData["first_rep"] = FirstRepeatChar(firstRep_str);

            return View(p);
        }

        public IActionResult showStudents()
        {
            List<Student> st = new List<Student>()
            {
                new Student(){roll = 1, age = 45, name="poosalu", course=".net core", gender="Male", fee = 396500},
                new Student(){roll = 23, age = 46, name="Ragaalu", course="GenAI", gender="FeMale", fee = 38700},
                new Student(){roll = 34, age = 48, name="Pentaalu", course="DS", gender="Male", fee = 34589},
                new Student(){roll = 46, age = 56, name="ravvakka", course="ML", gender="FeMale", fee = 56788},
                new Student(){roll = 42, age = 58, name="randakka", course="Python", gender="FeMale", fee = 988454}
            };
            return View(st);
        }

        public IActionResult MyForm()
        {
            return View();
        }
        public IActionResult ShowData(string sid, string nm, string gen, string age)
        {
            Student st = new Student();
            st.name = nm;
            st.age = Convert.ToInt32(age);
            st.gender = gen;
            return View("ContactUs", st);
        }

        [HttpPost]
        public IActionResult ShowData2()
        {
            Student st = new Student();
            st.roll = Convert.ToInt32(Request.Form["sid"]);
            st.name = Request.Form["nm"].ToString();
            st.age = Convert.ToInt32(Request.Form["age"]);
            st.gender = Request.Form["sgen"].ToString();
            return View("ContactUs", st);
        }
        
        
        public IActionResult ShowDataIFormCollection(IFormCollection data)
        {
            Student st = new Student();
            st.roll = Convert.ToInt32(data["sid"]);
            st.name = data["nm"].ToString();
            st.age = Convert.ToInt32(data["age"]);
            st.gender = data["sgen"].ToString();
            return View("ContactUs", st);
        }
        
        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static char FirstNonRepeatingChar(string str)
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            // Count frequency of each character
            foreach (char c in str)
            {
                if (frequency.ContainsKey(c))
                    frequency[c]++;
                else
                    frequency[c] = 1;
            }

            // Find first character with count = 1
            foreach (char c in str)
            {
                if (frequency[c] == 1)
                    return c;
            }

            return '_'; // return underscore if no non-repeating char
        }

        static string ReverseSentence(string str)
        {
            string[] wordsArray = str.Split(" ");
            Array.Reverse(wordsArray);
            return string.Join(" ", wordsArray);
        }

        static bool ispalindrome(string str)
        {
            string cleaned = str.ToLower().Replace(" ", "");
            char[] clearnedArr = cleaned.ToCharArray();
            Array.Reverse(clearnedArr);
            string reversed = new string(clearnedArr);
            bool isPalindrome = cleaned == reversed;
            return isPalindrome;
        }

        static string FirstRepeatChar(string str)
        {
            char? firstNonRepeated = str.GroupBy(c => c)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key).FirstOrDefault();

            if (firstNonRepeated.HasValue)
            {
                return firstNonRepeated.Value.ToString();
            }
            else
            {
                return "No unique character found";
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Default()
        {
            return View("ContactUs");
        }

    }
}

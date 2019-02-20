using Microsoft.AspNetCore.Mvc; // This line imports the Microsoft.AspNetCore.Mvc namespace into our controller, so we have access to ASP.NET Core's built in Controller class
using FriendLetter.Models;

namespace FriendLetter.Controllers
{
    public class HomeController : Controller //  By adding : Controller to our HomeController class, we tell .NET that HomeController should inherit or extend functionality from ASP.NET Core's built-in Controller class 
    { 
        [Route("/hello")]
        public string Hello() { return "Hello friend!"; } //This Hello() method represents a route in our application. That is, a certain area of our application a user can visit eg. the / after url: facebook.com/tristansetha
        
        [Route("/goodbye")] // overrides url so we can directly visit without going to home first
        public string Goodbye() { return "Goodbye friend."; }

        // [Produces("text/html")] // canceled out because html is no longer define in letter()
        [Route("/Letter")] // "/" = homepage // letter route is in this home controller
        public ActionResult Letter() 
        {  // ActionResult. This is a class built into the MVC library meant to handle rendering views. (And we already have access to logic from MVC here in this file, thanks to our using Microsoft.AspNetCore.Mvc; statement.)  // view() when invoked this route should now return a view in the server's response to the client
            LetterVariable myLetterVariable = new LetterVariable();
            myLetterVariable.SetRecipient("Jessica");
            myLetterVariable.SetSender("John");
            return View(myLetterVariable);
        }
       
        [Route("/journal")]
        public ActionResult Journal() { return View(); }

        [Route("/")]
        public ActionResult Form() { return View(); }

        [Route("/postcard")] //Because we told our <form> in Form.cshtml to have an action="/postcard", the route matching the /postcard path is automatically invoked. That's our Postcard() route.
        public ActionResult Postcard(string recipient, string sender, string location, string souvenir) // from form html
        {
            LetterVariable myLetterVariable = new LetterVariable();
            myLetterVariable.SetRecipient(recipient);
            myLetterVariable.SetSender(sender);

            myLetterVariable.SetLocation(location);
            myLetterVariable.SetSouvenir(souvenir);
            return View(myLetterVariable);
        }

    }  
}

// how does letter know which view directory to render? views directory is the first directory located by views(). within in autio locates a subdirectory whose name matches the controller name. Put letter route is in a home controller so it looks for a directory called home
// letter.cshtml name matches with letter() route. thats why naming is important

// Our Letter() route now does three things when invoked (that is, when a client sends a request to our root route, or, localhost:5000):
// It creates a new empty LetterVariable object named myLetterVariable.
// Using the SetRecipient() method defined in Models/LetterVariable.cs, it sets the _recipient property of this object to "Jessica".
// It passes this myLetterVariable object into the View() method as an argument. This ensures our corresponding Letter.cshtml view now has access to our LetterVariable object.

// Model Binding
// Remember how we used @Model.GetRecipient() in Letter.cshtml? MVC uses something called model binding to pass data from one part of an application to another. Instances of @Model in the view represent whatever we pass into View() as an argument on the corresponding route.
// In this case, we've passed the View() method in the Letter() route the object myLetterVariable as an argument. This means any instances of @Model in the Letter.cshtml view now represent myLetterVariable. So when we call @Model.GetRecipient() in Letter.cshtml, it's the same as calling myLetterVariable.GetRecipient().
// Let’s check it out! We'll restart our server, visit http://localhost:5000, and see the name "Jessica" is now rendered in our view!
// But what if we wanted to send the letter to Lina instead? Well, we'd just change the argument provided to myLetterVariable.SetRecipient() in the Letter() route:
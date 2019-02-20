namespace FriendLetter.Models //We place the LetterVariables class in a FriendLetter.Models namespace. This means that any other files that need access to our model's logic can import it with the statement using FriendLetter.Models;.
{                             // In our case, the FriendLetter.Models name is ideal, because this namespace contains all the models in our FriendLetter project
  public class LetterVariable
  {
      private string _recipient;
      private string _sender;
      private string _location;
      private string _souvenir;

      public string GetRecipient() //getter method
      {
          return _recipient;
      }

      public string GetSender()
      {
          return _sender;
      }

      public string GetLocation()
      {
          return _location;
      }

      public string GetSouvenir()
      {
          return _souvenir;
      }

      public void SetRecipient(string newRecipient) // include a setter method for the _recipient property so we may change whose name it displays as necessary: decalring a string variable to assign to the value passing in to use within the function
      {
          _recipient = newRecipient;
      }

      public void SetSender(string newSender)
      {
          _sender = newSender;
      }

      public void SetLocation(string newLocation)
      {
          _location = newLocation;
      }

      public void SetSouvenir(string newSouvenir)
      {
          _souvenir = newSouvenir;
      }
  }
}
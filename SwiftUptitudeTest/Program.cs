

using SwiftUptitudeTest;
using SwiftUptitudeTest.HelperMethods;
using System.Reflection;




Console.WriteLine("Welcome to SWIFT login page");

int tries = 0;
Methods methods = new Methods();
UserDetails userDetails = new UserDetails();
while (tries <=3)
{
    start:
    Console.Write("Enter username :");
    userDetails.UserName = Console.ReadLine();
    Console.Write("Enter password:");
    userDetails.Password = Console.ReadLine();
    var validateUser = methods.IsValidUser(userDetails.UserName);
    var validatePassword = methods.IsValidPassword(userDetails.Password);

    if (validatePassword == true && validateUser ==true)
    {
        Console.WriteLine("Successfully logged in");

       var collectionList = methods.GetCollectionIfo();
        var deliveryList = methods.GetDeliveryInfo();
        var parcelInfo = methods.GetParcel();
        var serviceSummary = methods.ServiceSummary();
        Console.Clear();
        methods.CheckOut(collectionList, deliveryList,parcelInfo, serviceSummary);
    }
    else
    {
        tries++;
        Console.WriteLine($"Incorrect username or password. You have {tries} left. ");
        if (tries == 0)
        {
            Console.WriteLine("You have nomore tries left \n Choose an option \n" +
                " 1. Re-enter the username and password \n " +
                "2.Recreate username and password");
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    tries = 0;
                    break;
                case 2:
                    Console.WriteLine("Create a new username and password");
                    do
                    {
                        Console.Write("Enter user name (Must have atleat 4 or more characters)");
                        userDetails.UserName = Console.ReadLine();
                        Console.Write("Enter a password (Must have 6-8 characters)");
                        userDetails.Password = Console.ReadLine();

                    } while (!methods.IsValidUser(userDetails.UserName) || !methods.IsValidPassword(userDetails.Password));

                    Console.WriteLine("Users created successfully");
                    tries = 0;
                    goto start;
                    

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

}

  


    








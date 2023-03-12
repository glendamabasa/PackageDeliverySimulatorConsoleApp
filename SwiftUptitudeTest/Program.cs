

using SwiftUptitudeTest;
using SwiftUptitudeTest.HelperMethods;
using System.Reflection;



Console.WriteLine("__________________________________________________________");
Console.WriteLine("            Welcome to SWIFT login page");
Console.WriteLine("__________________________________________________________");

int tries = 0;
Methods methods = new Methods();
UserDetails userDetails = new UserDetails();
FileHandler fileHandler = new FileHandler();
while (tries <=3)
{
    start:
    Console.Write("Enter username :");
    string username = Console.ReadLine();
    Console.Write("Enter password:");
    string password = Console.ReadLine();

    Console.Write("Loading ");
    for (int i = 0; i < 3; i++)
    {
        Console.Write(".");
        Thread.Sleep(200); // delay for half a second
    }
    userDetails = fileHandler.ReadFromFile();

    if (userDetails.UserName == username && userDetails.Password==password)
    {
        Console.WriteLine("__________________________________________________________");
        Console.WriteLine("Successfully logged in");
        Console.WriteLine("__________________________________________________________");

        var collectionDetails = methods.GetCollectionIfo();
        var deliveryDetails = methods.GetDeliveryInfo();
        var parcelInfo = methods.GetParcel();
        var serviceSummary = methods.GetServiceSummary();
        Console.Clear();
        methods.CheckOut(collectionDetails, deliveryDetails, parcelInfo, serviceSummary);
    }
  
    else
    {
   
        Console.WriteLine();
        Console.WriteLine($"Incorrect username or password.");
        tries++;
        Console.WriteLine();
        if (tries == 3)
        {
            Console.WriteLine("__________________________________________________________");

            Console.WriteLine("You have nomore tries left \n Choose an option \n" +
                " 1. Re-enter the username and password \n " +
                "2.Recreate username and password");
            Console.WriteLine("__________________________________________________________");

            Console.WriteLine();
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    tries = 0;
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Create a new username and password");
                    Console.WriteLine();
                    do
                    {
                        addNewUser:
                        Console.Write("Enter user name (Must have atleat 4 or more characters) :");
                         username = Console.ReadLine();
                        Console.Write("Enter a password (Must have 6-8 characters) :");
                        password = Console.ReadLine();
                        var validateUser = methods.IsValidUser(username);
                        var validatePassword = methods.IsValidPassword(password);
                        if (validatePassword == true && validateUser == true)
                        {
                            Console.WriteLine("User created");
                            fileHandler.WriteToFile(username, password);
                        }
                        else
                        {
                            Console.WriteLine("Do you wish to re-enter user details ?" +
                                "\n Press Y to re-enter user details or  any key to exit");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {
                                goto addNewUser;
                            }
                            Console.WriteLine("Closing program...");
                            Thread.Sleep(500);
                            Environment.Exit(0);
                        }

                        } while (!methods.IsValidUser(userDetails.UserName) || !methods.IsValidPassword(userDetails.Password));
                    Console.WriteLine();
                    Console.WriteLine("Users created successfully");
                    Console.WriteLine();
                    tries = 0;
                    goto start;
                    

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        goto start;
    }

}

  


    








using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftUptitudeTest.HelperMethods
{
    public  class Methods
    {
        public  bool IsValidUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
            {
                Console.WriteLine("Invalid username. Please enter a username with a lenght of 4 or more characters");
                return false;
            }
            return true;
        }

        public  bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6 || password.Length > 8 
                || !password.Any(char.IsUpper) || !password.Any(char.IsDigit) ||!password.Any(char.IsLetterOrDigit))
            {
                Console.WriteLine("Invalid password");
                return false;
            }
            return true;
        }

        public  Collection GetCollectionIfo()
        {
            try
            {
                Collection collectionDetails = new Collection();
                Console.WriteLine("______________________________");
                Console.WriteLine("Collection Information");
                Console.WriteLine("______________________________");
                Console.WriteLine();
                Console.Write("Enter the house number :");
                collectionDetails.HouseNo = Console.ReadLine();

                Console.Write("Enter the AdressLine 1 :");
                collectionDetails.Address1 = Console.ReadLine();

                Console.Write("Enter the AddressLine 2 :");
                collectionDetails.Address2 = Console.ReadLine();

                Console.Write("Enter Collection date :");
                collectionDetails.CollectionDate = Console.ReadLine();

                Console.Write("Enter collection contact person name :");
                collectionDetails.CollectionContactName = Console.ReadLine();

                Console.Write("Enter collection contact number :");
                collectionDetails.CollectionContactNumber = Console.ReadLine();

                return collectionDetails;
            }
            catch (Exception ex)
            {
               throw new Exception($"Error occured in GetCollectionInfo method :{ex.Message}");
            }

        }

        public Delivery GetDeliveryInfo()
        {
            try
            {
                Console.WriteLine();
                Delivery deliveryDetails = new Delivery();
                Console.WriteLine("______________________________");

                Console.WriteLine("Delivery Instructions");
                Console.WriteLine("______________________________");
                Console.WriteLine();
                Console.Write("Enter house number :");
                deliveryDetails.HouseNo = Console.ReadLine();

                Console.Write("Enter the AdressLine 1 :");
                deliveryDetails.Address1 = Console.ReadLine();

                Console.Write("Enter the AddressLine 2 :");
                deliveryDetails.Address2 = Console.ReadLine();

                Console.Write("Enter Collection date :");
                deliveryDetails.DeliveryDate = Console.ReadLine();

                Console.Write("Enter collection contact person name :");
                deliveryDetails.DeliveryContactName = Console.ReadLine();

                Console.Write("Enter collection contact number :");
                deliveryDetails.DeliveryContactNumber = Console.ReadLine();

                return deliveryDetails;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured in GetDeliveryInfo method :{ex.Message}");
            }
        }
        public ParcelInfo GetParcel()
        {
            try
            {
                ParcelInfo parcelInfor = new ParcelInfo();

                Console.WriteLine();
                Console.WriteLine("______________________________");
                Console.WriteLine("Parcel Information");
                Console.WriteLine("______________________________");
                Console.WriteLine();

                Console.Write(" Enter parcel weight :");
                parcelInfor.Weight = double.Parse(Console.ReadLine());
                Console.Write("Enter parcel lenght :");
                parcelInfor.Length = double.Parse(Console.ReadLine());

                Console.Write("Enter parcel width :");
                parcelInfor.Width = double.Parse(Console.ReadLine());

                Console.Write("Enter parcel height :");
                parcelInfor.Height = double.Parse(Console.ReadLine());
                Console.Write("Enter any special instructions :");
                parcelInfor.SpecialInstructions = Console.ReadLine();

                parcelInfor.VolumetricMass = (parcelInfor.Weight * parcelInfor.Length * parcelInfor.Width) / 4000;
                Console.WriteLine();
                Console.WriteLine( $"The parcel's volumetric mass is : {parcelInfor.VolumetricMass}");
            
                return parcelInfor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured in GetParcel method :{ex.Message}");
            }

        } 

        public string GetServiceSummary()
        {
            try
            {

                Console.WriteLine();
                Console.WriteLine("Please choose a service summary from the following options  " +
                    "\n 1. Same day delivery R500" +
                    "\n 2 Overnight R250" +
                    "\n Economy R125");
                Console.WriteLine();

                int opt = int.Parse(Console.ReadLine());
                string serviceSummaryOpt = string.Empty;
                switch (opt)
                {
                    case 1:
                        serviceSummaryOpt = "Same-Day Delivery R500";
                        break;
                    case 2:
                        serviceSummaryOpt = "Overnight  R250";
                        break;
                    case 3:
                        serviceSummaryOpt = "Economy R125";
                        break;
                    default:
                        Console.WriteLine("Invalid option for service summary");
                        break;
                }
                return serviceSummaryOpt;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured in GetSummaryService method :{ex.Message}");
            }
        }

        public void  CheckOut(Collection collectionDetails,Delivery deliveryDetails,ParcelInfo parcelInfo,string ServiceSummaryOpt)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("========================================================");
            Console.WriteLine("Checkout page");
            Console.WriteLine("========================================================");
            Console.ResetColor();

           

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("========================================================");
            Console.WriteLine("Collection Information");
            Console.WriteLine("========================================================");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine($"House No : {collectionDetails.HouseNo}");
            Console.WriteLine($"Address 1 : {collectionDetails.Address1}");
            Console.WriteLine($"Address 2 : {collectionDetails.Address2}");
            Console.WriteLine($"Collection date : {collectionDetails.CollectionDate}");
            Console.WriteLine($"Collection contact name : {collectionDetails.CollectionContactName}");
            Console.WriteLine($"Collection contact number : {collectionDetails.CollectionContactNumber}");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("========================================================");
            Console.WriteLine("Delivery Information");
            Console.WriteLine("========================================================");
            Console.ResetColor();

            Console.WriteLine($"House No : {deliveryDetails.HouseNo}");
            Console.WriteLine($"Address 1 : {deliveryDetails.Address1}");
            Console.WriteLine($"Address 2 : {deliveryDetails.Address2}");
            Console.WriteLine($"Collection date : {deliveryDetails.DeliveryDate}");
            Console.WriteLine($"Collection contact name : {deliveryDetails.DeliveryContactName}");
            Console.WriteLine($"Collection contact number : {deliveryDetails.DeliveryContactNumber}");
            
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("========================================================");
            Console.WriteLine("Parcel Information");
            Console.WriteLine("========================================================");
            Console.WriteLine();
            Console.ResetColor();


            Console.WriteLine($"Weight : {parcelInfo.Weight}");
            Console.WriteLine($"Length : {parcelInfo.Length}");
            Console.WriteLine($"Width : {parcelInfo.Width}");
            Console.WriteLine($"Height : {parcelInfo.Height}");
            Console.WriteLine($"Volumetric mass : {parcelInfo.VolumetricMass}");
            Console.WriteLine($"Special Instructions : {parcelInfo.SpecialInstructions}");

      
            Console.WriteLine ($"Service choosen : {ServiceSummaryOpt}");
            Console.WriteLine("========================================================");

        }

    }
}

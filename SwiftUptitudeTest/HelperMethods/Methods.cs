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
                || !password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            {
                Console.WriteLine("Invalid password");
                return false;
            }
            return true;
        }

        public  List<Collection> GetCollectionIfo()
        {
            Collection collectionDetails = new Collection();

            Console.WriteLine("Collection Information");
            Console.Write("Enter the stret no :");
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

            List<Collection> collectionList = new List<Collection>();
            collectionList.Add(collectionDetails);

            return collectionList;

        }

        public List<Delivery> GetDeliveryInfo()
        {
            Delivery deliveryDetails = new Delivery();
            List<Delivery> deliveryList = new List<Delivery>();
            Console.WriteLine("Delivery Instructions");
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

            List<Collection> collectionList = new List<Collection>();

            deliveryList.Add(deliveryDetails);


            return deliveryList;
        }
        public List<ParcelInfo> GetParcel()
        {
            Console.WriteLine("Parcel Information");
            List<ParcelInfo> parcelInfoList = new List<ParcelInfo>();
            ParcelInfo parcelInfor = new ParcelInfo();

            Console.Write(" Enter parcel weight :");
            parcelInfor.Weight = double.Parse(Console.ReadLine());
            Console.Write("Enter parcel lenght");
            parcelInfor.Length = double.Parse(Console.ReadLine());

            Console.Write("Enter parcel width");
            parcelInfor.Width = double.Parse(Console.ReadLine());

            Console.Write("Enter parcel height");
            parcelInfor.Height = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter any special instructions");
            parcelInfor.SpecialInstructions = Console.ReadLine();

            parcelInfor.VolumetricMass = (parcelInfor.Weight * parcelInfor.Length * parcelInfor.Width) / 4000;
            Console.WriteLine( $"The parcel's volumetric mass is : {parcelInfor.VolumetricMass}");

            parcelInfoList.Add(parcelInfor);
            return parcelInfoList;

        } 

        public string ServiceSummary()
        {
            Console.WriteLine("Please choose a service summary from the following options  " +
                "\n 1. Same day delivery R500" +
                "\n 2 Overnight R250" +
                "\n Economy R125");
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

        public void  CheckOut(List<Collection> collectionList,List<Delivery> deliveryList,List<ParcelInfo>parcelInfo,string ServiceSummaryOpt)
        {
            Console.WriteLine("========================================================");

            Console.WriteLine("Checkout page");
            Console.WriteLine("========================================================");
            Console.WriteLine("");
            Console.WriteLine("Collection Information");
            Console.WriteLine("========================================================");
            foreach (var item in collectionList)
            {
                Console.Write($"House No : {item.HouseNo}");
                Console.Write($"Address 1 : {item.Address1}");
                Console.Write($"Address 2 : {item.Address2}");
                Console.Write($"Collection date : {item.CollectionDate}");
                Console.Write($"Collection contact name : {item.CollectionContactName}");
                Console.Write($"Collection contact number : {item.CollectionContactNumber}");

            }
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine("Delivery Information");
            Console.WriteLine("========================================================");

            foreach (var item in deliveryList)
            {
                Console.Write($"House No : {item.HouseNo}");
                Console.Write($"Address 1 : {item.Address1}");
                Console.Write($"Address 2 : {item.Address2}");
                Console.Write($"Collection date : {item.DeliveryDate}");
                Console.Write($"Collection contact name : {item.DeliveryContactName}");
                Console.Write($"Collection contact number : {item.DeliveryContactNumber}");
            }
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine("Parcel Information");
            Console.WriteLine("========================================================");

            foreach (var item in parcelInfo)
            {
                Console.Write($"Weight : {item.Weight}");
                Console.Write($"Length : {item.Length}");
                Console.Write($"Width : {item.Width}");
                Console.Write($"Height : {item.Height}");
                Console.Write($"Volumetric mass : {item.VolumetricMass}");
                Console.WriteLine($"Special Instructions : {item.SpecialInstructions}");

            }
            Console.Write ($"Service choosen : {ServiceSummaryOpt}");

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RandREng.IdentityDBEntity;
using RandREng.MeasureDBEntity;

namespace Helper
{
	class Program
	{
		static void Main(string[] args)
		{
//            PopulateBranches("MeasureLocal");
            PopulateUsers("IdentityLocal");

//            PopulateBranches("MeasureLive");
            PopulateUsers("IdentityLive");

 //           PopulateBranches("MeasureAzure");
            PopulateUsers("IdentityAzure");

//            PopulateLowesStores("MeasureLocal");
//            PopulateLowesStores("MeasureAzure");
            PopulateLowesStores("MeasureLive");

            CustomerLoad("MeasureLocal");
            CustomerLoad("MeasureLive");
            CustomerLoad("MeasureAzure");
		}


		public class lll
		{
			[JsonProperty("Location")]
			public Store[] Location;
		}


		public class Store
		{
			public short DIST;
			public string DIR;
			public string KEY;
			public string STORENAME;
			public string NAME;
			public string ADDR;
			public string ADDRESS;
			public string CITY;
			public string CITYFORMATTED;
			public string STATE;
			public string ZIP;
			public string PHONE;
			public string COMMFAX;
			public string HOURS;
			public string DIREC;
			public string LOGO;
			public string CONS;
			public string COUNTRY;
			public string LLAT;
			public string LLON;
			[JsonProperty("StoreHours")]
			Hours StoreHours;
			public string OFFSET;
			public string showProductAisleNumber;
			public string showProductBayNumber;
			public string showMetaProducts;
			public string showStoreMapView;
			public string showInStockPageView;
			public string showProductLocations;
		}

		public class Hours
		{
			public string Monday_Open;
			public string Monday_Close;
			public string Tuesday_Open;
			public string Tuesday_Close;
			public string Wednesday_Open;
			public string Wednesday_Close;
			public string Thursday_Open;
			public string Thursday_Close;
			public string Friday_Open;
			public string Friday_Close;
			public string Saturday_Open;
			public string Saturday_Close;
			public string Sunday_Open;
			public string Sunday_Close;
		}

		static void CustomerLoad(string connection)
		{
            System.Console.WriteLine("CustomerLoad {0}", connection);
            RandREng.MeasureDBEntity.MeasureEntities conn = new RandREng.MeasureDBEntity.MeasureEntities(connection);
			AspNetUser user = conn.AspNetUsers.FirstOrDefault(u => u.UserName.StartsWith("employee"));
			if (user != null)
            {
                int count = conn.Customers.Count();
                DateTime start = DateTime.Now;
                for (int i = count; i < 1000000; i++)
                {
                    Customer c = new Customer();
                    c.LastModifiedById = user.Id;
                    c.LastModifiedDateTime = DateTime.Now;
                    c.LastName = string.Format("Last{0}", i);
                    c.FirstName = string.Format("First{0}", i);
                    c.Address = string.Format("{0} Nowhere Lane", i);
                    c.City = "Im Lost";
                    c.State = "GA";
                    c.ZipCode = "12345";
                    c.EmailAddress = "foo@bar.com";
                    conn.Customers.Add(c);
                    if (((i + 1) % 1000) == 0)
                    {
                        DateTime end = DateTime.Now;

                        System.Console.WriteLine(string.Format("{0} - {1}", (end - start).ToString(), i));
                        start = end;
                        try
                        {
                            int a = conn.SaveChanges();

                            conn.Dispose();
                            conn = new RandREng.MeasureDBEntity.MeasureEntities(connection);
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException e)
                        {
                        }
                    }
                }
			}
			conn.SaveChanges();
            conn.Dispose();
		}

        static void PopulateUsers(string connection)
        {
            System.Console.WriteLine("PopulateUsers {0}", connection);
            PopulateAdmins(connection);
            PopulateStoreUser(connection);
            PopulateTechUser(connection);
            PopulateEmployeesUser(connection);

        }
        static void PopulateAdmins(string connection)
        {
            IdentityResult roleResult;
            ApplicationDbContext context = new ApplicationDbContext(connection);
            roleResult = context.CreateUser(new ApplicationUser() { UserName = "admin@custom-installs.com", IsConfirmed = true, Active = true }, "cfi12345", "Admin");
            roleResult = context.CreateUser(new ApplicationUser() { UserName = "admin", IsConfirmed = true, Active = true }, "cfi12345", "Admin");
        }

        static void PopulateStoreUser(string connection)
        {
            IdentityResult roleResult;
            ApplicationDbContext context = new ApplicationDbContext(connection);

            roleResult = context.CreateUser(new ApplicationUser() { UserName = "store@custom-installs.com", IsConfirmed = true, Active = true }, "cfi12345", "Store");
        }

        static void PopulateTechUser(string connection)
        {
            IdentityResult roleResult;
            ApplicationDbContext context = new ApplicationDbContext(connection);

            roleResult = context.CreateUser(new ApplicationUser() { UserName = "tech@custom-installs.com", IsConfirmed = true, Active = true }, "cfi12345", "Tech");
        }

        static void PopulateEmployeesUser(string connection)
        {
            IdentityResult roleResult;
            ApplicationDbContext context = new ApplicationDbContext(connection);

            roleResult = context.CreateUser(new ApplicationUser() { UserName = "employee@custom-installs.com", IsConfirmed = true, Active = true }, "cfi12345", "Employee");
        }

        static void PopulateBranches(string connection)
        {
            System.Console.WriteLine("PoulateBranches {0}", connection);
            RandREng.MeasureDBEntity.MeasureEntities conn = new RandREng.MeasureDBEntity.MeasureEntities(connection);

            Branch branch = conn.Branches.FirstOrDefault(b => b.Name == "Atlanta");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Atlanta";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "GA";
                branch.City = "Norcross";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }

            branch = conn.Branches.FirstOrDefault(b => b.Name == "Greenville");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Greenville";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "SC";
                branch.City = "Greenville";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }
            branch = conn.Branches.FirstOrDefault(b => b.Name == "Coastal");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Coastal";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "SC";
                branch.City = "Myrtle Beach";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }
            branch = conn.Branches.FirstOrDefault(b => b.Name == "Fayetteville");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Fayetteville";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "NC";
                branch.City = "Fayetteville";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }
            branch = conn.Branches.FirstOrDefault(b => b.Name == "Columbia");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Columbia";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "SC";
                branch.City = "Columbia";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }
            branch = conn.Branches.FirstOrDefault(b => b.Name == "Tampa");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Tampa";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "fl";
                branch.City = "Tampa";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }
            branch = conn.Branches.FirstOrDefault(b => b.Name == "Orlando");
            if (branch == null)
            {
                branch = new Branch();
                branch.Active = true;
                branch.Name = "Orlando";
                branch.Address = "4291 Communications Dr."; ;
                branch.State = "FL";
                branch.City = "Orlando";
                branch.ZipCode = "30093";
                conn.Branches.Add(branch);
            }


            conn.SaveChanges();
        }        
        
        static void PopulateLowesStores(string connection)
		{
            System.Console.WriteLine("PopulateLowesStores {0}", connection);
            RandREng.MeasureDBEntity.MeasureEntities conn = new RandREng.MeasureDBEntity.MeasureEntities(connection);

			StoreType type = conn.StoreTypes.FirstOrDefault(st => st.Name == "LOWES");
			if (type == null)
			{
				type = new StoreType();
				type.Name = "LOWES";
				conn.StoreTypes.Add(type);
				conn.SaveChanges();
			}
            Branch branch = conn.Branches.FirstOrDefault(st => st.Name == "Atlanta");

			Dictionary<string, Store> Stores = new Dictionary<string, Store>();
			for (decimal lat = 27.0m; lat < 38.5m; lat += .5m)
			{
				for (decimal llong = -76.0m; llong > -88.4m; llong -= .5m)
				{
					string dest = string.Format("http://www.lowes.com/IntegrationServices/resources/storeLocator/json/v2_0/stores?langId=-1&storeId=10702&catalogId=10051&place={0},{1}&count=100", lat, llong);
					HttpWebRequest req = (HttpWebRequest)WebRequest.Create(dest);
					req.Accept = "application/json, text/javascript, */*; q=0.01";
					req.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";
					req.Referer = "http://www.lowes.com/StoreLocatorDisplayView?storeId=10151&langId=-1&catalogId=10051";
					req.AutomaticDecompression = DecompressionMethods.GZip;
					req.Headers.Add("Accept-Language", "en-USen;q=0.8");

					req.Timeout = 600000;

					HttpWebResponse webResponse = (HttpWebResponse)req.GetResponse();
					Stream responseStream = webResponse.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream);
					string responseString = "";
					responseString = streamReader.ReadToEnd();

					lll stuff = JsonConvert.DeserializeObject<lll>(responseString);

					foreach (Store store in stuff.Location)
					{
						if (!Stores.Keys.Contains(store.KEY))
						{
							RandREng.MeasureDBEntity.Store client = (from c in conn.Stores where c.Number == store.KEY select c).FirstOrDefault();

							if (client == null)
							{

								Stores.Add(store.KEY, store);
								System.Console.WriteLine("Adding store " + store.KEY);
								client = new RandREng.MeasureDBEntity.Store();
								client.Address = store.ADDR;
								client.Active = true;
								client.BranchId = branch.Id;
								client.City = store.CITY;
								client.TypeID = 1;
								client.FaxNumber = store.COMMFAX;
								client.Latitude = double.Parse(store.LLAT);
								client.Longitude = double.Parse(store.LLON);
								client.NickName = store.NAME;
								client.State = store.STATE;
								client.Number = store.KEY;
								client.StorePhoneNumber = store.PHONE;
								client.DistrictNumber = store.DIST;
								client.ZipCode = store.ZIP;
								conn.Stores.Add(client);
							}
							else
							{
								client.Address = store.ADDR;
							}
						}
					}
					conn.SaveChanges();
				}
			}


		}

	}

}

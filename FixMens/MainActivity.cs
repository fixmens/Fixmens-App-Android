﻿using Android.App;
using Android.Widget;
using Android.OS;
using System.Net;
using System.IO;
using System;
using System.Json;
using System.Threading.Tasks;
using FixMens.Models;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
using FixMens.Services;

namespace FixMens
{


    [Activity(Theme = "@android:style/Theme.Holo.Light", Label = "FixMens", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
		public static MobileServiceClient MobileService =
				new MobileServiceClient(
				"https://fixmensappbackend.azurewebsites.net"
			);

		public class TodoItem
		{
			public string Id { get; set; }
			public string Text { get; set; }
		}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //CurrentPlatform.Init();
            base.OnCreate(savedInstanceState);



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            MyTransactions.ReplaceFragment(this, Resource.Id.fragment_container, new MenuFragment());
			
            Button order = FindViewById<Button>(Resource.Id.BtnByOrder);
            Button name = FindViewById<Button>(Resource.Id.BtnByName);
            Button device = FindViewById<Button>(Resource.Id.BtnByDevice);

			// When the user clicks the button ...
			order.Click +=  (sender, e) =>
			{
				var intent = new Intent(this, typeof());
				intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
				StartActivity(intent);
                Console.Write("hola");


			};

			/*
            // Get the latitude/longitude EditBox and button resources:
            EditText orden = FindViewById<EditText>(Resource.Id.TxtOrder);
            EditText infoOrden = FindViewById<EditText>(Resource.Id.txtInfoOrden);
            Button button = FindViewById<Button>(Resource.Id.BtnConsultarOrden);

            // When the user clicks the button ...
            button.Click += async (sender, e) =>
            {

                // Get the latitude and longitude entered by the user and create a query.
                try
                {
					//CurrentPlatform.Init();
					TodoItem item = new TodoItem { Text = "Awesome item" };
					await MobileService.GetTable<TodoItem>().InsertAsync(item);
                    var rxcui = orden.Text;
                    var url = string.Format(@"http://fixmensintegration.azurewebsites.net/api/reparaciones/{0}", rxcui);
                    // Fetch the weather information asynchronously, 
                    // parse the results, then update the screen:
                    //JsonValue json = await ConsultarOrden(url);
                    // ParseAndDisplay (json);


                    var request = HttpWebRequest.Create(string.Format(@"http://fixmensintegration.azurewebsites.net/api/reparaciones/{0}", rxcui));
                    request.ContentType = "application/json";
                    request.Method = "GET";
                    // Send the request to the server and wait for the response:
                    using (WebResponse response = await request.GetResponseAsync())
                    {
                        // Get a stream representation of the HTTP web response:
                        using (Stream stream = response.GetResponseStream())
                        {
                            // Use this stream to build a JSON document object:
                            JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                            Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                            var modelResponse = JsonConvert.DeserializeObject<ReparacionViewModel>(jsonDoc.ToString());

                            infoOrden.Text = jsonDoc.ToString();
                            // Return the JSON document:

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine("Response: {0}", ex.Message);
                }


            };
            */
		}

        //private async Task<JsonValue> ConsultarOrden(string url){


        //}


    }


}


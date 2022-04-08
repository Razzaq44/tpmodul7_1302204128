using System;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TP7
{
	public class CovidConfig
	{
		public string satuan_suhu { get; set; }
		public string batas_hari_deman { get; set; }
		public string pesan_ditolak { get; set; }
		public string pesan_diterima { get; set; }
		public static void UbahSatuan()
        {
			string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
			string pathAndFile = path + "/covid_config.json";
			string json = File.ReadAllText(pathAndFile);

			var baca = System.Text.Json.JsonSerializer.Deserialize<CovidConfig>(json);

			if (baca.satuan_suhu == "celcius")
            {
				JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json) as JObject;
				JToken jToken = jObject.SelectToken("satuan_suhu");
				jToken.Replace("fahrenheit");
				string updatedJsonString = jObject.ToString();
				File.WriteAllText(pathAndFile, updatedJsonString);
			} 
			else if (baca.satuan_suhu == "fahrenheit")
            {
				JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json) as JObject;
				JToken jToken = jObject.SelectToken("satuan_suhu");
				jToken.Replace("celcius");
				string updatedJsonString = jObject.ToString();
				File.WriteAllText(pathAndFile, updatedJsonString);
			}
            else
            {
				JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json) as JObject;
				JToken jToken = jObject.SelectToken("satuan_suhu");
				jToken.Replace("celcius");
				string updatedJsonString = jObject.ToString();
				File.WriteAllText(pathAndFile, updatedJsonString);
			}			
		}

		public static void setDefault()
        {
			string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
			string pathAndFile = path + "/covid_config.json";
			string json = File.ReadAllText(pathAndFile);

			JObject jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json) as JObject;
			JToken jToken = jObject.SelectToken("satuan_suhu");
			jToken.Replace("celcius");
			string updatedJsonString = jObject.ToString();
			File.WriteAllText(pathAndFile, updatedJsonString);
		}
		
		public CovidConfig() { }
	}
}


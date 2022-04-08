using System;
using System.Text.Json;
using System.IO;

namespace TP7
{
    public class program
    {
        public static void Main(string[] args)
        {
            CovidConfig.setDefault();
            string input = "Y";
            while (input != "N")
            {
                CovidConfig objHasilBaca = ReadJSON();

                Console.WriteLine("Berapa suhu badan anda saat ini ? Dalam nilai " + objHasilBaca.satuan_suhu + " ");
                double suhu = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
                int hari = Convert.ToInt32(Console.ReadLine());

                if (objHasilBaca.satuan_suhu == "celcius" && suhu >= 36.5 && suhu <= 37.5 && hari < Convert.ToInt32(objHasilBaca.batas_hari_deman))
                {
                    Console.WriteLine();
                    Console.WriteLine(objHasilBaca.pesan_diterima);
                }
                else if (objHasilBaca.satuan_suhu == "fahrenheit" && suhu < 97.7 && suhu > 99.5)
                {
                    Console.WriteLine();
                    Console.WriteLine(objHasilBaca.pesan_diterima);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(objHasilBaca.pesan_ditolak);
                    Console.WriteLine();
                }

                
                Console.WriteLine();
                Console.WriteLine("Ubah Satuan Suhu? (Y/N)");
                
                input = Console.ReadLine();
                if (input == "Y")
                {
                    CovidConfig.UbahSatuan();
                    Console.WriteLine();
                }
                else if (input != "Y" || input != "N")
                {
                    Console.WriteLine("Inputan salah!");
                    break;
                }
                else
                {
                    break;
                }
            }             
        }
        public static CovidConfig ReadJSON()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string pathAndFile = path + "/covid_config.json";
            string json = File.ReadAllText(pathAndFile);

            CovidConfig config = JsonSerializer.Deserialize<CovidConfig>(json);

            return config;
        }
    }
}



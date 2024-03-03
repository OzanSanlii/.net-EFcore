using System;
using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld

{

    internal class Program
    {
        static void Main(string[] args)
        {
            DataContextEF entityFramework = new DataContextEF();
            DataContextDapper dapper = new DataContextDapper();
            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            //Console.WriteLine(rightNow);


            Computer myComputer = new Computer()
            {
                Motherboard = "2691",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943,
                VideoCard = "RTX 2070"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard, 
            //     HasWifi, 
            //     HasLTE ,
            //     ReleaseDate, 
            //     Price, 
            //     VideoCard  
            // ) VALUES ('" + myComputer.Motherboard
            //     + "','" + myComputer.HasWifi
            //     + "','" + myComputer.HasLTE
            //     + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //     + "','" + myComputer.Price.ToString()
            //     + "','" + myComputer.VideoCard
            // + "')";

            // Console.WriteLine(sql);

            // bool result = dapper.ExecuteSql(sql);

            // Console.WriteLine(result);

            // string sqlSelect = @"
            // SELECT 
            //     Computer.Motherboard, 
            //     Computer.HasWifi, 
            //     Computer.HasLTE ,
            //     Computer.ReleaseDate, 
            //     Computer.Price, 
            //     Computer.VideoCard
            // FROM TutorialAppSchema.Computer";

            // IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);


            // foreach (Computer singleComputer in computers)
            // {
            //     Console.WriteLine("'" + singleComputer.Motherboard
            //     + "','" + singleComputer.HasWifi
            //     + "','" + singleComputer.HasLTE
            //     + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //     + "','" + singleComputer.Price.ToString()
            //     + "','" + singleComputer.VideoCard
            // + "'");

            // }

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();

            if (computersEf != null)
            {

                foreach (Computer singleComputer in computersEf)
                {
                    Console.WriteLine("'" + singleComputer.ComputerID
                    + "','" + singleComputer.Motherboard
                    + "','" + singleComputer.HasWifi
                    + "','" + singleComputer.HasLTE
                    + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + singleComputer.Price.ToString()
                    + "','" + singleComputer.VideoCard
                + "'");
                }

            }

        }
    }
}
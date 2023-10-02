using FilleTransferSystem.BusinessLogic;
using FilleTransferSystem.Models;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FilleTransferSystem
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var getFileProcess = new GetFilesProcess();
      var csv = new StringBuilder();
      var input = new InputModel()
       {
         FileInputDirectory = "C:\\Users\\Microsoft\\Hololens\\FileTransferSystem\\Input",
         FileOutputDirectory = "C:\\Users\\Microsoft\\Hololens\\FileTransferSystem\\Output",
         isProcessSubCategories = true
       };

     
      var files = getFileProcess.GetFilePathsInDirectory(input);
      if (files is not null)
      {
        foreach (var item in files)
        {

          var filePath = getFileProcess.VerifyFileExtension(item);
          if (filePath.Equals("jpg") || filePath.Equals("pdf"))
          {
            var MD5 = getFileProcess.GetMD5HashFromFile(item);
            var newLine = $"{item},{filePath},{MD5}";
            csv.AppendLine(newLine);


          }
          else
          {
            Console.WriteLine($"The File in path {item}, is not to be processed");
          }

        }
        File.WriteAllText("C:\\Users\\Microsoft\\Hololens\\FileTransferSystem\\CSV", csv.ToString());
      }
      else
      {
        Console.WriteLine("We could not find any files");
      }


    }


   
  }
}
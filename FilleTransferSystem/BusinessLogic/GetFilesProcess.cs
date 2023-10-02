using FilleTransferSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FilleTransferSystem.BusinessLogic
{
  internal class GetFilesProcess
  {

    public List<string> GetFilePathsInDirectory(InputModel input)
    {

	 var files = new List<string>();
	 try
	 {
	   if (input.isProcessSubCategories)
	   {
		files = Directory.GetFiles(input.FileInputDirectory, "*", SearchOption.AllDirectories).ToList();

	   }
	   else
	   {
		files = Directory.GetFiles(input.FileInputDirectory, "*", SearchOption.TopDirectoryOnly).ToList();
	   }
	 }
	 catch (Exception ex)
	 {

	   //Add Error Logs
	 }

	 return files;

    }


    public string VerifyFileExtension(string filePath)
    {
	 var extension  = Path.GetExtension(filePath);
	 if (extension.ToLower() == ".jpg")
	 {
	   if (HasJpgExtension(filePath) && HasJpgHeader(filePath))
	   {
		return "jpg";
	   }
	   
	 }
	 else if (extension.ToLower() == ".pdf")
	 {
        if (HasPDFExtension(filePath) && HasPDFHeader(filePath))
        {
          return "pdf";
        }
      }
      return "failed";
    }



    static bool HasJpgExtension(string filePath)
    {
	 // add other possible extensions here
	 return Path.GetExtension(filePath).Equals(".jpg", StringComparison.InvariantCultureIgnoreCase);
         
    }

    static bool HasJpgHeader(string filePath)
    {
	
      string arrayString = string.Join(" ", File.ReadAllBytes(filePath).Select(b => b.ToString("X2")).ToArray());
      if (arrayString.StartsWith(Constants.JPGSignature)) //Checking against the signatures list
      {
	   return true;
      }
	 return false;
    }


    static bool HasPDFExtension(string filePath)
    {
      // add other possible extensions here
      return Path.GetExtension(filePath).Equals(".pdf", StringComparison.InvariantCultureIgnoreCase);

    }

    static bool HasPDFHeader(string filePath)
    {
      string arrayString = string.Join(" ", File.ReadAllBytes(filePath).Select(b => b.ToString("X2")).ToArray());
      if (arrayString.StartsWith(Constants.PDFSignature)) //Checking against the signatures list
      {
        return true;
      }
      return false;
    }

   internal string GetMD5HashFromFile(string filePath)
    {
      FileStream file = new FileStream(filePath, FileMode.Open);
      MD5 md5 = new MD5CryptoServiceProvider();
      byte[] retVal = md5.ComputeHash(file);
      file.Close();

      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < retVal.Length; i++)
      {
        sb.Append(retVal[i].ToString("x2"));
      }
      return sb.ToString();
    }

  }
}

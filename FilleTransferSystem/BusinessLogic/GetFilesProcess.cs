using FilleTransferSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilleTransferSystem.BusinessLogic
{
  internal class GetFilesProcess
  {

    public List<string> GetAllFilesInDirectory(InputModel input)
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


  }
}

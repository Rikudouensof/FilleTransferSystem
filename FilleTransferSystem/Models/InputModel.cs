using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilleTransferSystem.Models
{
  internal class InputModel
  {
    [Required]
    public string FileInputDirectory { get; set; }


    [Required]
    public string FileOutputDirectory { get; set; }


    [Required]
    public bool isProcessSubCategories { get; set; }
  }
}

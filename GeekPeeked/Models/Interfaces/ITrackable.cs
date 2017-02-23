using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public interface ITrackable
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }

        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}

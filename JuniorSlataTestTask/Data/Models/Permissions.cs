using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JuniorSlataTestTask.Data.Models
{
    public enum Permissions
    {
        Administrator = 0,
        User = 1,
        HRManager = 2,
        Mentor = 3
    }
}
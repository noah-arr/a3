using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Data.Models;

public class Member
{
    public int MemberID { get; set; }
    [Required, StringLength(30)]  public string Username { get; set; }
    [Required] public string PasswordHash { get; set; }
    public bool isLocked { get; set; }    
}

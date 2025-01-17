using System;
using System.Collections.Generic;

namespace Libreria_Online.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserLastname { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserRol { get; set; } = null!;

    public DateTime? UserCreationDate { get; set; }
}

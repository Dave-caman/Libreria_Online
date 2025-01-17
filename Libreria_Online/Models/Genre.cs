using System;
using System.Collections.Generic;

namespace Libreria_Online.Models;

public partial class Genre
{
    public int GenresId { get; set; }

    public string GenresName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

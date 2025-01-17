using System;
using System.Collections.Generic;

namespace Libreria_Online.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookAuthor { get; set; } = null!;

    public string? BookDescription { get; set; }

    public int BookGenreId { get; set; }

    public string BookImageCover { get; set; } = null!;

    public string BookDigitalPath { get; set; } = null!;

    public virtual Genre BookGenre { get; set; } = null!;
}

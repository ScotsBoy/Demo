using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RecordStore.Models;

public partial class Artist
{
    [DisplayName("Artist")]
    public int ArtistId { get; set; }

    public string Name { get; set; } = null!;
    [DisplayName("Category")]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();
}

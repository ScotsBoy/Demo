using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RecordStore.Models;

public partial class Release
{
    public int ReleaseId { get; set; }

    [DisplayName("Artist")]
    public int ArtistId { get; set; }

    public string Name { get; set; } = null!;

    [DisplayName("Release Type")]
    public int ReleaseTypeId { get; set; }
    [DisplayName("Medium")]
    public int MediumId { get; set; }

    public string Runtime { get; set; } = null!;
    [DisplayName("Release Date")]
    public DateOnly ReleaseDate { get; set; }

    public virtual Artist Artist { get; set; } = null!;

    public virtual Medium Medium { get; set; } = null!;

    public virtual ReleaseType ReleaseType { get; set; } = null!;
}

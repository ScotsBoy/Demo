using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RecordStore.Models;

public partial class ReleaseType
{
    [DisplayName("Release Type")]
    public int ReleaseTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Release> Releases { get; set; } = new List<Release>();
}

using System;
using System.Collections.Generic;

namespace GDE.PlgxReader.Models
{
    public class PlgxInfo
    {
        public PlgxInfoMetadata InfoMetadata { get; set; } = new PlgxInfoMetadata();

        public byte[] Uuid { get; set; }

        public string BaseFileName { get; set; }

        public DateTime? CreationTime { get; set; }

        public PlgxGenerator Generator { get; set; } = new PlgxGenerator();

        public PlgxRequirements Requirements { get; set; } = new PlgxRequirements();

        public string PreBuildCommand { get; set; }

        public string PostBuildCommand { get; set; }

        public List<PlgxEmbeddedFile> Files { get; set; } = new List<PlgxEmbeddedFile>();
    }
}

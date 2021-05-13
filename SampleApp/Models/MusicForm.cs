using System;
using System.Collections.Generic;

namespace SampleApp.Models
{
    public class MusicForm
    {
        public string Title { get; set; }
        public IList<Field> Fields { get; set; }
    }

    public class Field
    {
        public string Label { get; set; }
        public string Type { get; set; }
        public List<string> DropdownValues { get; set; }
        public string Value { get; set; }
    }
}

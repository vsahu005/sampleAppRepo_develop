using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NetworkAccessLayer.DataObjects
{
    [DataContract]
    public class MusicForm
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "fields")]
        public List<Field> Fields { get; set; }
    }

    [DataContract]
    public class Field
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "dropdownValues")]
        public List<string> DropdownValues { get; set; }
    }
}

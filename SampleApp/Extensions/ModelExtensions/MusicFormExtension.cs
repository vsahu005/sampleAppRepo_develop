using System;
using System.Collections.Generic;
using SampleApp.Models;

namespace SampleApp.Extensions.ModelExtensions
{
    public static class MusicFormExtension
    {
        public static MusicForm ApiObjectToModel(this NetworkAccessLayer.DataObjects.MusicForm apiMusicForm)
        {
            if (apiMusicForm is null)
            {
                return default;
            }

            MusicForm musicFormModel = new MusicForm();
            List<Field> fields = new List<Field>();
            apiMusicForm.Fields.ForEach(field =>
            fields.Add(new Field
            {
                Label = field.Label,
                Type = field.Type,
                DropdownValues = field.DropdownValues
            }));
            musicFormModel.Title = apiMusicForm.Title;
            musicFormModel.Fields = fields;
            return musicFormModel;
        }
    }
}

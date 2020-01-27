using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WarThunderComparer.comparerData.Collections
{
    class Language
    {
        public int Image { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class LanguageCollection
    {
        public static List<Language> GetLanguages()
        {
            Context context = Application.Context;

            List<Language> languages = new List<Language>();
            Language language = null;

            language = new Language();
            language.Id = 1;
            language.Name = "English";
            language.Image = Resource.Drawable._flagUSEN;
            languages.Add(language);

            language = new Language();
            language.Id = 2;
            language.Name = "Français";
            language.Image = Resource.Drawable._flagTheBestFrance;
            languages.Add(language);

            language = new Language();
            language.Id = 3;
            language.Name = "Deutsch";
            language.Image = Resource.Drawable._flagTheBestFRG;
            languages.Add(language);

            language = new Language();
            language.Id = 4;
            language.Name = "Italiano";
            language.Image = Resource.Drawable._flagTheBestItalyNew;
            languages.Add(language);

            language = new Language();
            language.Id = 5;
            language.Name = "Español";
            language.Image = Resource.Drawable._flagSpain;
            languages.Add(language);

            language = new Language();
            language.Id = 6;
            language.Name = "Português";
            language.Image = Resource.Drawable._flagPortugalBrazil;
            languages.Add(language);

            language = new Language();
            language.Id = 7;
            language.Name = "Česky";
            language.Image = Resource.Drawable._flagTheBestCzech;
            languages.Add(language);

            language = new Language();
            language.Id = 8;
            language.Name = "Polski";
            language.Image = Resource.Drawable._flagTheBestPoland;
            languages.Add(language);

            language = new Language();
            language.Id = 9;
            language.Name = "Русский";
            language.Image = Resource.Drawable._flagTheBestRussia;
            languages.Add(language);

            language = new Language();
            language.Id = 10;
            language.Name = "Українська";
            language.Image = Resource.Drawable._flagUkraine;
            languages.Add(language);

            language = new Language();
            language.Id = 11;
            language.Name = "日本人の";
            language.Image = Resource.Drawable._flagTheBestJapanNew;
            languages.Add(language);

            language = new Language();
            language.Id = 12;
            language.Name = "한국어";
            language.Image = Resource.Drawable._flagKorea;
            languages.Add(language);
            
            return languages;
        }






    }
}
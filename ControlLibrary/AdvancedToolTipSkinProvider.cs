using System.Drawing;

namespace ControlLibrary
{
    public interface ISkinProvider
    {
        Font PrimaryFont { get; set; }
        Font SecondaryFont { get; set; }
        Font SmallFont { get; set; }

        SolidBrush PrimaryFontColor { get; set; }
        SolidBrush SecondaryFontColor { get; set; }

        SolidBrush PrimaryColor { get; set; }
        SolidBrush AccentColor { get; set; }

        SolidBrush Background { get; set; }
    }

    class BlackToolTipSkin : ISkinProvider
    {
        public Font PrimaryFont { get; set; }
        public Font SecondaryFont { get; set; }
        public Font SmallFont { get; set; }

        public SolidBrush PrimaryFontColor { get; set; }
        public SolidBrush SecondaryFontColor { get; set; }

        public SolidBrush PrimaryColor { get; set; }
        public SolidBrush AccentColor { get; set; }

        public SolidBrush Background { get; set; }

        public BlackToolTipSkin()
        {
            PrimaryFont = new Font("Calibri", 12);
            SecondaryFont = new Font("Calibri", 9, FontStyle.Italic);
            SmallFont = new Font("Calibri", 9);


            PrimaryFontColor = new SolidBrush(Color.White);
            SecondaryFontColor = new SolidBrush(Color.LightSkyBlue);

            PrimaryColor = new SolidBrush(Color.Black);
            AccentColor = new SolidBrush(Color.Black);

            Background = new SolidBrush(Color.Black);
        }
    }

    class MaterialBlueTipSkin : ISkinProvider
    {
        public Font PrimaryFont { get; set; }
        public Font SecondaryFont { get; set; }
        public Font SmallFont { get; set; }

        public SolidBrush PrimaryFontColor { get; set; }
        public SolidBrush SecondaryFontColor { get; set; }

        public SolidBrush PrimaryColor { get; set; }
        public SolidBrush AccentColor { get; set; }

        public SolidBrush Background { get; set; }

        public MaterialBlueTipSkin()
        {
            PrimaryFont = new Font("Roboto-Regular", 12);
            SecondaryFont = new Font("Roboto-Regular", 9, FontStyle.Bold);
            SmallFont = new Font("Roboto-Regular", 9, FontStyle.Bold);


            PrimaryFontColor = new SolidBrush(Color.Black);
            SecondaryFontColor = new SolidBrush(Color.DarkGray);

            PrimaryColor = new SolidBrush(Color.Black);
            AccentColor = new SolidBrush(Color.LightSkyBlue);

            Background = new SolidBrush(Color.White);
        }
    }

    class MaterialOrangeTipSkin : ISkinProvider
    {
        public Font PrimaryFont { get; set; }
        public Font SecondaryFont { get; set; }
        public Font SmallFont { get; set; }

        public SolidBrush PrimaryFontColor { get; set; }
        public SolidBrush SecondaryFontColor { get; set; }

        public SolidBrush PrimaryColor { get; set; }
        public SolidBrush AccentColor { get; set; }

        public SolidBrush Background { get; set; }

        public MaterialOrangeTipSkin()
        {
            PrimaryFont = new Font("Roboto-Regular", 12);
            SecondaryFont = new Font("Roboto-Regular", 9, FontStyle.Bold);
            SmallFont = new Font("Roboto-Regular", 9, FontStyle.Bold);


            PrimaryFontColor = new SolidBrush(Color.Black);
            SecondaryFontColor = new SolidBrush(Color.DarkGray);

            PrimaryColor = new SolidBrush(Color.Black);
            AccentColor = new SolidBrush(Color.Orange);

            Background = new SolidBrush(Color.White);
        }
    }
}

using System;
using System.Diagnostics;
using System.Globalization;

namespace ChobbyLauncher
{
    public class TextToSpeechMac : TextToSpeechBase
    {
        private double volume = 100;

        public override void Say(string name, string text)
        {
            if (volume <= 0) return;
            var level = Math.Clamp(volume / 100, 0, 1).ToString(CultureInfo.InvariantCulture);
            Process.Start(new ProcessStartInfo("/usr/bin/say")
            {
                ArgumentList = { "[[volm " + level + "]] " + Sanitize(text) }
            });
        }

        public override void SetVolume(double value)
        {
            volume = value;
        }
    }
}

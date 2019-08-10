using System;
namespace FindDanceClasses.UI.Services
{
    public interface IPlatformService
    {
        bool GetHasHardwareKeys();

        double GetLines(string text, double width, double fontSize, string fontName = null);
    }
}

namespace SOLID.Factories
{
    using System;
    using SOLID.Interfaces;
    using SOLID.Models.Layouts;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                case "NoTimeLayout":
                    return new NoTimeLayout();
                default:
                    throw new ArgumentException($"Invalid layout type! - {layoutType}");
            }
        }
    }
}

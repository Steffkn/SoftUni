namespace SOLID.Models.Layouts
{
    using System;

    public class XmlLayout : Layout
    {
        public override string Format => "<log>" + Environment.NewLine +
                                "\t<date>{0}</date>" + Environment.NewLine +
                                "\t<level>{1}</level>" + Environment.NewLine +
                                "\t<message>{2}</message>" + Environment.NewLine +
                                "</log>" + Environment.NewLine;
    }
}

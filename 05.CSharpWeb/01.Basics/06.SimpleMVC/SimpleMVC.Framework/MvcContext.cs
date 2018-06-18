namespace SimpleMVC.Framework
{
    using System;

    public class MvcContext
    {
        private static MvcContext Instance;
        private static object locker = new Object();

        private MvcContext() { }

        public static MvcContext Get
        {
            get
            {
                if (Instance == null)
                {
                    lock (locker)
                    {
                        if (Instance == null)
                        {
                            Instance = new MvcContext();
                        }
                    }
                }

                return Instance;
            }
        }

        public string ResourcesFolder { get; set; }

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}

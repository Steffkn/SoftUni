namespace SimpleMVC.Framework
{
    using System;
    using System.Reflection;
    using WebServer;

    public static class MvcEngine
    {
        private const string DefaultModelsFolder = "Models";
        private const string DefaultViewsFolder = "Views";
        private const string DefaultResourcesFolder = "Resources";
        private const string DefaultControllersFolder = "Controllers";
        private const string ControllersSuffix = "Controller";

        public static void Run(WebServer server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();
            RegisterResourcesData();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        private static void RegisterControllersData()
        {
            MvcContext.Get.ControllersFolder = DefaultControllersFolder;
            MvcContext.Get.ControllersSuffix = ControllersSuffix;
        }

        private static void RegisterViewsData()
        {
            MvcContext.Get.ViewsFolder = DefaultViewsFolder;
        }

        private static void RegisterModelsData()
        {
            MvcContext.Get.ModelsFolder = DefaultModelsFolder;
        }

        private static void RegisterResourcesData()
        {
            MvcContext.Get.ResourcesFolder = DefaultResourcesFolder;
        }
    }
}

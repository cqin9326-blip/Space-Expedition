namespace Space_Expedition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArtifactManager manager = new ArtifactManager();
            Menu menu = new Menu(manager);
            manager.LoadVault();
            menu.Start();
        }
    }
}

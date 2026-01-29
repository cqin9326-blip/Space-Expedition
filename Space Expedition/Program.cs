namespace Space_Expedition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArtifactManager manager = new ArtifactManager();
            manager.Load("galactic_vault.txt");
        }
    }
}

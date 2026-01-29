using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition
{
    internal class ArtifactManager
    {
        private Artifact[] artifacts = new Artifact[5];
        private int count = 0;


        private void AddToArray(Artifact artifact)
        {
            if (count == artifacts.Length)
            {
                Artifact[] newarray = new Artifact[artifacts.Length * 2];

                for (int i = 0; i < artifacts.Length; i++)
                {
                    newarray[i] = artifacts[i];
                }

                artifacts = newarray;
            }

            artifacts[count] = artifact;
            count++;
        }

        public void LoadVault()
        {
            if (!File.Exists("galactic_vault.txt"))
            {
                Console.WriteLine("galactic_vault.txt not found.");
                return;
            }

            string[] lines = File.ReadAllLines("galactic_vault.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] part = lines[i].Split(',');

                Artifact artifact = new Artifact();
                artifact.EncodedName = part[0].Trim();
                artifact.DecodedName = DecodeName(artifact.EncodedName);
                artifact.Planet = part[1].Trim();
                artifact.DiscoveryDate = part[2].Trim();
                artifact.StorageLocation = part[3].Trim();
                artifact.Description = part[4].Trim();

                AddToArray(artifact);
            }

            SortArtifacts();
        }


    }
}

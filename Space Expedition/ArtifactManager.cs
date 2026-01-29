using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition
{
    internal class ArtifactManager
    {
        private const int MaximumArtifacts = 100;
        private Artifact[] artifactList;
        private int artifactCount;

        public ArtifactCollection()
        {
            artifactList = new Artifact[MaximumArtifacts];
            artifactCount = 0;
        }


        private char[] mapFrom =
{
            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        private char[] mapTo =
        {
            'H','Z','A','U','Y','E','K','G','O','T','I','R','J',
            'V','W','N','M','F','Q','S','D','B','X','L','C','P'
        };

        public void Load(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] p = line.Split(',');

                Artifact a = new Artifact();

                a.EncodedName = p[0].Trim();
                a.DecodedName = DecodeName(a.EncodedName);
                a.Planet = p[1].Trim();
                a.DiscoveryDate = p[2].Trim();
                a.StorageLocation = p[3].Trim();
                a.Description = p[4].Trim();

                list[count++] = a;
            }
            SortByName();
        }
    }
}

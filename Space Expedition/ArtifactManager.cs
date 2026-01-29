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

        private char Map(char letter)
        {
            char[] original = {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };

            char[] mapped = {
                'H','Z','A','U','Y','E','K','G','O','T','I','R','J',
                'V','W','N','M','F','Q','S','D','B','X','L','C','P'
            };

            for (int i = 0; i < original.Length; i++)
            {
                if (letter == original[i])
                {
                    return mapped[i];
                }
            }

            return letter;
        }

        private char Mirror(char letter)
        {
            char left = 'A';
            char right = 'Z';

            while (left <= right)
            {
                if (letter == left)
                {
                    return right;
                }

                if (letter == right)
                {
                    return left;
                }

                left++;
                right--;
            }

            return letter;
        }

        private string DecodeLayer(char letter, int level)
        {
            if (level == 1)
            {
                return Mirror(letter).ToString();
            }

            char mapped = Map(letter);
            return DecodeLayer(mapped, level - 1);
        }

        private string DecodeName(string encoded)
        {
            if (encoded.Length == 0)
            {
                return "";
            }

            char letter = encoded[0];

            if (encoded.Length == 1)
            {
                return Mirror(letter).ToString();
            }

            int level = int.Parse(encoded[1].ToString());

            return DecodeLayer(letter, level) + DecodeName(encoded.Substring(2));
        }

        private int CompareNames(string name1, string name2)
        {
            int i = 0;

            while (i < name1.Length && i < name2.Length)
            {
                if (name1[i] != name2[i])
                {
                    return name1[i] - name2[i];
                }
                i++;
            }

            return name1.Length - name2.Length;
        }

        private void InsertionSort()
        {
            for (int i = 1; i < count; i++)
            {
                Artifact key = artifacts[i];
                int j = i - 1;

                while (j >= 0 &&
                       CompareNames(artifacts[j].DecodedName, key.DecodedName) > 0)
                {
                    artifacts[j + 1] = artifacts[j];
                    j--;
                }

                artifacts[j + 1] = key;
            }
        }

        private int BinarySearch(string decodedName)
        {
            int left = 0;
            int right = count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                int key = CompareNames(artifacts[mid].DecodedName, decodedName);

                if (key == 0) return mid;
                if (key < 0) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        private void OrderedInsert(Artifact artifact)
        {
            EnsureCapacity();

            int i = count - 1;

            while (i >= 0 &&
                   CompareNames(artifacts[i].DecodedName, artifact.DecodedName) > 0)
            {
                artifacts[i + 1] = artifacts[i];
                i--;
            }

            artifacts[i + 1] = artifact;
            count++;
        }




    }
}

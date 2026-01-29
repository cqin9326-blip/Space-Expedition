using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Expedition
{
    internal class ArtifactManager
    {
        private Artifact[] list = new Artifact[200];
        private int count = 0;


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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDecimalApplication
{
    class TreeNode<String>
    {
        public string Data { get; set; }

        public TreeNode<String> Parent { get; set; }

        public List<TreeNode<String>> Children { get; set; }

        public int GetHeight()
        {
            int height = 1;
            TreeNode<String> current = this;
            while (current.Parent != null)
            {
                height++;
                current = current.Parent;

            }

            return height;
            //Techie, M. (2020).C# - How to insert delete update in TreeNode. Available: https://www.youtube.com/watch?v=9Tz4sLvZzFc. Last accessed 5th Dec 2021.
        }

    }
}

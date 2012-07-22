using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class PropertyNode
    {
        public SortedSet<PropertyNode> childrenNodes;
        public string Name { get; private set; }
        public int Id { get; private set; }

        public PropertyNode(string name, int id)
        {
            this.Name = name;
            this.Id = id;
            childrenNodes = new SortedSet<PropertyNode>();
        }

         

    }
}

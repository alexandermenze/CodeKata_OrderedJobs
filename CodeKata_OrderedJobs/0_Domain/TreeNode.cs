using System.Collections.Generic;
using System.Linq;

namespace CodeKata_OrderedJobs.Domain
{
    class TreeNode<T>
    {
        public T Data { get; }
        public TreeNode<T> Parent { get; }
        public IEnumerable<TreeNode<T>> Children
        {
            get { return _children; }
        }

        private ICollection<TreeNode<T>> _children = new LinkedList<TreeNode<T>>();

        public TreeNode(T data, TreeNode<T> parent = null){
            Data = data;
            Parent = parent;
        }

        public TreeNode<T> AddChild(T child)
        {
            var childNode = new TreeNode<T>(child, this);
            _children.Add(childNode);
            return childNode;
        }

        public TreeNode<T> Search(T data)
            => Children.FirstOrDefault(node => node.Data.Equals(data));

        public bool Contains(T data)
            => Search(data) != null;

        public string ToString()
        {

        }
    }
}

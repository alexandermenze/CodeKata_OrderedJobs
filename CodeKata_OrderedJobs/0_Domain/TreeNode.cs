using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeKata_OrderedJobs.Domain
{
    class TreeNode<T>
    {
        public T Data { get; }
        public TreeNode<T> Parent { get; }
        public IEnumerable<TreeNode<T>> Children
        {
            get => _children;
        }

        public bool IsRoot
        {
            get => Parent == null;
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
        {
            var resultNode = Children.FirstOrDefault(node => node.Data.Equals(data));
            if(resultNode == null)
            {
                foreach(var child in Children)
                {
                    resultNode = child.Search(data);
                    if (resultNode != null) return resultNode;
                }
            }
            return resultNode;
        }

        public bool Contains(T data)
            => Search(data) != null;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            ToString(stringBuilder);
            return stringBuilder.ToString();
        }

        private void ToString(StringBuilder stringBuilder)
        {
            Children
                .ToList()
                .ForEach(node => node.ToString(stringBuilder));
            if(!IsRoot)
                stringBuilder.Append(Data.ToString());
        }
    }
}

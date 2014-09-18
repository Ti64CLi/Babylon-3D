using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    public class ClientRectAdapter : Web.ClientRect
    {
        public ClientRectAdapter(int left, int right, int width, int height)
        {
            this.left = left;
            this.right = right;
            this.width = width;
            this.height = height;
        }

        public int left
        {
            get;
            set;
        }

        public int width
        {
            get;
            set;
        }

        public int right
        {
            get;
            set;
        }

        public int top
        {
            get;
            set;
        }

        public int bottom
        {
            get;
            set;
        }

        public int height
        {
            get;
            set;
        }
    }
}

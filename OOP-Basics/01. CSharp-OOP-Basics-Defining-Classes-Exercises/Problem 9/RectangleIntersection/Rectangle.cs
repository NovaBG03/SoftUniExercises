

namespace RectangleIntersection
{
    class Rectangle
    {
        private string id;
        private int width;
        private int height;
        private int topLeftX;
        private int topLeftY;
        //private int topRightX;
        //private int topRightY;
        //private int botLeftX;
        //private int botLeftY;
        //private int botRightX;
        //private int botRightY;

        public Rectangle(string id, int width, int height, int topLeftX, int topLeftY)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.TopLeftX = TopLeftX;
            this.TopLeftY = TopLeftY;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int TopLeftX
        {
            get { return topLeftX; }
            set { topLeftX = value; }
        }

        public int TopLeftY
        {
            get { return topLeftY; }
            set { topLeftY = value; }
        }

        //public int TopRightX
        //{
        //    get { return topRightX; }
        //    set { topRightX = value; }
        //}
        //public int TopRightY
        //{
        //    get { return topRightY; }
        //    set { topRightY = value; }
        //}
        //public int BotLeftX
        //{
        //    get { return botLeftX; }
        //    set { botLeftX = value; }
        //}
        //public int BotLeftY
        //{
        //    get { return botLeftY; }
        //    set { botLeftY = value; }
        //}
        //public int BotRightX
        //{
        //    get { return botRightX; }
        //    set { botRightX = value; }
        //}
        //public int BotRightY
        //{
        //    get { return botRightY; }
        //    set { botRightY = value; }
        //}


        public bool Intersects(Rectangle rectangle2)
        {
            if ((this.TopLeftX + this.Width < rectangle2.TopLeftX) ||
                (rectangle2.TopLeftX + rectangle2.Width < this.TopLeftX) ||
                (this.TopLeftY < rectangle2.TopLeftY - rectangle2.Height) ||
                (rectangle2.TopLeftY < this.TopLeftY - this.Height))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


    }
}

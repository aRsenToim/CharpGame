using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Controller
{
    internal class QuadTreeController
    {
        private int MAX_OBJECTS = 1;
        private int MAX_DEPTH = 6;

        private Rectangle Bounds;
        private List<QuadTreeObject> objects;
        private QuadTreeController[] children;
        private int level = 0;

        public QuadTreeController(Rectangle bounds, int Level)
        {
            Bounds = bounds;
            level = Level;
            objects = new List<QuadTreeObject>();
            children = new QuadTreeController[4];
        }

        public void Clear()
        {
            objects.Clear();

            for (int i = 0; i < children.Length; i++)
            {
                if (children[i] != null)
                {
                    children[i].Clear();
                    children[i] = null;
                }
            }
        }

        private int GetIndex(Rectangle Item)
        {
            int index = -1; //0-3, -1 - пересечение
            double centerX = Bounds.X + (Bounds.Width / 2);
            double centerY = Bounds.Y + (Bounds.Height / 2);

            bool topQuad = (Item.Y < centerY && Item.Y + Item.Height < centerY);
            bool bottomQuad = (Item.Y > centerY);

            if (Item.X < centerX && Item.X + Item.Width < centerX)
            {
                if (topQuad) index = 1;
                else if (bottomQuad) index = 2;
            }

            else if (Item.X > centerX)
            {
                if (topQuad) index = 0;
                else if (bottomQuad) index = 3;
            }

            return index;
        }

        private void subdivide()
        {
            int subWidth = Bounds.Width / 2;
            int subHeight = Bounds.Height / 2;

            // 0 — верх-право, 1 — верх-лево, 2 — низ-лево, 3 — низ-право
            children[0] = new QuadTreeController(new Rectangle(Bounds.X + subWidth, Bounds.Y, subWidth, subHeight), level + 1);
            children[1] = new QuadTreeController(new Rectangle(Bounds.X, Bounds.Y, subWidth, subHeight), level + 1);
            children[2] = new QuadTreeController(new Rectangle(Bounds.X, Bounds.Y + subHeight, subWidth, subHeight), level + 1);
            children[3] = new QuadTreeController(new Rectangle(Bounds.X + subWidth, Bounds.Y + subHeight, subWidth, subHeight), level + 1);
        }

        public void Insert(QuadTreeObject obj)
        {
            if (children[0] != null)
            {
                int index = GetIndex(obj.Bounds);

                if (index != -1)
                {
                    children[index].Insert(obj);
                    return;
                }
            }

            objects.Add(obj);

            if (objects.Count > MAX_OBJECTS && level < MAX_DEPTH)
            {
                if (children[0] == null)
                {
                    subdivide();
                }

                int i = 0;
                while (i < objects.Count)
                {
                    int index = GetIndex(objects[i].Bounds);
                    if (index != -1)
                    {
                        children[index].Insert(objects[i]);
                        objects.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        public List<QuadTreeObject> Query(List<QuadTreeObject> returnObjects, Rectangle area)
        {
            if (!Bounds.Intersects(area))
            {
                return returnObjects;
            }

            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].Bounds.Intersects(area))
                {   
                    returnObjects.Add(objects[i]);
                }
            }

            if (children[0] != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    children[i].Query(returnObjects, area);
                }
            }

            return returnObjects;
        }

        public List<Rectangle> GetFullBounds(List<Rectangle> boundsList = null)
        {
            if (boundsList == null) boundsList = new List<Rectangle>();

            boundsList.Add(Bounds);

            if (children != null)
            {
                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] != null)
                        children[i].GetFullBounds(boundsList);
                }
            }

            return boundsList;
        }
    }
}
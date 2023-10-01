using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace customprogram
{
    public abstract class GameObject
    {
        private double _x, _y;
        private int _radius;
        private Bitmap _image;
        private string _name;
        private Window _win;
        public GameObject()
        { }
        public double X
        {
            get 
            {
                return _x;
            }
            set 
            {
                _x = value;
            }
        }
        public double Y
        {
            get 
            {
                return _y;
            }
            set 
            {
                _y = value;
            }
        }
        public int Radius
        {
            get 
            {
              return _radius;
            }
            set
            {
                _radius = value;
            }
        }
        public Bitmap Image
        {
            get 
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public string Name
        {
            get 
            {   
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Window Win
        {
            get { return _win; }
            set { _win = value; }
        }
   
        public abstract void Draw();
        public abstract void Move();
    }
}

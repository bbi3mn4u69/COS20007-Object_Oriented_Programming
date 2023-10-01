using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customprogram
{
    public class ManageGoDownObject
    {
        private List<GodownObject> _go_down_object_list;
        private int _enemymax, _bossmax, _heartmax, _shieldmax;

        public ManageGoDownObject() 
        {
            _go_down_object_list = new List<GodownObject>();
            _enemymax = 8;
            _bossmax = 5;
            _heartmax = 3;
            _shieldmax = 3;
        }
        public List<GodownObject> GoDownObjectList
        {
            get 
            {
                return _go_down_object_list; 
            }
            set 
            {
                _go_down_object_list = value;
            }
        }
        // add go down object
        public void AddGoDownObject(GodownObject obj)
        {
            if (obj.Name == "bigboss")
            {
                if (AddBoss())
                {
                    _go_down_object_list.Add(obj);
                }
            }
            else if (obj.Name == "enemy")
            {
                if (AddEnemies())
                {
                    _go_down_object_list.Add(obj);
                }
            }
            else if (obj.Name == "heart")
            {
                if (AddHeart()) 
                {
                  _go_down_object_list.Add(obj);
                }
                
            }
            else if (obj.Name == "shield") 
            {
                if (AddShield()) 
                {
                    _go_down_object_list.Add(obj);
                }
                
            }

        }
        // condition to add boss
        private bool AddBoss() 
        {
            int boss = 0;
            foreach (GodownObject obj in _go_down_object_list) 
            {
                if (obj.Name == "bigboss")
                {
                    boss++;
                }
            }
            return boss < _bossmax;
        }
        // condition to add enemies
        private bool AddEnemies()
        {
            int enemies = 0;
            foreach (GodownObject obj in _go_down_object_list)
            {
                if (obj.Name == "enemy") 
                {
                    enemies++;
                }
            }
            return enemies < _enemymax;
        }
        // condition to add abilities
        private bool AddHeart() 
        {
            int heart = 0;
            foreach (GodownObject obj in _go_down_object_list)
                if (obj.Name == "heart") 
                {
                    heart++;    
                }
            return heart < _heartmax;
        }
        private bool AddShield()
        {
            int shield = 0;
            foreach (GodownObject obj in _go_down_object_list) 
                if (obj.Name == "shield") 
                {
                    shield++;
                }
            return shield < _shieldmax;
        }
        public void RemoveGoDownObject(GodownObject obj) 
        {
            _go_down_object_list.Remove(obj);
        }
    }
}

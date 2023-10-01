using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace customprogram
{
    public class SpaceWar : IGameState
    {
        private ManageGoDownObject _godownobjectmanager;
        // game 
        private Player _player;
        private BackGround _gamebackground;
        // Object List
        private List<PlayerBullet> _bulletlist;
        // remove object list
        private List<GodownObject> _rmvgodownobject;
        private List<PlayerBullet> _rmvbulletlist;
        // checkcollision
        private CollisionDetector _collision_detector;
        public SpaceWar(Window win) 
        {
            _godownobjectmanager = new ManageGoDownObject();
            _player = new Player(win);
            _gamebackground = new BackGround();
            // create new object list
           
            _bulletlist = new List<PlayerBullet>();
            //create new remove list 
            _rmvbulletlist = new List<PlayerBullet>();
            _rmvgodownobject = new List<GodownObject>();
            _collision_detector = new CollisionDetector();
        }
        // new handle input

        public void HandleInput(Window win) 
        {

            double _player_speed = 1.6;
            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _player.X += _player_speed;
            }
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                _player.X -= _player_speed;
            }
            if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                _player.Y -= _player_speed;
            }
            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                _player.Y += _player_speed;
            }
     
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                _bulletlist.Add(new PlayerBullet(win, _player.X, _player.Y));
            }

        }
        // create go down object
        private GodownObject AddGoDownObject(GoDownObjectFactory godownobjfactory, Window win) 
        {
            int numbers = SplashKit.Rnd(1, 5);
            GodownObject godownobj = godownobjfactory.Create(numbers, win);
            return godownobj;
        }

        // adding created go down obejct to the list 
        public void SpawnGodownObject(Window win) 
        {
            GoDownObjectFactory godownobjfactory = new GoDownObjectFactory();
            GodownObject godownobj = AddGoDownObject(godownobjfactory, win);
            if (SplashKit.Rnd(1, 500) < 7)
            {
                _godownobjectmanager.AddGoDownObject(godownobj);
            }
        }

     
        // player bullet hit boss and enemies
        public void BulletCollision(Window win) 
        {
            foreach (PlayerBullet bullet in _bulletlist)
            {
                foreach (GodownObject godownobj in _godownobjectmanager.GoDownObjectList)
                {
                    if (_collision_detector.CheckCollision(bullet, godownobj)) 
                    {
                        if (godownobj.Name == "bigboss" || godownobj.Name == "enemy")
                        {
                           _rmvbulletlist.Add(bullet);
                           godownobj.Health -= 1;
                            if (godownobj.Health == 0)
                            {
                                _rmvgodownobject.Add(godownobj);
                            }
                        }
                    }
                }
            }
            // delete bullet
            foreach (PlayerBullet bullet in _rmvbulletlist)
            {
                _bulletlist.Remove(bullet);
            }
            // delete boss and enemies
            foreach (GodownObject godownobj in _rmvgodownobject)
            {
                _godownobjectmanager.RemoveGoDownObject(godownobj);
            }

        }

        // when colision occur between minion, abilties and player
        public void GoDownObjectWhenCollideWithPlayer()
        {
            foreach (GodownObject godownobj in _godownobjectmanager.GoDownObjectList)
            {
                if (_collision_detector.CheckCollision(godownobj, _player))
                {
                    _rmvgodownobject.Add(godownobj);
                    if (godownobj.Name == "enemy")
                    {
                        if (_player.Health == 10 && _player.Shield > 0)
                        {
                            _player.Shield -= 1;
                          
                        }
                        else if (_player.Health >= 0 && _player.Shield == 0)
                        {
                            _player.Health -= 1;
                 
                        }
                        _rmvgodownobject.Add(godownobj);
                    }
                    if (godownobj.Name == "heart") 
                    {
                        if (_player.Shield == 0 && _player.Health < 10)
                        {
                            _player.Health += 1;
                        }
                        _rmvgodownobject.Add(godownobj);
                    }
                    
                    if (godownobj.Name == "shield")
                    {
                        if (_player.Shield < 10 && _player.Health == 10)
                        {
                            _player.Shield += 1;
                        }
                        _rmvgodownobject.Add(godownobj);
                    }
                    if (godownobj.Name == "bigboss")
                    {
                        if (_player.Health == 10 && _player.Shield > 0)
                        {
                            _player.Shield -= 5;
                            if (_player.Shield < 5) 
                            {
                                _player.Shield = 0;
                            }
                        }
                        else if (_player.Health >= 0 && _player.Shield == 0)
                        {
                            _player.Health -= 5;
                            if (_player.Health < 5)
                            {
                                _player.Health = 0;
                            }
                        }
                        _rmvgodownobject.Add(godownobj);
                    }
                }
            }
            foreach (GodownObject godownobj in _rmvgodownobject)
            {
                _godownobjectmanager.RemoveGoDownObject(godownobj);
            }
        }
       
        public void GameObjectOffScreen()
        {
            //remove redundant bullet
            foreach (PlayerBullet bullet in _bulletlist)
            {
                if (bullet.OnScreen() == false) 
                {
                    _rmvbulletlist.Remove(bullet);  
                }
            }
            foreach (PlayerBullet bullet in _rmvbulletlist)
            {
                _bulletlist.Remove(bullet); 
            }
            // remove falling object 
            foreach (GodownObject godownobj in _godownobjectmanager.GoDownObjectList)
            {
                if (godownobj.Y > 640 + godownobj.Radius)
                {
                    _rmvgodownobject.Add(godownobj);
                }
            }
            
            foreach (GodownObject godownobj in _rmvgodownobject)
            {
                _godownobjectmanager.RemoveGoDownObject(godownobj);
            }
        }
        
        public void CheckEnd() 
        {
            if (_player.Health == 0)
            {
                // end state 1, hit by enemies
                GameStateManager.Instance().SetState(new EndState1());
            }
            else if (_player.Y < -_player.Radius)
            {
                // end stage 2, player go off screen
                GameStateManager.Instance().SetState(new EndState2());
            }
            foreach (GodownObject godownobj in _godownobjectmanager.GoDownObjectList)
            {
                if (godownobj.Name == "enemy") 
                {
                    if (godownobj.Y > 640)
                    {
                        // end state 3, if enenies reached base
                        GameStateManager.Instance().SetState(new EndState3());
                    }
                }
                else if (godownobj.Name == "bigboss")
                {
                    if (godownobj.Y > 640)
                    {
                        // end state 4, if boss reached base
                        GameStateManager.Instance().SetState(new EndState4());
                    }
                }
            }
        }
      
        // new Draw Game
        public void Draw() 
        {
            _gamebackground.Draw();
            _player.Draw();
           
            foreach (PlayerBullet bullet in _bulletlist)
            {
                bullet.Draw();
            }
            foreach (GodownObject godownobj in _godownobjectmanager.GoDownObjectList)
            {
                godownobj.Draw();
            }
        }


        public void Update(Window win)
        {

           
            BulletCollision(win);
            GameObjectOffScreen();
            GoDownObjectWhenCollideWithPlayer();
            CheckEnd();
            foreach (PlayerBullet bullet in _bulletlist)
            {
                bullet.Move();
            }

            foreach (GodownObject godownobj in _godownobjectmanager.GoDownObjectList)
            {
                godownobj.Move();
            }
            SpawnGodownObject(win);
            _player.Move();
       
        }
  
    }
}

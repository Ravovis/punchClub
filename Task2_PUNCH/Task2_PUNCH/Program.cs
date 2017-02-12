using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_PUNCH
{
    class Program
    {
        enum Area { head, body, legs }
        class Fighter
        {
            
            int HP;
            public Fighter()
            {
                this.HP = 100;
            }
            public void GetHit(Area? attack)
            {
                switch(attack)
                {
                    case Area.legs: this.HP -= 10;
                        break;
                    case Area.body:
                        this.HP -= 25;
                        break;
                    case Area.head:
                        this.HP -= 50;
                        break;
                }
            }
            public bool IsDead()
            {
                if (this.HP <= 0) return true;
                else return false;
            }
            public void GetInfo()
            {
                Console.WriteLine("HP: "+ (this.HP >=0 ? this.HP : 0));
            }
        }
        //--------------------
        
        class Fight
        {
            Fighter Player, Enemy;
           
            Area? Attack1, Attack2, Defence1, Defence2;
            public Fight(Fighter P, Fighter E)
            {
                Player = P;
                Enemy = E;
                Attack1 = null; Attack2 = null; Defence1 = null;Defence2 = null;
            }

            public void TurnInit()
            {
                Console.WriteLine("Where do you want to punch? (1 - HEAD , 2 - BODY, 3 - LEGS)");
                int answer = int.Parse(Console.ReadLine());
                switch(answer)
                {
                    case 1:
                        Attack1 = Area.head;
                        break;
                    case 2:
                        Attack1 = Area.body;
                        break;
                    case 3:
                        Attack1 = Area.legs;
                        break;
                }
                Console.WriteLine("Where do you want to protect? (1 - HEAD , 2 - BODY, 3 - LEGS)");
                answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        Defence1 = Area.head;
                        break;
                    case 2:
                        Defence1 = Area.body;
                        break;
                    case 3:
                        Defence1 = Area.legs;
                        break;
                }

                Random r = new Random();


                answer = r.Next(2) + 1;
                switch (answer)
                {
                    case 1:
                        Defence2 = Area.head;
                        break;
                    case 2:
                        Defence2 = Area.body;
                        break;
                    case 3:
                        Defence2 = Area.legs;
                        break;
                }

                answer = r.Next(2)+1;
                switch (answer)
                {
                    case 1:
                        Attack2 = Area.head;
                        break;
                    case 2:
                        Attack2 = Area.body;
                        break;
                    case 3:
                        Attack2 = Area.legs;
                        break;
                }
            }
            public void NextTurn()
            {
                if(Attack1==null)
                {
                    return;
                }
                if (Attack2 == null)
                {
                    return;
                }
                if (Defence1 == null)
                {
                    return;
                }
                if (Defence2 == null)
                {
                    return;
                }
                if(Attack1!=Defence2)
                {
                    Console.WriteLine("Succesfull attack");
                    Enemy.GetHit(Attack1);
                   
                    if (Enemy.IsDead())
                    {
                        Enemy = null;
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("Enemy blocked an attack");
                }
                Console.WriteLine("Enemy:");
                Enemy.GetInfo();
                if (Attack2 != Defence1)
                {
                    Console.WriteLine("Enemy get you");
                    Player.GetHit(Attack2);
                   
                    if (Player.IsDead())
                    {
                        Console.WriteLine("Player:");
                        Player.GetInfo();
                        Player = null;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("You blocked an attack");
                }
                Console.WriteLine("Player:");
                Player.GetInfo();
                Attack1 = null; Attack2 = null; Defence1 = null; Defence2 = null;
            }

            public bool IsEnded()
            {
                if(Player==null)
                {
                    Console.WriteLine("Defeat");
                    return true;
                }
                if (Enemy == null)
                {
                    Console.WriteLine("Victory");
                    return true;
                }
                return false;
            }

        }


        //-------------------------------
        static void Main(string[] args)
        {
            Fighter Player = new Fighter();
            Fighter Enemy = new Fighter();

            Fight fight = new Fight(Player, Enemy);
            while(!fight.IsEnded())
            {
                fight.TurnInit();
                fight.NextTurn();
            }

           
        }
    }
}

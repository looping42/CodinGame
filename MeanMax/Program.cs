using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MeanMax
{
    public class Program
    {
        private const int reaper = 400;
        private const int carteCirculaire = 6000;

        public static void Main(string[] args)
        {
            while (true)
            {
                List<unit> unitesLst = new List<unit>();
                int myScore = int.Parse(Console.ReadLine());
                int enemyScore1 = int.Parse(Console.ReadLine());
                int enemyScore2 = int.Parse(Console.ReadLine());
                int myRage = int.Parse(Console.ReadLine());
                int enemyRage1 = int.Parse(Console.ReadLine());
                int enemyRage2 = int.Parse(Console.ReadLine());
                int unitCount = int.Parse(Console.ReadLine());
                for (int i = 0; i < unitCount; i++)
                {
                    string[] inputs = Console.ReadLine().Split(' ');
                    int unitId = int.Parse(inputs[0]);
                    int unitType = int.Parse(inputs[1]);
                    int player = int.Parse(inputs[2]);
                    float mass = float.Parse(inputs[3]);
                    int radius = int.Parse(inputs[4]);
                    int x = int.Parse(inputs[5]);
                    int y = int.Parse(inputs[6]);
                    int vx = int.Parse(inputs[7]);
                    int vy = int.Parse(inputs[8]);
                    int extra = int.Parse(inputs[9]);
                    int extra2 = int.Parse(inputs[10]);

                    if (player == 0)
                    {
                        unit unites = new unit(unitId, unitType, player, mass, radius, x, y, vx, vy, extra, extra2, myRage);
                        unitesLst.Add(unites);
                    }
                    else if (player == 1)
                    {
                        unit unites = new unit(unitId, unitType, player, mass, radius, x, y, vx, vy, extra, extra2, enemyRage1);
                        unitesLst.Add(unites);
                    }
                    else
                    {
                        unit unites = new unit(unitId, unitType, player, mass, radius, x, y, vx, vy, extra, extra2, enemyRage2);
                        unitesLst.Add(unites);
                    }
                }

                foreach (unit item in unitesLst)
                {
                    Console.Error.WriteLine(item.ToString());
                    item.GetAcceleration(300);
                }

                Game game = new Game(unitesLst);
                game.MoveReaper();
                game.Movedestroyer();
                game.Movedoofer();
                Console.Error.WriteLine("findetour");
                foreach (unit item in unitesLst)
                {
                    item.FinDetourfriction();
                    Console.Error.WriteLine(item.ToString());
                }
            }
        }
    }

    public class Game
    {
        public List<unit> playerEnnemy;
        public List<unit> Player0Lst;
        public List<unit> Player1Lst;
        public List<unit> Player2Lst;
        public List<unit> epaves;

        public List<unit> tankToDestroy;

        //public List<unit> doofer;
        public List<unit> unitesLst;

        public Game(List<unit> unitesLst)
        {
            Player0Lst = unitesLst.Where(x => x.player == 0).ToList();
            Player1Lst = unitesLst.Where(x => x.player == 1).ToList();
            Player2Lst = unitesLst.Where(x => x.player == 2).ToList();
            epaves = unitesLst.Where(x => x.unitType == 4).ToList();
            tankToDestroy = unitesLst.Where(x => x.unitType == 3).ToList();
            playerEnnemy = new List<unit>();
            playerEnnemy.AddRange(Player1Lst);
            playerEnnemy.AddRange(Player2Lst);
            this.unitesLst = unitesLst;
        }

        public bool IsInCircle()
        {
            bool unitInsideCircle = false;

            foreach (unit myunit in Player0Lst)
            {
                foreach (unit epave in epaves)
                {
                    if (Math.Pow((myunit.x - epave.x), epave.radius) + Math.Pow((myunit.y - epave.y), epave.radius) <= myunit.radius + epave.radius)
                    {
                        unitInsideCircle = true;
                    }
                }
            }
            return unitInsideCircle;
        }

        public bool isInRectangle(unit epaveUnit, unit unitToCompare)
        {
            return epaveUnit.x >= unitToCompare.x - unitToCompare.radius && epaveUnit.x <= unitToCompare.x + unitToCompare.radius && epaveUnit.y >= unitToCompare.y - unitToCompare.radius && epaveUnit.y <= unitToCompare.y + unitToCompare.radius;
        }

        //test if coordinate (x, y) is within a radius from coordinate (center_x, center_y)
        public bool isPointInCircle(unit epaveUnit, unit unitToCompare)
        {
            if (isInRectangle(epaveUnit, unitToCompare))
            {
                double dx = unitToCompare.x - epaveUnit.x;
                double dy = unitToCompare.y - epaveUnit.y;
                dx *= dx;
                dy *= dy;
                double distanceSquared = dx + dy;
                double radiusSquared = unitToCompare.radius * unitToCompare.radius;
                return distanceSquared <= radiusSquared;
            }
            return false;
        }

        public bool IfReaperWasInepavesDontMove()
        {
            List<unit> myReaper = Player0Lst.Where(x => x.unitType == 0).ToList();
            if (epaves.Count() > 0)
            {
                bool inCircle = IsInCircle();
                if (inCircle)
                {
                    return true;
                }
            }
            return false;
        }

        public void MoveReaper()
        {
            if (!IfReaperWasInepavesDontMove())
            {
                List<unit> myReaper = Player0Lst.Where(x => x.unitType == 0).ToList();
                if (epaves.Count() > 0)
                {
                    foreach (unit reaper in myReaper)
                    {
                        List<unit> epaveNear = CalculateDistanceBetweenCircle(reaper, 4, epaves);
                        epaveNear.OrderByDescending(x => x.extra).ThenBy(x => x.DistanceBetweenComparaison).FirstOrDefault();
                        Console.WriteLine(epaves[0].x + " " + epaves[0].y + " 300");
                    }
                }
                else
                {
                    foreach (unit reaper in myReaper)
                    {
                        tankToDestroy = tankToDestroy.OrderByDescending(x => x.extra).ToList();
                        Console.WriteLine(tankToDestroy[0].x + " " + tankToDestroy[0].y + " 300");
                    }
                }
            }
            else
            {
                Console.WriteLine("WAIT");
            }
        }

        public void Movedestroyer()
        {
            List<unit> mydestroyer = Player0Lst.Where(x => x.unitType == 1).ToList();
            foreach (unit destroyer in mydestroyer)
            {
                List<unit> unitNear = new List<unit>();
                unitNear = CalculateDistanceBetweenCircle(destroyer, 0, playerEnnemy);
                if ((unitNear.Count() > 1) && (destroyer.myRage >= 60))
                {
                    List<unit> zoneepavestoBlock = SearchNearUnitWhoAreInEpaveZone(unitNear);
                    if (zoneepavestoBlock.Count() > 0)
                        Console.WriteLine("SKILL " + zoneepavestoBlock[0].x + " " + zoneepavestoBlock[0].y + " BOMB");
                    else
                        Console.WriteLine(tankToDestroy[0].x + " " + tankToDestroy[0].y + " 300");
                }
                else
                {
                    tankToDestroy = tankToDestroy.OrderByDescending(x => x.extra).ToList();
                    Console.WriteLine(tankToDestroy[0].x + " " + tankToDestroy[0].y + " 300");
                }
            }
        }

        public void Movedoofer()
        {
            unit playeroneReaper = Player1Lst.Where(x => x.unitType == 0).First();
            List<unit> mydoofer = Player0Lst.Where(x => x.unitType == 2).ToList();
            foreach (unit doofer in mydoofer)
            {
                List<unit> unitNear = new List<unit>();
                unitNear = CalculateDistanceBetweenCircle(doofer, 0, playerEnnemy);
                if ((unitNear.Count > 0) && (doofer.myRage >= 30))
                {
                    List<unit> zoneepavestoBlock = SearchNearUnitWhoAreInEpaveZone(unitNear);
                    if (zoneepavestoBlock.Count() > 0)
                        Console.WriteLine("SKILL " + zoneepavestoBlock[0].x + " " + zoneepavestoBlock[0].y + " Flaques Huiles");
                    else
                        Console.WriteLine(playeroneReaper.x + " " + playeroneReaper.y + " 300");
                }
                else
                {
                    Console.WriteLine(playeroneReaper.x + " " + playeroneReaper.y + " 300");
                }
            }
        }

        /// <summary>
        /// recherche des unités ennemis proche qui sont dans les zone des epaves
        /// </summary>
        public List<unit> SearchNearUnitWhoAreInEpaveZone(List<unit> unitEnnemiNear)
        {
            List<unit> lstUnitesNearEnnemiinZoneEpaves = new List<unit>();
            //pour chaque unités ennemis proche  on recherche les unités qui sont dans la zone des épaves
            foreach (unit ennemiUnit in playerEnnemy.Where(x => x.unitType == 0))
            {
                foreach (var epave in epaves)
                {
                    if (IntersectCircle(ennemiUnit, epave))
                    {
                        lstUnitesNearEnnemiinZoneEpaves.Add(epave);
                    }
                }
            }
            return lstUnitesNearEnnemiinZoneEpaves;
        }

        public bool IntersectCircle(unit FirstCircle, unit CircleToCompare)

        {
            float distanceX = FirstCircle.x - CircleToCompare.x;
            float distanceY = FirstCircle.y - CircleToCompare.y;
            float radiusSum = CircleToCompare.radius + FirstCircle.radius;
            return distanceX * distanceX + distanceY * distanceY <= radiusSum * radiusSum;
        }

        public List<unit> CalculateDistanceBetweenCircle(unit SearchnearThisUnit, int unitType, List<unit> lstUnitToSearch)
        {
            List<unit> unitNear = new List<unit>();
            foreach (unit ennemiUnit in lstUnitToSearch.Where(x => x.unitType == unitType))
            {
                double DistanceCircle = Math.Sqrt(Math.Pow(ennemiUnit.x - SearchnearThisUnit.x, 2) + Math.Pow(ennemiUnit.y - SearchnearThisUnit.y, 2) - (ennemiUnit.radius + SearchnearThisUnit.radius));
                if (DistanceCircle <= 2000)
                {
                    ennemiUnit.DistanceBetweenComparaison = DistanceCircle;
                    unitNear.Add(ennemiUnit);
                }
            }
            return unitNear;
        }

        public void calculateDecellerate(int targetX, int targetY, unit pointActuel)
        {
            int deltaX = targetX - pointActuel.x;
            int deltaY = targetY - pointActuel.y;
            double distance = Math.Sqrt(Math.Pow(deltaX, deltaX) + Math.Pow(deltaY, deltaY));
            //int DECELERATION = v * (1 - 0.2);
            int decelDistance = Math.Pow(pointActuel.vx, pointActuel.vy) / (2 * 0.2);

            if (distance > decelDistance) //we are still far, continue accelerating (if possible)
            {
                velocity = Math.Min(velocity + ACCELERATION * dt, TOPSPEED);
            }
            else    //we are about to reach the target, let's start decelerating.
            {
                velocity = Math.Max(velocity - DECELERATION * dt, 0);
            }

            cx += velocity * cosangle * dt;
            cy += velocity * sinangle * dt;
        }
    }

    public class unit
    {
        private const double friction = 0.2;
        public int unitId { get; set; }
        public int unitType { get; set; }
        public int player { get; set; }
        public float mass { get; set; }
        public int radius { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int vx { get; set; }
        public int vy { get; set; }
        public double vitessexAfterFriction { get; set; }
        public double vitesseyAfterFriction { get; set; }
        public double velocityXAfterFriction { get; set; }
        public double velocityYAfterFriction { get; set; }
        public int extra { get; set; }
        public int extra2 { get; set; }
        public float acceleration { get; set; }
        public int myRage { get; set; }
        public double DistanceBetweenComparaison { get; set; }

        public double Speed()
        {
            return Math.Sqrt(vx * vx + vy * vy);
        }

        public float GetAcceleration(int acc)
        {
            if (vx != 0)
                return acc / mass;
            else
                return 0;
        }

        public void FinDetourfriction()
        {
            vitessexAfterFriction = Convert.ToDouble(vx * (1 - friction));
            vitesseyAfterFriction = Convert.ToDouble(vy * (1 - friction));
            velocityXAfterFriction = vitessexAfterFriction - vx;
            velocityYAfterFriction = vitesseyAfterFriction - vy;
        }

        public unit(int unitId, int unitType, int player, float mass, int radius, int x, int y, int vx, int vy, int extra, int extra2, int myRage)
        {
            this.unitId = unitId;
            this.unitType = unitType;
            this.player = player;
            this.mass = mass;
            this.radius = radius;
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            this.extra = extra;
            this.extra2 = extra2;
            this.myRage = myRage;
        }

        public override string ToString()
        {
            return ("unitid :" + unitId + " unitType :" + unitType + " player :" + player + " mass :" + mass + " radius :" + radius + " x:" + x
                + " y:" + y + " vx:" + vx + " vy:" + vy + " extra:" + extra + "extra2:" + extra2 + " Acceleration:" + acceleration +
                " vxAfterFriction:" + vitessexAfterFriction + " vyAfterFriction:" + vitesseyAfterFriction +
            " velocityXAfterFriction:" + velocityXAfterFriction + " velocityYAfterFriction:" + velocityYAfterFriction + "rage" + myRage);
        }
    }
}
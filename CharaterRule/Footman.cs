using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheDuke.CharaterRule
{

    class Footman : Figure
    {      
        public Footman()
        {
            this.Name = "FootMan";
            this.LocationX = 0;
            this.LocationY = 0;
            this.DEF = new Bitmap(@"D:\Games\TheDuke\Image\FootmanA.png");
            this.ATK = new Bitmap(@"D:\Games\TheDuke\Image\FootmanB.png");
            this.Side = 0;
            this.Face = "A";
        }
        public Footman(string name, int LocationX, int LocationY, int side, string face)
        {
            this.Name = name;
            this.LocationX = LocationX;
            this.LocationY = LocationY;
            this.DEF = new Bitmap(@"D:\Games\TheDuke\Image\FootmanA.png");
            this.ATK = new Bitmap(@"D:\Games\TheDuke\Image\FootmanB.png");
            this.Side = side;
            this.Face = face;
        }
        public override string CanMove()
        {
            if (this.Face == "A")
            {
                return "1,0|-1,0|0,1|0,-1";
            }
            else
            {
                if (this.Side ==1)
                {
                    return "1,1|-1,-1|1,-1|-1,1|-2,0";
                }
                else return "1,1|-1,-1|1,-1|-1,1|2,0";

            }
        }
    }
}

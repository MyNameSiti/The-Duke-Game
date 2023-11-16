using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDuke.CharaterRule
{
    class Duke : Figure
    {
        public Duke()
        {
            this.Name = "Duke";
            this.LocationX = 0;
            this.LocationY = 0;
            this.DEF = new Bitmap(@"D:\Games\TheDuke\Image\DukeA.png");
            this.ATK = new Bitmap(@"D:\Games\TheDuke\Image\DukeB.png");
            this.Side = 0;
            this.Face = "A";
        }
        public Duke(string name, int LocationX, int LocationY, int side, string face)
        {
            this.Name = name;
            this.LocationX = LocationX;
            this.LocationY = LocationY;
            this.DEF = new Bitmap(@"D:\Games\TheDuke\Image\DukeA.png");
            this.ATK = new Bitmap(@"D:\Games\TheDuke\Image\DukeB.png");
            this.Side = side;
            this.Face = face;
        }
        public override string CanMove()
        {
            if (this.Face == "A")
            {
                return "1,0|-1,0|2,0|-2,0|3,0|-3,0|4,0|-4,0|5,0|-5,0";
               
            }
            else  return "0,1|0,-1|0,2|0,-2|0,3|0,-3|0,4|0,-4|0,5|0,-5";
        }
    }

}

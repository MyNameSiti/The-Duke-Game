using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheDuke
{
   class Figure
    {
        public string Name { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public int Side { get; set; }
        public string Face { get; set; }
        public Image DEF { get; set; }
        public Image ATK { get; set; }
        public Figure()
        {
            this.Name = "A";
            this.LocationX = 0;
            this.LocationY = 0;
            this.DEF = new Bitmap(@"D:\Games\TheDuke\Image\FootmanA.png");
            this.ATK = new Bitmap(@"D:\Games\TheDuke\Image\FootmanB.png");
            this.Side = 1;
            this.Face = "A";
        }
        public Figure(string name, int LocationX, int LocationY, int side, string face)
        {
            this.Name = name;
            this.LocationX = LocationX;
            this.LocationY = LocationY;
            this.DEF = new Bitmap(@"D:\Games\TheDuke\Image\FootmanA.png");
            this.ATK = new Bitmap(@"D:\Games\TheDuke\Image\FootmanB.png");
            this.Side = side;
            this.Face = face;    
        }
        public virtual string CanMove()
        {
            return "";
        }

        public virtual string CanAttack()
        {
            return "";
        }
        public virtual string CanJump()
        {
            return "";
        }

        public virtual string CanCastSpell()
        {
            return "";
        }
    }


}

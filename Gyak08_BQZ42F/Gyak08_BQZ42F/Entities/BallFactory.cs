﻿using Gyak08_BQZ42F.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak08_BQZ42F.Entities
{
    public class BallFactory:IToyFactory
    {
        public Color BallColor { get; set; }
        public Toy CreateNew()
        {
            return new Ball(BallColor);
        }
    }
}

﻿using FreeWheels.PozyxLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeWheels.Tests
{
    public class TestResult
    {
        public string TestCase { get; set; }
        public string Category { get; set; }
        public DateTime Datetime { get; set; }
        public int TimeSpan { get; set; }

        public string[] Description { get; set; }

        public int TotalResults { get; set; }
        public int ZeroCount { get; set; }

        public Position realPostion { get; set; }
        public Position avgPostion { get; set; }

        public Position[] Results { get; set; }

        public int[] Distance2d { get; set; }
        public double MedianDistance2d { get; set; }
        public string ModeDistance2d { get; set; }
        public double AverageDistance2d { get; set; }
        public double StandardDeviationDistance2d { get; set; }

        public int[] Distance3d { get; set; }
        public double MedianDistance3d { get; set; }
        public string ModeDistance3d { get; set; }
        public double AverageDistance3d { get; set; }
        public double StandardDeviationDistance3d { get; set; }

        public int[] Deviations2d { get; set; }
        public double Median2d { get; set; }
        public string Mode2d { get; set; }
        public double Average2d { get; set; }
        public double StandardDeviation2d { get; set; }

        public int[] Deviations3d { get; set; }
        public double Median3d { get; set; }
        public string Mode3d { get; set; }
        public double Average3d { get; set; }
        public double StandardDeviation3d { get; set; }

        public TestResult(string testCase, string category)
        {
            this.TestCase = testCase;
            this.Category = category;
        }
    }
}

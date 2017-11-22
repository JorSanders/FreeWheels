﻿using FreeWheels.Classes;
using FreeWheels.Classes.PozyxApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace FreeWheels.Tests
{
    public class StandardDeviation
    {

        private Pozyx _Pozyx;
        private Position position;

        public StandardDeviation(Pozyx pozyx)
        {
            _Pozyx = pozyx;
            this.position = new Position();
        }

        public async Task<List<int>> coords()
        {

            _Pozyx.LetsGo();
            await Task.Delay(500);

            //Interval xyz results
            List<int> xList = new List<int>();
            List<int> yList = new List<int>();
            List<int> zList = new List<int>();
            float sumX = 0;
            float sumY = 0;
            float sumZ = 0;
            float averageX = 0;
            float averageY = 0;
            float averageZ = 0;

            //Output 
            String convType = "cm";     // mm, cm, m
            int convValue = 10;         // mm = 1, cm = 10, m = 1000

            //Mean Deviation
            float distanceFromMeanX;

            //Time
            int timeDelay = 200;
            int numResults = 0;
            DateTime dt = DateTime.Now.AddMilliseconds(5000);

            //start sign
            Debug.WriteLine("------");

            while (dt > DateTime.Now)
            {
                //adds x y and z to lists
                xList.Add(PositioningData.PosX());
                yList.Add(PositioningData.PosY());
                zList.Add(PositioningData.PosZ());
                //calculates the sum of x y and z
                sumX += PositioningData.PosX();
                sumY += PositioningData.PosY();
                sumZ += PositioningData.PosZ();
                numResults++;
                await Task.Delay(timeDelay);
            }
            //confirms finished result
            Debug.WriteLine("Adding positioning finished");

            //prints the x y and z results
            Debug.WriteLine("number of results " + numResults);
            for (int i = 0; i < numResults; i++)
            {
                Debug.Write(xList[i] + " ");
                Debug.Write(yList[i] + " ");
                Debug.WriteLine(zList[i]);
                await Task.Delay(100);
            }

            //calculates the average x y and z results
            averageX = sumX / numResults;
            averageY = sumY / numResults;
            averageZ = sumZ / numResults;

            Debug.WriteLine("----------------------------------------------");
            Debug.WriteLine("Last " + numResults + " results averages: ");
            Debug.Write("Location ");
            Debug.Write("x(" + convType + "): ");
            Debug.Write(averageX / convValue);
            Debug.Write(" y(" + convType + "): ");
            Debug.Write(averageY / convValue);  
            Debug.Write(" z(" + convType + "): ");
            Debug.WriteLine(averageZ / convValue);
            Debug.WriteLine("----------------------------------------------");
            

            return xList;
        }

        public double[] GetDeviations(List<Position> data)
        {
            double[] deviations = new double[data.Count];

            for (int i = 0; i < data.Count; i ++)
            {
                // D² = A² + B² + C²
                deviations[i] = Math.Sqrt(Math.Pow(data[i].X, 2) + Math.Pow(data[i].Y, 2) + Math.Pow(data[i].Z, 2));
            }

            return deviations;
        }

        public double GetStandardDeviation(List<Position> PosList)
        {
            //Convert Positions List
            double[] data = GetDeviations(PosList);

            int size = data.Length;
            double total = data.Sum();
            double average = total / size;

            double[] deviations = new double[size];

            // Calc Deviation on Average
            for(int i = 0; i < size; i++)
            {
                deviations[i] = Math.Pow(data[i] - average, 2);
            }

            double deviationsTotal = deviations.Sum();
            double averageDeviation = deviationsTotal / size;
            double standardDeviation = Math.Sqrt(averageDeviation);

            return standardDeviation;

        }

    }
}

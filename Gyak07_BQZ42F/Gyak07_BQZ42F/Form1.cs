﻿using Gyak07_BQZ42F.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyak07_BQZ42F
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        Random rnd = new Random(1234);
        public Form1()
        {
            InitializeComponent();

            Population = GetPopulation(@"C:\Temp\nép.csv");
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            for (int year = 2005; year <= 2024; year++)
            {

                for (int i = 0; i < Population.Count; i++)
                {

                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
            List<Person> GetPopulation(string csvpath)
            {
                List<Person> population = new List<Person>();

                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        population.Add(new Person()
                        {
                            BirthYear = int.Parse(line[0]),
                            Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                            NbrOfChildren = int.Parse(line[2])
                        });
                    }
                }

                return population;
            }
            List<BirthProbability> GetBirthProbabilities(string csvpath)
            {
                List<BirthProbability> birthprob = new List<BirthProbability>();

                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        birthprob.Add(new BirthProbability()
                        {
                            Age = int.Parse(line[0]),
                            NbrOfChildren = int.Parse(line[1]),
                            P = double.Parse(line[3])
                        });
                    }
                }

                return birthprob;
            }
            List<DeathProbability> GetDeathProbabilities(string csvpath)
            {
                List<DeathProbability> deathprob = new List<DeathProbability>();

                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine().Split(';');
                        deathprob.Add(new DeathProbability()
                        {
                            Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                            Age = int.Parse(line[1]),
                            P = double.Parse(line[2])
                        });
                    }
                }

                return deathprob;
            }
        }

    }
}

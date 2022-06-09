using System.Diagnostics.Tracing;

namespace Practica_1year_ants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Commands:\nnext - starts next day\nstop - stops program\ninfo - info about objects");
            string? comand;
            string col; //TODO: cleanup
            string inf; //TODO: cleanup
            int i = 0;
            int dry = 11;
            //create colonies
            List<Colony> colonies = new List<Colony>
            {
                new("красные", new Queen("София", new[] {3, 4}, new[] {3, 4}, 1, 0, 25, 8, 20), new []{14, 9, 1}),
                new("зеленые",
                    new Queen("Елизавета", new[] {2, 4}, new[] {1, 3}, 2, 0, 18, 5, 22), new []{17, 7, 1})
            };
            // cделать кучи
            Heap[] heaps =
            {
                new(100, 100, 100, 100), new(100, 100, 100, 100), new(100, 100, 100, 100),
                new(100, 100, 100, 100), new(100, 100, 100, 100)
            };
            for (int j = 0; j < colonies.Count; j++)
            {
                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Workers.Add(new Worker("легендарный", 1, 1, 1, 2, 3, 3));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Workers.Add(new Worker("старший", 2, 2, 1, 2, 1, 1));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Workers.Add(new Worker("легендарный", 3, 1, 2, 2, 2, 3));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Worker2.Add(new Worker("легендарный крепкий", 1, 2, 2, 2, 1,
                            3, 1, 1));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Worker2
                            .Add(new Worker("легендарный бригадир", 2, 2, 2, 2, 1, 3));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Worker2
                            .Add(new Worker("старший бригадир", 3, 1, 2, 2, 1, 1));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "обычный", 1));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "старший", 2));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "продвинутый", 3, 2));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Warior2
                            .Add(new Warrior(0, "продвинутый худой", 1, 2, 1, 1, 0));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Warior2.Add(new Warrior(1, "обычный аномальный", 2));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Warior2.Add(new Warrior(0, "старший сосредоточенный", 3, 1, 1,
                            1, 1, 2));
                    }
                }
            }

            // create specials

            Random random = new Random();
            int aphidStartDay = random.Next(0, 7);

            Console.WriteLine("=====");

            while (i < dry)
            {
                comand = Console.ReadLine();
                if (comand == "next")
                {
                    Console.WriteLine($"Day {i}  (Until dry season {dry - i} days)");
                    if (aphidStartDay < i && i < aphidStartDay + 5)
                    {
                        Console.WriteLine($"Действует эффект \"Тля\" , осталось {aphidStartDay + 5 - i} дней ");
                    }

                    foreach (Colony j in colonies)
                    {
                        // a = j; TODO: cleanup
                        Console.WriteLine($"=====\nКолония \"{j.Name}\":\n==== Королева \"{j.Queen.Name}\"");
                        Console.WriteLine(
                            $"== Популяция:\n+Воины = {j.Warriors.Count + j.Warior2.Count - 2};\n+Рабочие = {j.Workers.Count + j.Worker2.Count - 2};\n" +
                            $"+Особые = {j.Scarab.Life + j.Termite.Life + j.Butterfly.Life}\n" +
                            $"= Ресурсы: в = {j.branch}, к = {j.stone}, л = {j.leaf}, р = {j.water}\n====");
                    }

                    for (int j = 0; j < 5; j++)
                    {
                        Console.WriteLine(
                            $"Куча {j + 1}: в = {heaps[j].Branch}, к = {heaps[j].Stone}, л = {heaps[j].Leaf}, р = {heaps[j].Water}");
                    }

                    // распределение по кучам
                    for (int j = 0; j < colonies.Count; j++)
                    {
                        for (int c = 0; c < colonies[j].Workers.Count; c++)
                        {
                            Worker n = colonies[j].Workers[c];
                            heaps[random.Next(0, 5)].Workers.Add(n);
                        }

                        for (int c = 0; c < colonies[j].Worker2.Count; c++)
                        {
                            Worker n = colonies[j].Worker2[c];
                            heaps[random.Next(0, 5)].Workers.Add(n);
                        }

                        for (int c = 0; c < colonies[j].Warriors.Count; c++)
                        {
                            Warrior n = colonies[j].Warriors[c];
                            heaps[random.Next(0, 5)].Wariors.Add(n);
                        }

                        for (int c = 0; c < colonies[j].Warior2.Count; c++)
                        {
                            Warrior n = colonies[j].Warior2[c];
                            heaps[random.Next(0, 5)].Wariors.Add(n);
                        }


                        if (colonies[j].Butterfly.Life != 0)
                        {
                            Butterfly n = colonies[j].Butterfly;
                            heaps[random.Next(0, 5)].Butterfly = n;
                        }
                    }

                    for (int k = 0; k < heaps.Length; k++)
                    {
                        for (int w = 0; w < heaps[k].Wariors.Count; w++)
                        {
                            int r = random.Next(0, 2);
                            if (r == 0)
                            {
                                int ch = random.Next(0, heaps[k].Workers.Count);
                                if (heaps[k].Wariors[w].Colony == 3)
                                {
                                    heaps[k].Wariors[w].Damage += 1;
                                    heaps[k].Wariors[w].Fight(heaps[k].Workers[ch], null);
                                    heaps[k].Wariors[w].Damage -= 1;
                                }

                                if (heaps[k].Wariors[w].Colony != 3)
                                {
                                    heaps[k].Wariors[w].Fight(heaps[k].Workers[ch], null);
                                }

                                if (heaps[k].Workers[ch].HP == 0)
                                {
                                    heaps[k].Workers[ch] = null;
                                    heaps[k].Workers.RemoveAt(ch);
                                }
                            }

                            if (r == 1)
                            {
                                int ch = random.Next(0, heaps[k].Wariors.Count);
                                if (heaps[k].Wariors[w].Colony == 3)
                                {
                                    heaps[k].Wariors[w].Damage += 1;
                                    heaps[k].Wariors[w].Fight(null, heaps[k].Wariors[ch]);
                                    heaps[k].Wariors[w].Damage -= 1;
                                }

                                if (heaps[k].Wariors[w].Colony != 3)
                                {
                                    heaps[k].Wariors[w].Fight(null, heaps[k].Wariors[ch]);
                                }

                                if (heaps[k].Wariors[ch].HP == 0)
                                {
                                    heaps[k].Wariors[ch] = null;
                                    heaps[k].Wariors.RemoveAt(ch);
                                }

                                if (heaps[k].Wariors[w].HP == 0) //TODO: IndexOutOfRange
                                {
                                    heaps[k].Wariors[w] = null;
                                    heaps[k].Wariors.RemoveAt(w);
                                }
                            }
                        }

                        for (int w = 0; w < heaps[k].Workers.Count; w++)
                        {
                            if (i < 8) // хомяк?
                            {
                                heaps[k].Workers[w].Count += 1;
                            }

                            int safe = heaps[k].Workers[w].Count;
                            if (heaps[k].Branch > heaps[k].Workers[w].Branch & heaps[k].Workers[w].Count > 0)
                            {
                                heaps[k].Branch -= heaps[k].Workers[w].Branch;
                                heaps[k].Workers[w].Count -= heaps[k].Workers[w].Branch;
                                for (int l = 0; l < colonies[heaps[k].Workers[w].Num].Workers.Count; l++)
                                {
                                    if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                    {
                                        colonies[c].Branch(heaps[k].Workers[w].Branch);
                                    }
                                }
                            }

                            if (heaps[k].Branch < heaps[k].Workers[w].Branch & heaps[k].Workers[w].Count > 0 &
                                heaps[k].Branch > 0)
                            {
                                heaps[k].Branch = 0;
                                heaps[k].Workers[w].Count -= heaps[k].Branch;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Branch(heaps[k].Branch);
                                        }
                                    }
                                }
                            }

                            if (heaps[k].Leaf > heaps[k].Workers[w].Leaf & heaps[k].Workers[w].Count > 0)
                            {
                                heaps[k].Leaf -= heaps[k].Workers[w].Leaf;
                                heaps[k].Workers[w].Count -= heaps[k].Workers[w].Leaf;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Leaf(heaps[k].Workers[w].Leaf);
                                        }
                                    }
                                }
                            }

                            if (heaps[k].Leaf < heaps[k].Workers[w].Leaf & heaps[k].Workers[w].Count > 0 &
                                heaps[k].Leaf > 0)
                            {
                                heaps[k].Leaf = 0;
                                heaps[k].Workers[w].Count -= heaps[k].Leaf;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Leaf(heaps[k].Leaf);
                                        }
                                    }
                                }
                            }

                            if (heaps[k].Stone > heaps[k].Workers[w].Stone & heaps[k].Workers[w].Count > 0)
                            {
                                heaps[k].Stone -= heaps[k].Workers[w].Stone;
                                heaps[k].Workers[w].Count -= heaps[k].Workers[w].Stone;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Stone(heaps[k].Workers[w].Stone);
                                        }
                                    }
                                }
                            }

                            if (heaps[k].Stone < heaps[k].Workers[w].Stone & heaps[k].Workers[w].Count > 0 &
                                heaps[k].Stone > 0)
                            {
                                heaps[k].Stone = 0;
                                heaps[k].Workers[w].Count -= heaps[k].Stone;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Stone(heaps[k].Stone);
                                        }
                                    }
                                }
                            }

                            if (heaps[k].Water > heaps[k].Workers[w].Water & heaps[k].Workers[w].Count > 0)
                            {
                                heaps[k].Water -= heaps[k].Workers[w].Water;
                                heaps[k].Workers[w].Count -= heaps[k].Workers[w].Water;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Water(heaps[k].Workers[w].Water);
                                        }
                                    }
                                }
                            }

                            if (heaps[k].Water < heaps[k].Workers[w].Water & heaps[k].Workers[w].Count > 0 &
                                heaps[k].Water > 0)
                            {
                                heaps[k].Water = 0;
                                heaps[k].Workers[w].Count -= heaps[k].Water;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Workers.Count; l++)
                                    {
                                        if (colonies[c].Workers[l].Num == heaps[k].Workers[w].Num)
                                        {
                                            colonies[c].Water(heaps[k].Water);
                                        }
                                    }
                                }
                            }

                            heaps[k].Workers[w].Count = safe;
                        }

                        if (heaps[k].Scarab != null)
                        {
                            if (heaps[k].Scarab.HP != 0)
                            {
                                int save = heaps[k].Scarab.Count;
                                if (heaps[k].Branch > heaps[k].Scarab.Branch & heaps[k].Scarab.Count > 0)
                                {
                                    heaps[k].Branch -= heaps[k].Scarab.Branch;
                                    heaps[k].Scarab.Count -= heaps[k].Scarab.Branch;
                                    colonies[0].Branch(heaps[k].Scarab.Branch);
                                }

                                if (heaps[k].Branch < heaps[k].Scarab.Branch & heaps[k].Scarab.Count > 0 &
                                    heaps[k].Branch > 0)
                                {
                                    heaps[k].Branch = 0;
                                    heaps[k].Scarab.Count -= heaps[k].Branch;
                                    colonies[0].Branch(heaps[k].Branch);
                                }

                                if (heaps[k].Leaf > heaps[k].Scarab.Leaf & heaps[k].Scarab.Count > 0)
                                {
                                    heaps[k].Leaf -= heaps[k].Scarab.Leaf;
                                    heaps[k].Scarab.Count -= heaps[k].Scarab.Leaf;
                                    colonies[0].Leaf(heaps[k].Scarab.Leaf);
                                }

                                if (heaps[k].Leaf < heaps[k].Scarab.Leaf & heaps[k].Scarab.Count > 0 &
                                    heaps[k].Leaf > 0)
                                {
                                    heaps[k].Leaf = 0;
                                    heaps[k].Scarab.Count -= heaps[k].Leaf;
                                    colonies[0].Leaf(heaps[k].Leaf);
                                }

                                if (heaps[k].Stone > heaps[k].Scarab.Stone & heaps[k].Scarab.Count > 0)
                                {
                                    heaps[k].Stone -= heaps[k].Scarab.Stone;
                                    heaps[k].Scarab.Count -= heaps[k].Scarab.Stone;
                                    colonies[0].Stone(heaps[k].Scarab.Stone);
                                }

                                if (heaps[k].Stone < heaps[k].Scarab.Stone & heaps[k].Scarab.Count > 0 &
                                    heaps[k].Stone > 0)
                                {
                                    heaps[k].Stone = 0;
                                    heaps[k].Scarab.Count -= heaps[k].Stone;
                                    colonies[0].Stone(heaps[k].Stone);
                                }

                                if (heaps[k].Water > heaps[k].Scarab.Water & heaps[k].Scarab.Count > 0)
                                {
                                    heaps[k].Water -= heaps[k].Scarab.Water;
                                    heaps[k].Scarab.Count -= heaps[k].Scarab.Water;
                                    colonies[0].Water(heaps[k].Scarab.Water);
                                }

                                if (heaps[k].Water < heaps[k].Scarab.Water & heaps[k].Scarab.Count > 0 &
                                    heaps[k].Water > 0)
                                {
                                    heaps[k].Water = 0;
                                    heaps[k].Scarab.Count -= heaps[k].Water;
                                    colonies[0].Water(heaps[k].Water);
                                }

                                heaps[k].Scarab.Count = save;
                            }
                        }

                        if (heaps[k].Butterfly != null)
                        {
                            if (heaps[k].Butterfly.HP != 0)
                            {
                                int save = heaps[k].Butterfly.Count;
                                if (heaps[k].Branch > heaps[k].Butterfly.Branch & heaps[k].Butterfly.Count > 0)
                                {
                                    heaps[k].Branch -= heaps[k].Butterfly.Branch;
                                    heaps[k].Butterfly.Count -= heaps[k].Butterfly.Branch;
                                    colonies[0].Branch(heaps[k].Butterfly.Branch);
                                }

                                if (heaps[k].Branch < heaps[k].Butterfly.Branch & heaps[k].Butterfly.Count > 0 &
                                    heaps[k].Branch > 0)
                                {
                                    heaps[k].Branch = 0;
                                    heaps[k].Butterfly.Count -= heaps[k].Branch;
                                    colonies[0].Branch(heaps[k].Branch);
                                }

                                if (heaps[k].Leaf > heaps[k].Butterfly.Leaf & heaps[k].Butterfly.Count > 0)
                                {
                                    heaps[k].Leaf -= heaps[k].Butterfly.Leaf;
                                    heaps[k].Butterfly.Count -= heaps[k].Butterfly.Leaf;
                                    colonies[0].Leaf(heaps[k].Butterfly.Leaf);
                                }

                                if (heaps[k].Leaf < heaps[k].Butterfly.Leaf & heaps[k].Butterfly.Count > 0 &
                                    heaps[k].Leaf > 0)
                                {
                                    heaps[k].Leaf = 0;
                                    heaps[k].Butterfly.Count -= heaps[k].Leaf;
                                    colonies[0].Leaf(heaps[k].Leaf);
                                }

                                if (heaps[k].Stone > heaps[k].Butterfly.Stone & heaps[k].Butterfly.Count > 0)
                                {
                                    heaps[k].Stone -= heaps[k].Butterfly.Stone;
                                    heaps[k].Butterfly.Count -= heaps[k].Butterfly.Stone;
                                    colonies[0].Stone(heaps[k].Butterfly.Stone);
                                }

                                if (heaps[k].Stone < heaps[k].Butterfly.Stone & heaps[k].Butterfly.Count > 0 &
                                    heaps[k].Stone > 0)
                                {
                                    heaps[k].Stone = 0;
                                    heaps[k].Butterfly.Count -= heaps[k].Stone;
                                    colonies[0].Stone(heaps[k].Stone);
                                }

                                if (heaps[k].Water > heaps[k].Butterfly.Water & heaps[k].Butterfly.Count > 0)
                                {
                                    heaps[k].Water -= heaps[k].Butterfly.Water;
                                    heaps[k].Butterfly.Count -= heaps[k].Butterfly.Water;
                                    colonies[0].Water(heaps[k].Butterfly.Water);
                                }

                                if (heaps[k].Water < heaps[k].Butterfly.Water & heaps[k].Butterfly.Count > 0 &
                                    heaps[k].Water > 0)
                                {
                                    heaps[k].Water = 0;
                                    heaps[k].Butterfly.Count -= heaps[k].Water;
                                    colonies[0].Water(heaps[k].Water);
                                }

                                heaps[k].Butterfly.Count = save;
                            }
                        }

                        // if (heaps[k].Termite != null)
                        // {
                        //     int r = random.Next(0, 4);
                        //     if (r == 0)
                        //     {
                        //         int ch = random.Next(0, heaps[k].Workers.Count);
                        //         heaps[k].Termite.Fight(heaps[k].Workers[ch], null, null, null);
                        //         if (heaps[k].Workers[ch].HP == 0)
                        //         {
                        //             heaps[k].Workers[ch] = null;
                        //             heaps[k].Workers.RemoveAt(ch);
                        //         }
                        //     }
                        //
                        //     if (r == 1)
                        //     {
                        //         int ch = random.Next(0, heaps[k].Wariors.Count);
                        //         heaps[k].Termite.Fight(null, heaps[k].Wariors[ch], null, null);
                        //         if (heaps[k].Wariors[ch].HP == 0)
                        //         {
                        //             heaps[k].Wariors[ch] = null;
                        //             heaps[k].Wariors.RemoveAt(ch);
                        //         }
                        //
                        //         if (heaps[k].Termite.HP == 0)
                        //         {
                        //             heaps[k].Termite = null;
                        //         }
                        //     }
                        //
                        //     if (r == 2 & heaps[k].Scarab != null)
                        //     {
                        //         if (heaps[k].Scarab.HP != 0)
                        //         {
                        //             heaps[k].Termite.Fight(null, null, null, heaps[k].Scarab);
                        //         }
                        //     }
                        //
                        //     if (r == 3 & heaps[k].Butterfly != null)
                        //     {
                        //         if (heaps[k].Butterfly.HP != 0)
                        //         {
                        //             heaps[k].Termite.Fight(null, null, heaps[k].Butterfly, null);
                        //         }
                        //     }
                        // }
                    }

                    for (int j = 0; j < colonies.Count; j++)
                    {
                        for (int k = 0; k < colonies[j].Workers.Count; k++)
                        {
                            if (colonies[j].Workers[k] == null)
                            {
                                colonies[j].Workers.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < colonies[j].Worker2.Count; k++)
                        {
                            if (colonies[j].Worker2[k] == null)
                            {
                                colonies[j].Worker2.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < colonies[j].Warriors.Count; k++)
                        {
                            if (colonies[j].Warriors[k] == null)
                            {
                                colonies[j].Warriors.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < colonies[j].Warior2.Count; k++)
                        {
                            if (colonies[j].Warior2[k] == null)
                            {
                                colonies[j].Warior2.RemoveAt(k);
                            }
                        }
                    }

                    Reproduction(colonies, colonies.Count);

                    Console.WriteLine();
                    Console.WriteLine("________________________");
                    Console.WriteLine();
                }

                else if (comand == "info")
                {
                    Console.WriteLine(
                        $"Введите номер колонии (1 - {colonies.Count})  и тип требуемых данных (colony, worker, warrior, special)");
                    string[] param = Console.ReadLine().Split();
                    colonies[Convert.ToInt32(param[0]) - 1].GetInfoColony(param[1]);
                }

                else if (comand == "stop")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Команда не распознана. Попробуйте ещё раз");
                }
            }
        }

        static void Reproduction(List<Colony> colonies, int count)
        {
            Random random = new Random();
            for (int colony = 0; colony < count; colony++)
            {
                if (!colonies[colony].SubColony)
                {
                    if (colonies[colony].Queen.Count == 0 && colonies[colony].Queen.QueenDoughter[0] <=
                        colonies[colony].Queen.QueenDoughter[1])
                    {
                        colonies[colony].Queen.Start = random.Next(colonies[colony].Queen.QueenDoughter[0],
                            colonies[colony].Queen.QueenDoughter[1]);
                        colonies[colony].Queen.Count++;
                    }
                    else if (colonies[colony].Queen.Count < colonies[colony].Queen.Start)
                    {
                        colonies[colony].Queen.Count++;
                    }
                    else if (colonies[colony].Queen.Count >= colonies[colony].Queen.Start + random.Next(0, 8))
                    {
                        colonies.Add(new Colony(CreateColonyName(random),
                            new Queen(CreateQueenName(random), new int[] {2, random.Next(2, 5)},
                                new int[] {1, random.Next(2, 5)}, colonies[colony].Queen.Colony,
                                // count, 
                                1, 3, 1, 1),
                            new int[] {random.Next(3, 10), random.Next(2, 5), random.Next(1, 2)}, true));
                        count += 1;
                        AddAnts(colonies[^1], colonies[colony], random, count);
                        colonies[colony].Queen.Count = 0;
                        colonies[colony].Queen.QueenDoughter[0]++;
                    }
                }
            }
        }

        static void AddAnts(Colony colony, Colony parentalColony, Random random, int colonyNum)
        {
            for (int worker = 0; worker < colony.Population![0]; worker++)
            {
                colony.Workers.Add(
                    (Worker) parentalColony.Workers[random.Next(0, parentalColony.Workers.Count)].Clone());
                colony.Workers[worker].Colony = colonyNum;
            }

            for (int warrior = 0; warrior < colony.Population[1]; warrior++)
            {
                colony.Warriors.Add((Warrior) parentalColony.Warriors[random.Next(0, parentalColony.Warriors.Count)]
                    .Clone());
                colony.Warriors[warrior].Colony = colonyNum;
            }

            for (int special = 0; special < colony.Population[2]; special++)
            {
                colony.Specials.Add((Special) parentalColony.Specials[random.Next(0, parentalColony.Specials.Count)]
                    .Clone());
                colony.Specials[special].Colony = colonyNum;
            }
        }

        static String CreateColonyName(Random random)
        {
            return create_name(random);
        }

        static String CreateQueenName(Random random)
        {
            return create_name(random);
        }

        static string create_name(Random random)
        {
            string[] names =
            {
                "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у",
                "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"
            };
            string n = names[random.Next(0, 32)];
            for (int s = 0; s < random.Next(1, 15); s++)
            {
                n = n + names[random.Next(0, 32)];
            }

            return n;
        }


        class Ant : ICloneable
        {
            public String Tags;
            public int HP;
            public int Armor;
            public int Damage;
            public int Colony;
            public List<string>? Bonus;
            public bool aphid = false;


            public Ant(int colony, string tags = "", int damage = 0, int armor = 0,
                int hp = 1, List<string>? bonus = null)
            {
                HP = hp;
                Armor = armor;
                Damage = damage;
                Colony = colony;
                Tags = tags;
                Bonus = bonus;
            }

            public object Clone()
            {
                return MemberwiseClone();
            }
        }

        class Queen : Ant
        {
            public string Name;
            public int[] Cycle;
            public int[] QueenDoughter;
            public int Start;
            public int Count;

            public Queen(string name, int[] cycle, int[] queenDoughter, int colony, int start, int hp = 1,
                int armor = 0,
                int damage = 0) : base(colony, damage: damage, armor: armor, hp: hp)
            {
                Name = name;
                Cycle = cycle;
                QueenDoughter = queenDoughter;
                Start = start;
                Count = new Random().Next(Cycle[0], Cycle[1]);
            }

            public void Grow(Colony colony)
            {
                if (Count < Cycle[0])
                {
                    Count += 1;
                }
                else if (Count >= Cycle[0] && Count <= Cycle[1])
                {
                    Random random = new Random();
                    if (random.Next(0, 20) > 10)
                    {
                        int type = random.Next(0, 3);
                        if (type == 0)
                        {
                            colony.Workers.Add(
                                (Worker) colony.Workers[random.Next(0, colony.Workers.Count - 1)].Clone());
                        }
                        else if (type == 1)
                        {
                            colony.Warriors.Add(
                                (Warrior) colony.Workers[random.Next(0, colony.Workers.Count - 1)].Clone());
                        }
                        else if (type == 2)
                        {
                            colony.Specials.Add((Special) colony.Specials[random.Next(0, colony.Specials.Count - 1)]
                                .Clone());
                        }

                        Count = 0;
                    }
                }
            }
        }

        class Worker : Ant
        {
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;
            public int Count;

            public Worker(String tags, int colony, int leaf, int branch, int stone, int water, int count,
                int hp = 1, int armor = 0, int damage = 0) : base(colony, tags,
                damage: damage, armor: armor, hp: hp)
            {
                Leaf = leaf;
                Branch = branch;
                Stone = stone;
                Water = water;
                Count = count;
            }
        }

        class Warrior : Ant
        {
            public int AttackNum; // укусы
            public int Bad;
            public int TargetNum;


            public Warrior(int bad, String tags, int colony, int target = 1, int attackNum = 1, int hp = 1,
                int armor = 1, int damage = 1, List<String>? bonus = null) : base(colony, tags, damage: damage,
                armor: armor, hp: hp, bonus: bonus)
            {
                AttackNum = attackNum;
                Bad = bad;
                TargetNum = target;
            }

            public void Fight(Worker worker, Warrior warrior, Special special)
            {
                if (this.aphid)
                {
                    return;
                }

                if (worker != null)
                {
                    if (worker.Colony != Colony || Bad == 1)
                    {
                        if (worker.Armor >= Damage)
                        {
                            worker.Armor -= Damage;
                        }
                        else
                        {
                            worker.HP -= Damage - worker.Armor;
                            worker.Armor = 0;
                        }

                        if (Armor >= worker.Damage)
                        {
                            Armor -= worker.Damage;
                        }
                        else
                        {
                            HP -= worker.Damage - Armor;
                            Armor = 0;
                        }
                    }
                }

                if (warrior != null)
                {
                    if (warrior.Colony != Colony || Bad == 1)
                    {
                        if (warrior.Armor >= Damage)
                        {
                            warrior.Armor -= Damage;
                        }
                        else
                        {
                            warrior.HP -= Damage - warrior.Armor;
                            warrior.Armor = 0;
                        }

                        if (Armor >= warrior.Damage)
                        {
                            Armor -= warrior.Damage;
                        }
                        else
                        {
                            HP -= warrior.Damage - Armor;
                            Armor = 0;
                        }
                    }
                }

                if (special != null)
                {
                    if (!special.Bonus.Contains("не может быть атакован войнами"))
                    {
                        if (special.Armor >= Damage)
                        {
                            special.Armor -= Damage;
                        }
                        else
                        {
                            special.HP -= Damage - special.Armor;
                            special.Armor = 0;
                        }

                        if (Armor >= special.Damage)
                        {
                            Armor -= special.Damage;
                        }
                        else
                        {
                            HP -= special.Damage - Armor;
                            Armor = 0;
                        }
                    }
                    else if (special.Tags.Contains("мирный"))
                    {
                        if (special.Colony != Colony || Bad == 1)
                        {
                            if (special.Armor >= Damage)
                            {
                                special.Armor -= Damage;
                            }
                            else
                            {
                                special.HP -= Damage - special.Armor;
                                special.Armor = 0;
                            }
                        }
                    }
                }
            }
        }


        class Special : Warrior
        {
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;
            public int Count;

            public Special(int leaf, int branch, int stone, int water, int count, int bad, string tags, int colony,
                int target = 1, int attackNum = 1, int hp = 1, int armor = 1, int damage = 1,
                List<String>? bonus = null) : base(bad, tags, colony,
                target, attackNum, hp, armor, damage)
            {
                Leaf = leaf;
                Branch = branch;
                Stone = stone;
                Water = water;
                Count = count;
            }
        }

        struct Colony
        {
            public string Name;
            public int leaf;
            public int branch;
            public int stone;
            public int water;
            public Queen Queen;
            public List<Worker> Workers;
            public List<Warrior> Warriors;
            public List<Special> Specials;
            public bool SubColony;
            public int[]? Population;

            public void Leaf(int a)
            {
                leaf += a;
            }

            public void Branch(int a)
            {
                branch += a;
            }

            public void Stone(int a)
            {
                stone += a;
            }

            public void Water(int a)
            {
                water += a;
            }

            public Colony(string name, Queen queen, int[] population, bool subColony = false)
            {
                Name = name;
                Queen = queen;
                Population = population;
                Workers = new List<Worker>();
                Warriors = new List<Warrior>();
                Specials = new List<Special>();
                branch = 0;
                leaf = 0;
                stone = 0;
                water = 0;
                SubColony = subColony;
            }

            public void GetInfoColony(string? type)
            {
                switch (type)
                {
                    case "colony":
                        Console.WriteLine($"Queen of {Name} is {Queen.Name}");
                        Console.WriteLine(
                            $"Population - {Warriors.Count + Workers.Count + Specials.Count}");
                        GetInfoColony("workers");
                        GetInfoColony("warrior");
                        GetInfoColony("special");
                        break;
                    case "worker":
                    {
                        Console.WriteLine("======Рабочие");
                        foreach (var worker1 in Workers)
                        {
                            Console.WriteLine($"---{worker1.Tags}");
                            Console.WriteLine(
                                $"--- состояние HP={worker1.HP},Armor={worker1.Armor},Damage={worker1.Damage}");
                            Console.WriteLine("========");
                        }

                        break;
                    }
                    case "warrior":
                    {
                        Console.WriteLine("======Воины");
                        foreach (var warrior1 in Warriors)
                        {
                            Console.WriteLine($"---{warrior1.Tags}");
                            Console.WriteLine(
                                $"--- состояние HP={warrior1.HP},Armor={warrior1.Armor},Damage={warrior1.Damage}");
                            if (warrior1.Bonus != null)
                            {
                                foreach (var bonus in warrior1.Bonus)
                                {
                                    Console.WriteLine($"---- дополнительный параметр {bonus}");
                                }
                            }

                            Console.WriteLine("========");
                        }

                        break;
                    }
                    case "special":
                    {
                        Console.WriteLine("======Особые");
                        foreach (var special in Specials)
                        {
                            Console.WriteLine($"---{special.Tags}");
                            Console.WriteLine(
                                $"--- состояние HP={special.HP},Armor={special.Armor},Damage={special.Damage}");
                            if (special.Bonus != null)
                            {
                                foreach (var bonus in special.Bonus)
                                {
                                    Console.WriteLine($"---- дополнительный параметр {bonus}");
                                }
                            }

                            Console.WriteLine("========");
                        }

                        break;
                    }
                }
            }
        }

        struct Heap
        {
            public List<Warrior> Wariors;
            public List<Worker> Workers;
            public List<Special> Specials;
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;

            public Heap(int leaf, int branch, int stone, int water) : this()
            {
                Leaf = leaf;
                Branch = branch;
                Stone = stone;
                Water = water;
                Workers = new List<Worker>();
                Wariors = new List<Warrior>();
                Specials = new List<Special>();
            }
        }
    }
}
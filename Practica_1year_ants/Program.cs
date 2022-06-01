namespace Practica_1year_ants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для управления программой используются команды :");
            Console.WriteLine(
                "<информация> - выводит на экран информацию о колонии, отдельных муровьях или особых насекомых");
            Console.WriteLine("<старт> - начинает следующий день");
            Console.WriteLine("<стоп> - прекращает работу программы");
            string comand;
            string col;
            string inf;
            int i = 0;
            List<Colony> colonies = new List<Colony>
            {
                new("чёрные", new Queen("Амалия", new[] {2, 4}, new[] {3, 4}, 1, 1, 0, 3, 1, 1)),
                new("красные",
                    new Queen("Гвиндолина", new[] {2, 3}, new[] {3, 4}, 2, 2, 0, 2, 0, 2)),
                new("рыжие",
                    new Queen("Евангелина", new[] {1, 3}, new[] {1, 5}, 3, 3, 0, 5, 2, 0))
            };
            int count = 3;
            Kucha[] kucha =
            {
                new(100, 100, 100, 100), new(100, 100, 100, 100), new(100, 100, 100, 100),
                new(100, 100, 100, 100), new(100, 100, 100, 100)
            };
            for (int j = 0; j < count; j++)
            {
                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Worker.Add(new Worker("легендарный", 1, colonies[j].Queen.Num, 1, 1, 2, 3, 3));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Worker.Add(new Worker("старший", 2, colonies[j].Queen.Num, 2, 1, 2, 1, 1));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Worker.Add(new Worker("легендарный", 3, colonies[j].Queen.Num, 1, 2, 2, 2, 3));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Worker2.Add(new Worker("легендарный крепкий", 1, colonies[j].Queen.Num, 2, 2, 2, 1,
                            3, 1, 1));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Worker2
                            .Add(new Worker("легендарный бригадир", 2, colonies[j].Queen.Num, 2, 2, 2, 1, 3));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Worker2
                            .Add(new Worker("старший бригадир", 3, colonies[j].Queen.Num, 1, 2, 2, 1, 1));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Warior.Add(new Warior(0, "обычный", 1, colonies[j].Queen.Num));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Warior.Add(new Warior(0, "старший", 2, colonies[j].Queen.Num));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Warior.Add(new Warior(0, "продвинутый", 3, colonies[j].Queen.Num, 2));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Warior2
                            .Add(new Warior(0, "продвинутый худой", 1, colonies[j].Queen.Num, 2, 1, 1, 0));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Warior2.Add(new Warior(1, "обычный аномальный", 2, colonies[j].Queen.Num));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Warior2.Add(new Warior(0, "старший сосредоточенный", 3, colonies[j].Queen.Num, 1, 1,
                            1, 1, 2));
                    }
                }
            }

            Colony a = colonies[0];
            a.Scarab = new Scarab("не может быть атакован войнами", 1, 0, 1, 3, 3, 3, 3, 3);
            a.Termite = new Termite("не может быть атакован войнами", 0, 0, 2);
            a.Butterfly = new Butterfly("не может быть атакован войнами\n урон всех воинов увеличен на 1", 0, 0, 3, 0,
                0, 2, 0, 2);
            colonies[0] = a;
            a = colonies[1];
            a.Scarab = new Scarab("не может быть атакован войнами", 0, 0, 1, 3, 3, 3, 3, 3);
            a.Termite = new Termite("не может быть атакован войнами", 1, 0, 2);
            a.Butterfly = new Butterfly("не может быть атакован войнами\n урон всех воинов увеличен на 1", 0, 0, 3, 0,
                0, 2, 0, 2);
            colonies[1] = a;
            a = colonies[2];
            a.Scarab = new Scarab("не может быть атакован войнами", 0, 0, 1, 3, 3, 3, 3, 3);
            a.Termite = new Termite("не может быть атакован войнами", 0, 0, 2);
            a.Butterfly = new Butterfly("не может быть атакован войнами\n урон всех воинов увеличен на 1", 1, 0, 3, 0,
                0, 2, 0, 2);
            colonies[2] = a;
            Random random = new Random();

            Console.WriteLine("________________________");
            Console.WriteLine();

            while (i < 10)
            {
                comand = Console.ReadLine();
                if (comand == "старт")
                {
                    Console.WriteLine($"День {i}  (До засухи {10 - i} дней)");
                    if (i < 8)
                    {
                        Console.WriteLine($"Действует эфект \"Шелкопряд\" , ещё {8 - i} дней ");
                    }

                    Console.WriteLine();
                    foreach (Colony j in colonies)
                    {
                        // a = j; TODO: cleanup
                        Console.WriteLine($"Колония \"{j.Name}\" :");
                        Console.WriteLine($"---- Королева \"{j.Queen.Name}\"");
                        Console.WriteLine(
                            $"---- Популяция : Воины - {j.Warior.Count + j.Warior2.Count - 2} ; Рабочие - {j.Worker.Count + j.Worker2.Count - 2} ; Особые - {j.Scarab.Life + j.Termite.Life + j.Butterfly.Life}");
                        Console.WriteLine($"---- Ресурсы : в = {j.branch}, к = {j.stone}, л = {j.leaf}, р = {j.water}");
                        Console.WriteLine();
                    }

                    for (int j = 0; j < 5; j++)
                    {
                        Console.WriteLine(
                            $"Куча {j + 1} : в = {kucha[j].Branch}, к = {kucha[j].Stone}, л = {kucha[j].Leaf}, р = {kucha[j].Water}");
                    }

                    for (int j = 0; j < count; j++)
                    {
                        for (int c = 0; c < colonies[j].Worker.Count; c++)
                        {
                            Worker n = colonies[j].Worker[c];
                            kucha[random.Next(0, 5)].Workers.Add(n);
                        }

                        for (int c = 0; c < colonies[j].Worker2.Count; c++)
                        {
                            Worker n = colonies[j].Worker2[c];
                            kucha[random.Next(0, 5)].Workers.Add(n);
                        }

                        for (int c = 0; c < colonies[j].Warior.Count; c++)
                        {
                            Warior n = colonies[j].Warior[c];
                            kucha[random.Next(0, 5)].Wariors.Add(n);
                        }

                        for (int c = 0; c < colonies[j].Warior2.Count; c++)
                        {
                            Warior n = colonies[j].Warior2[c];
                            kucha[random.Next(0, 5)].Wariors.Add(n);
                        }

                        if (colonies[j].Scarab.Life != 0)
                        {
                            Scarab n = colonies[j].Scarab;
                            kucha[random.Next(0, 5)].Scarab = n;
                        }

                        if (colonies[j].Termite.Life != 0)
                        {
                            Termite n = colonies[j].Termite;
                            kucha[random.Next(0, 5)].Termite = n;
                        }

                        if (colonies[j].Butterfly.Life != 0)
                        {
                            Butterfly n = colonies[j].Butterfly;
                            kucha[random.Next(0, 5)].Butterfly = n;
                        }
                    }

                    for (int k = 0; k < kucha.Length; k++)
                    {
                        for (int w = 0; w < kucha[k].Wariors.Count; w++)
                        {
                            int r = random.Next(0, 2);
                            if (r == 0)
                            {
                                int ch = random.Next(0, kucha[k].Workers.Count);
                                if (kucha[k].Wariors[w].Colony == 3)
                                {
                                    kucha[k].Wariors[w].Damage += 1;
                                    kucha[k].Wariors[w].Fight(kucha[k].Workers[ch], null);
                                    kucha[k].Wariors[w].Damage -= 1;
                                }

                                if (kucha[k].Wariors[w].Colony != 3)
                                {
                                    kucha[k].Wariors[w].Fight(kucha[k].Workers[ch], null);
                                }

                                if (kucha[k].Workers[ch].HP == 0)
                                {
                                    kucha[k].Workers[ch] = null;
                                    kucha[k].Workers.RemoveAt(ch);
                                }
                            }

                            if (r == 1)
                            {
                                int ch = random.Next(0, kucha[k].Wariors.Count);
                                if (kucha[k].Wariors[w].Colony == 3)
                                {
                                    kucha[k].Wariors[w].Damage += 1;
                                    kucha[k].Wariors[w].Fight(null, kucha[k].Wariors[ch]);
                                    kucha[k].Wariors[w].Damage -= 1;
                                }

                                if (kucha[k].Wariors[w].Colony != 3)
                                {
                                    kucha[k].Wariors[w].Fight(null, kucha[k].Wariors[ch]);
                                }

                                if (kucha[k].Wariors[ch].HP == 0)
                                {
                                    kucha[k].Wariors[ch] = null;
                                    kucha[k].Wariors.RemoveAt(ch);
                                }

                                if (kucha[k].Wariors[w].HP == 0) //TODO: IndexOutOfRange
                                {
                                    kucha[k].Wariors[w] = null;
                                    kucha[k].Wariors.RemoveAt(w);
                                }
                            }
                        }

                        for (int w = 0; w < kucha[k].Workers.Count; w++)
                        {
                            if (i < 8)
                            {
                                kucha[k].Workers[w].Count += 1;
                            }

                            int safe = kucha[k].Workers[w].Count;
                            if (kucha[k].Branch > kucha[k].Workers[w].Branch & kucha[k].Workers[w].Count > 0)
                            {
                                kucha[k].Branch -= kucha[k].Workers[w].Branch;
                                kucha[k].Workers[w].Count -= kucha[k].Workers[w].Branch;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Branch(kucha[k].Workers[w].Branch);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Branch < kucha[k].Workers[w].Branch & kucha[k].Workers[w].Count > 0 &
                                kucha[k].Branch > 0)
                            {
                                kucha[k].Branch = 0;
                                kucha[k].Workers[w].Count -= kucha[k].Branch;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Branch(kucha[k].Branch);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Leaf > kucha[k].Workers[w].Leaf & kucha[k].Workers[w].Count > 0)
                            {
                                kucha[k].Leaf -= kucha[k].Workers[w].Leaf;
                                kucha[k].Workers[w].Count -= kucha[k].Workers[w].Leaf;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Leaf(kucha[k].Workers[w].Leaf);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Leaf < kucha[k].Workers[w].Leaf & kucha[k].Workers[w].Count > 0 &
                                kucha[k].Leaf > 0)
                            {
                                kucha[k].Leaf = 0;
                                kucha[k].Workers[w].Count -= kucha[k].Leaf;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Leaf(kucha[k].Leaf);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Stone > kucha[k].Workers[w].Stone & kucha[k].Workers[w].Count > 0)
                            {
                                kucha[k].Stone -= kucha[k].Workers[w].Stone;
                                kucha[k].Workers[w].Count -= kucha[k].Workers[w].Stone;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Stone(kucha[k].Workers[w].Stone);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Stone < kucha[k].Workers[w].Stone & kucha[k].Workers[w].Count > 0 &
                                kucha[k].Stone > 0)
                            {
                                kucha[k].Stone = 0;
                                kucha[k].Workers[w].Count -= kucha[k].Stone;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Stone(kucha[k].Stone);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Water > kucha[k].Workers[w].Water & kucha[k].Workers[w].Count > 0)
                            {
                                kucha[k].Water -= kucha[k].Workers[w].Water;
                                kucha[k].Workers[w].Count -= kucha[k].Workers[w].Water;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Water(kucha[k].Workers[w].Water);
                                        }
                                    }
                                }
                            }

                            if (kucha[k].Water < kucha[k].Workers[w].Water & kucha[k].Workers[w].Count > 0 &
                                kucha[k].Water > 0)
                            {
                                kucha[k].Water = 0;
                                kucha[k].Workers[w].Count -= kucha[k].Water;
                                for (int c = 0; c < colonies.Count; c++)
                                {
                                    for (int l = 0; l < colonies[c].Worker.Count; l++)
                                    {
                                        if (colonies[c].Worker[l].Num == kucha[k].Workers[w].Num)
                                        {
                                            colonies[c].Water(kucha[k].Water);
                                        }
                                    }
                                }
                            }

                            kucha[k].Workers[w].Count = safe;
                        }

                        if (kucha[k].Scarab != null)
                        {
                            if (kucha[k].Scarab.HP != 0)
                            {
                                int save = kucha[k].Scarab.Count;
                                if (kucha[k].Branch > kucha[k].Scarab.Branch & kucha[k].Scarab.Count > 0)
                                {
                                    kucha[k].Branch -= kucha[k].Scarab.Branch;
                                    kucha[k].Scarab.Count -= kucha[k].Scarab.Branch;
                                    colonies[0].Branch(kucha[k].Scarab.Branch);
                                }

                                if (kucha[k].Branch < kucha[k].Scarab.Branch & kucha[k].Scarab.Count > 0 &
                                    kucha[k].Branch > 0)
                                {
                                    kucha[k].Branch = 0;
                                    kucha[k].Scarab.Count -= kucha[k].Branch;
                                    colonies[0].Branch(kucha[k].Branch);
                                }

                                if (kucha[k].Leaf > kucha[k].Scarab.Leaf & kucha[k].Scarab.Count > 0)
                                {
                                    kucha[k].Leaf -= kucha[k].Scarab.Leaf;
                                    kucha[k].Scarab.Count -= kucha[k].Scarab.Leaf;
                                    colonies[0].Leaf(kucha[k].Scarab.Leaf);
                                }

                                if (kucha[k].Leaf < kucha[k].Scarab.Leaf & kucha[k].Scarab.Count > 0 &
                                    kucha[k].Leaf > 0)
                                {
                                    kucha[k].Leaf = 0;
                                    kucha[k].Scarab.Count -= kucha[k].Leaf;
                                    colonies[0].Leaf(kucha[k].Leaf);
                                }

                                if (kucha[k].Stone > kucha[k].Scarab.Stone & kucha[k].Scarab.Count > 0)
                                {
                                    kucha[k].Stone -= kucha[k].Scarab.Stone;
                                    kucha[k].Scarab.Count -= kucha[k].Scarab.Stone;
                                    colonies[0].Stone(kucha[k].Scarab.Stone);
                                }

                                if (kucha[k].Stone < kucha[k].Scarab.Stone & kucha[k].Scarab.Count > 0 &
                                    kucha[k].Stone > 0)
                                {
                                    kucha[k].Stone = 0;
                                    kucha[k].Scarab.Count -= kucha[k].Stone;
                                    colonies[0].Stone(kucha[k].Stone);
                                }

                                if (kucha[k].Water > kucha[k].Scarab.Water & kucha[k].Scarab.Count > 0)
                                {
                                    kucha[k].Water -= kucha[k].Scarab.Water;
                                    kucha[k].Scarab.Count -= kucha[k].Scarab.Water;
                                    colonies[0].Water(kucha[k].Scarab.Water);
                                }

                                if (kucha[k].Water < kucha[k].Scarab.Water & kucha[k].Scarab.Count > 0 &
                                    kucha[k].Water > 0)
                                {
                                    kucha[k].Water = 0;
                                    kucha[k].Scarab.Count -= kucha[k].Water;
                                    colonies[0].Water(kucha[k].Water);
                                }

                                kucha[k].Scarab.Count = save;
                            }
                        }

                        if (kucha[k].Butterfly != null)
                        {
                            if (kucha[k].Butterfly.HP != 0)
                            {
                                int save = kucha[k].Butterfly.Count;
                                if (kucha[k].Branch > kucha[k].Butterfly.Branch & kucha[k].Butterfly.Count > 0)
                                {
                                    kucha[k].Branch -= kucha[k].Butterfly.Branch;
                                    kucha[k].Butterfly.Count -= kucha[k].Butterfly.Branch;
                                    colonies[0].Branch(kucha[k].Butterfly.Branch);
                                }

                                if (kucha[k].Branch < kucha[k].Butterfly.Branch & kucha[k].Butterfly.Count > 0 &
                                    kucha[k].Branch > 0)
                                {
                                    kucha[k].Branch = 0;
                                    kucha[k].Butterfly.Count -= kucha[k].Branch;
                                    colonies[0].Branch(kucha[k].Branch);
                                }

                                if (kucha[k].Leaf > kucha[k].Butterfly.Leaf & kucha[k].Butterfly.Count > 0)
                                {
                                    kucha[k].Leaf -= kucha[k].Butterfly.Leaf;
                                    kucha[k].Butterfly.Count -= kucha[k].Butterfly.Leaf;
                                    colonies[0].Leaf(kucha[k].Butterfly.Leaf);
                                }

                                if (kucha[k].Leaf < kucha[k].Butterfly.Leaf & kucha[k].Butterfly.Count > 0 &
                                    kucha[k].Leaf > 0)
                                {
                                    kucha[k].Leaf = 0;
                                    kucha[k].Butterfly.Count -= kucha[k].Leaf;
                                    colonies[0].Leaf(kucha[k].Leaf);
                                }

                                if (kucha[k].Stone > kucha[k].Butterfly.Stone & kucha[k].Butterfly.Count > 0)
                                {
                                    kucha[k].Stone -= kucha[k].Butterfly.Stone;
                                    kucha[k].Butterfly.Count -= kucha[k].Butterfly.Stone;
                                    colonies[0].Stone(kucha[k].Butterfly.Stone);
                                }

                                if (kucha[k].Stone < kucha[k].Butterfly.Stone & kucha[k].Butterfly.Count > 0 &
                                    kucha[k].Stone > 0)
                                {
                                    kucha[k].Stone = 0;
                                    kucha[k].Butterfly.Count -= kucha[k].Stone;
                                    colonies[0].Stone(kucha[k].Stone);
                                }

                                if (kucha[k].Water > kucha[k].Butterfly.Water & kucha[k].Butterfly.Count > 0)
                                {
                                    kucha[k].Water -= kucha[k].Butterfly.Water;
                                    kucha[k].Butterfly.Count -= kucha[k].Butterfly.Water;
                                    colonies[0].Water(kucha[k].Butterfly.Water);
                                }

                                if (kucha[k].Water < kucha[k].Butterfly.Water & kucha[k].Butterfly.Count > 0 &
                                    kucha[k].Water > 0)
                                {
                                    kucha[k].Water = 0;
                                    kucha[k].Butterfly.Count -= kucha[k].Water;
                                    colonies[0].Water(kucha[k].Water);
                                }

                                kucha[k].Butterfly.Count = save;
                            }
                        }

                        if (kucha[k].Termite != null)
                        {
                            int r = random.Next(0, 4);
                            if (r == 0)
                            {
                                int ch = random.Next(0, kucha[k].Workers.Count);
                                kucha[k].Termite.Fight(kucha[k].Workers[ch], null, null, null);
                                if (kucha[k].Workers[ch].HP == 0)
                                {
                                    kucha[k].Workers[ch] = null;
                                    kucha[k].Workers.RemoveAt(ch);
                                }
                            }

                            if (r == 1)
                            {
                                int ch = random.Next(0, kucha[k].Wariors.Count);
                                kucha[k].Termite.Fight(null, kucha[k].Wariors[ch], null, null);
                                if (kucha[k].Wariors[ch].HP == 0)
                                {
                                    kucha[k].Wariors[ch] = null;
                                    kucha[k].Wariors.RemoveAt(ch);
                                }

                                if (kucha[k].Termite.HP == 0)
                                {
                                    kucha[k].Termite = null;
                                }
                            }

                            if (r == 2 & kucha[k].Scarab != null)
                            {
                                if (kucha[k].Scarab.HP != 0)
                                {
                                    kucha[k].Termite.Fight(null, null, null, kucha[k].Scarab);
                                }
                            }

                            if (r == 3 & kucha[k].Butterfly != null)
                            {
                                if (kucha[k].Butterfly.HP != 0)
                                {
                                    kucha[k].Termite.Fight(null, null, kucha[k].Butterfly, null);
                                }
                            }
                        }
                    }

                    for (int j = 0; j < colonies.Count; j++)
                    {
                        for (int k = 0; k < colonies[j].Worker.Count; k++)
                        {
                            if (colonies[j].Worker[k] == null)
                            {
                                colonies[j].Worker.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < colonies[j].Worker2.Count; k++)
                        {
                            if (colonies[j].Worker2[k] == null)
                            {
                                colonies[j].Worker2.RemoveAt(k);
                            }
                        }

                        for (int k = 0; k < colonies[j].Warior.Count; k++)
                        {
                            if (colonies[j].Warior[k] == null)
                            {
                                colonies[j].Warior.RemoveAt(k);
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

                    Reproduction(colonies, count);

                    Console.WriteLine();
                    Console.WriteLine("________________________");
                    Console.WriteLine();
                }

                else if (comand == "информация")
                {
                    Console.WriteLine("Введите название колонии");
                    col = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine(
                        "Введите <колония> если хотите увидеть информацию о колонии, <рабочий> - о рабочем, <воин> - о воине, <особое> - об особом насекомом");
                    inf = Console.ReadLine();
                    Console.WriteLine();
                    if (inf == "колония")
                    {
                        foreach (Colony j in colonies)
                        {
                            if (j.Name == col)
                            {
                                a = j;
                                Console.WriteLine($" Королева \"{j.Queen.Name}\"");
                                Console.WriteLine(
                                    $" Общая популяция - {a.Warior.Count + a.Worker.Count + a.Scarab.Life + a.Termite.Life + a.Butterfly.Life + a.Worker2.Count + a.Warior2.Count - 4}");
                                Console.WriteLine();
                                Console.WriteLine($" <<<<<<<<<<<<< Рабочие >>>>>>>>>>>>>");
                                Console.WriteLine();
                                Console.WriteLine($" Тип : {j.Worker[0].Type}");
                                Console.WriteLine(
                                    $" ---- Параметры : Здоровье = {j.Worker[0].HP}; Защита = {j.Worker[0].Armor}");
                                Console.WriteLine($" ---- Количество : {j.Worker.Count}");
                                Console.WriteLine();
                                Console.WriteLine($" Тип : {j.Worker2[0].Type}");
                                Console.WriteLine(
                                    $" ---- Параметры : Здоровье = {j.Worker2[0].HP}; Защита = {j.Worker2[0].Armor}");
                                Console.WriteLine($" ---- Количество : {j.Worker2.Count}");
                                Console.WriteLine();
                                Console.WriteLine($" <<<<<<<<<<<<< Воины >>>>>>>>>>>>>");
                                Console.WriteLine();
                                Console.WriteLine($" Тип : {j.Warior[0].Type}");
                                Console.WriteLine(
                                    $" ---- Параметры : Здоровье = {j.Warior[0].HP}; Защита = {j.Warior[0].Armor}");
                                Console.WriteLine($" ---- Количество : {j.Warior.Count}");
                                Console.WriteLine();
                                Console.WriteLine($" Тип : {j.Warior2[0].Type}");
                                Console.WriteLine(
                                    $" ---- Параметры : Здоровье = {j.Warior2[0].HP}; Защита = {j.Warior2[0].Armor}");
                                Console.WriteLine($" ---- Количество : {j.Warior2.Count}");
                                Console.WriteLine();
                                Console.WriteLine($" <<<<<<<<<<<<< Особое насекомое >>>>>>>>>>>>>");
                                Console.WriteLine();
                                if (j.Scarab.Life == 1)
                                {
                                    Console.WriteLine($" Название : {j.Scarab.Name}");
                                    Console.WriteLine(
                                        $" ---- Параметры : Здоровье = {j.Scarab.HP}; Защита = {j.Scarab.Armor}; Атака = {j.Scarab.Damage}");
                                    Console.WriteLine($" ---- Бонусы : {j.Scarab.Bonus}");
                                }

                                if (j.Termite.Life == 1)
                                {
                                    Console.WriteLine($" Название : {j.Termite.Name}");
                                    Console.WriteLine(
                                        $" ---- Параметры : Здоровье = {j.Termite.HP}; Защита = {j.Termite.Armor}; Атака = {j.Termite.Damage}");
                                    Console.WriteLine($" ---- Бонусы : {j.Termite.Bonus}");
                                }

                                if (j.Butterfly.Life == 1)
                                {
                                    Console.WriteLine($" Название : {j.Butterfly.Name}");
                                    Console.WriteLine(
                                        $" ---- Параметры : Здоровье = {j.Butterfly.HP}; Защита = {j.Butterfly.Armor}; Атака = {j.Butterfly.Damage}");
                                    Console.WriteLine($" ---- Бонусы : {j.Butterfly.Bonus}");
                                }

                                Console.WriteLine();
                            }
                        }
                    }

                    if (inf == "рабочий")
                    {
                        foreach (Colony j in colonies)
                        {
                            if (j.Name == col)
                            {
                                Console.WriteLine($"Тип : {j.Worker[0].Type}");
                                Console.WriteLine(
                                    $"Параметры : Здоровье = {j.Worker[0].HP}; Защита = {j.Worker[0].Armor}");
                                Console.WriteLine($"Королева : {j.Queen.Name}");
                                Console.WriteLine();
                                Console.WriteLine($"Тип : {j.Worker2[0].Type}");
                                Console.WriteLine(
                                    $"Параметры : Здоровье = {j.Worker2[0].HP}; Защита = {j.Worker2[0].Armor}");
                                Console.WriteLine($"Королева : {j.Queen.Name}");
                                Console.WriteLine();
                            }
                        }
                    }

                    if (inf == "воин")
                    {
                        foreach (Colony j in colonies)
                        {
                            if (j.Name == col)
                            {
                                Console.WriteLine($" Тип : {j.Warior[0].Type}");
                                Console.WriteLine(
                                    $" Параметры : Здоровье = {j.Warior[0].HP}; Защита = {j.Warior[0].Armor}; Атака = {j.Warior[0].Damage}");
                                Console.WriteLine($"Королева : {j.Queen.Name}");
                                Console.WriteLine();
                                Console.WriteLine($" Тип : {j.Warior2[0].Type}");
                                Console.WriteLine(
                                    $" Параметры : Здоровье = {j.Warior2[0].HP}; Защита = {j.Warior2[0].Armor}; Атака = {j.Warior2[0].Damage}");
                                Console.WriteLine($"Королева : {j.Queen.Name}");
                                Console.WriteLine();
                            }
                        }
                    }

                    if (inf == "особое")
                    {
                        foreach (Colony j in colonies)
                        {
                            if (j.Name == col)
                            {
                                if (j.Scarab.Life == 1)
                                {
                                    Console.WriteLine($" Название : {j.Scarab.Name}");
                                    Console.WriteLine(
                                        $" Параметры : Здоровье = {j.Scarab.HP}; Защита = {j.Scarab.Armor}; Атака = {j.Scarab.Damage}");
                                    Console.WriteLine($" Бонусы : {j.Scarab.Bonus}");
                                }

                                if (j.Termite.Life == 1)
                                {
                                    Console.WriteLine($" Название : {j.Termite.Name}");
                                    Console.WriteLine(
                                        $" Параметры : Здоровье = {j.Termite.HP}; Защита = {j.Termite.Armor}; Атака = {j.Termite.Damage}");
                                    Console.WriteLine($" Бонусы : {j.Termite.Bonus}");
                                }

                                if (j.Butterfly.Life == 1)
                                {
                                    Console.WriteLine($" Название : {j.Butterfly.Name}");
                                    Console.WriteLine(
                                        $" Параметры : Здоровье = {j.Butterfly.HP}; Защита = {j.Butterfly.Armor}; Атака = {j.Butterfly.Damage}");
                                    Console.WriteLine($" Бонусы : {j.Butterfly.Bonus}");
                                }

                                if ((j.Butterfly.Life == 0) & (j.Scarab.Life == 0) & (j.Termite.Life == 0))
                                {
                                    Console.WriteLine("В этой колонии нет особых насекомых");
                                }

                                Console.WriteLine();
                            }
                        }
                    }
                }

                else if (comand == "стоп")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Команда не распознана. Попробуйте ещё раз");
                }
            }
        }

        class Ant
        {
            public int HP;
            public int Armor;
            public int Damage;
            public int Colony;
            public int Num;

            public Ant(int colony, int num, int hp = 1, int armor = 0, int damage = 0)
            {
                HP = hp;
                Armor = armor;
                Damage = damage;
                Colony = colony;
                Num = num;
            }
        }

        class Queen : Ant
        {
            public string Name;
            public int[] Cycle;
            public int[] Kor;
            public int Start;
            public int Count;

            public Queen(string name, int[] cycle, int[] kor, int colony, int num, int start, int hp = 1, int armor = 0,
                int damage = 0) : base(colony, num, hp, armor, damage)
            {
                Name = name;
                Cycle = cycle;
                Kor = kor;
                Start = start;
                Count = new Random().Next(Cycle[0], Cycle[1]);
            }

            // TODO: cleanup
            // public void timer()
            // {
            //     if (this.Count > 0)
            //     {
            //         this.Count -= 1;
            //     }
            //
            //     if (this.Count == 0)
            //     {
            //         this.Count = new Random().Next(this.cycle[0], this.cycle[1]);
            //     }
            // }
        }

        class Worker : Ant
        {
            public string Type;
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;
            public int Bad; //TODO: cleanup
            public int Count;

            public Worker(string type, int colony, int num, int leaf, int branch, int stone, int water, int count,
                int hp = 1, int armor = 0, int damage = 0) : base(colony, num, hp, armor, damage)
            {
                Type = type;
                Leaf = leaf;
                Branch = branch;
                Stone = stone;
                Water = water;
                Count = count;
            }
        }

        class Warior : Ant
        {
            public string Type;
            public int AttackNum; //TODO: cleanup
            public int Bad;
            public int Target; //TODO: cleanup

            public Warior(int bad, string type, int colony, int num, int target = 1, int attackNum = 1, int hp = 1,
                int armor = 1, int damage = 1) : base(colony, num, hp, armor, damage)
            {
                Type = type;
                AttackNum = attackNum;
                Bad = bad;
                Target = target;
            }

            public void Fight(Worker work, Warior war)
            {
                Worker worker = work;
                Warior warior = war;
                if (worker != null)
                {
                    if (worker.Colony != Colony)
                    {
                        worker.Armor -= this.Damage;
                        if (worker.Armor < 0)
                        {
                            worker.HP += worker.Armor;
                            worker.Armor = 0;
                        }
                    }
                }

                if (warior != null)
                {
                    if (warior.Colony != Colony)
                    {
                        warior.Armor -= Damage;
                        if (warior.Bad == 0)
                        {
                            Armor -= warior.Damage;
                        }

                        if (warior.Armor < 0)
                        {
                            warior.HP += warior.Armor;
                            warior.Armor = 0;
                        }

                        if (Armor < 0)
                        {
                            HP += Armor;
                            Armor = 0;
                        }
                    }
                }
            }
        }

        class Scarab : Ant   //TODO: not needed
        {
            public int Life;
            public int Bad; //TODO: cleanup
            public string Name; //TODO: cleanup
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;
            public string Bonus;
            public int Count;

            public Scarab(string bonus, int life, int bad, int colony, int leaf, int branch, int stone, int water,
                int count, int hp = 1, int armor = 0, int damage = 0) : base(colony, hp, armor, damage)
            {
                Life = life;
                Bad = bad;
                Bonus = bonus;
                Leaf = leaf;
                Branch = branch;
                Stone = stone;
                Water = water;
                Count = count;
            }
        }

        class Termite : Ant     //TODO: not needed
        {
            public int Life;
            public int Bad;  //TODO: cleanup
            public string Name;  //TODO: cleanup
            public string Bonus;
            public int Count;  //TODO: cleanup

            public Termite(string bonus, int life, int bad, int colony, int hp = 1, int armor = 0, int damage = 0) :
                base(colony, hp, armor, damage)
            {
                this.Life = life;
                this.Bad = bad;
                this.Bonus = bonus;
            }

            public void Fight(Worker worker, Warior warior, Butterfly butterfly, Scarab scarab)
            {
                if (worker != null)
                {
                    if (worker.Colony != this.Colony)
                    {
                        worker.Armor = worker.Armor - (this.Damage * 2);
                        if (worker.Armor < 0)
                        {
                            worker.HP = worker.HP + worker.Armor;
                            worker.Armor = 0;
                        }
                    }
                }

                if (warior != null)
                {
                    if (warior.Colony != this.Colony)
                    {
                        warior.Armor = warior.Armor - (this.Damage * 2);
                        this.Armor = this.Armor - warior.Damage;

                        if (warior.Armor < 0)
                        {
                            warior.HP = warior.HP + warior.Armor;
                            warior.Armor = 0;
                        }

                        if (this.Armor < 0)
                        {
                            this.HP = this.HP + this.Armor;
                            this.Armor = 0;
                        }
                    }
                }

                if (scarab != null)
                {
                    if (scarab.Colony != this.Colony)
                    {
                        scarab.Armor = scarab.Armor - this.Damage;
                        if (scarab.Armor < 0)
                        {
                            scarab.HP = scarab.HP + scarab.Armor;
                            scarab.Armor = 0;
                        }
                    }
                }

                if (butterfly != null)
                {
                    if (butterfly.Colony != this.Colony)
                    {
                        butterfly.Armor = butterfly.Armor - (this.Damage * 2);
                        this.Armor = this.Armor - butterfly.Damage;

                        if (butterfly.Armor < 0)
                        {
                            butterfly.HP = butterfly.HP + butterfly.Armor;
                            butterfly.Armor = 0;
                        }

                        if (this.Armor < 0)
                        {
                            this.HP = this.HP + this.Armor;
                            this.Armor = 0;
                        }
                    }
                }
            }
        }


        class Butterfly : Ant
        {
            public int Life;
            public int Bad;  //TODO: cleanup
            public string Name;  //TODO: cleanup
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;
            public int Count;
            public string Bonus;

            public Butterfly(string bonus, int life, int bad, int colony, int leaf, int branch, int stone, int water,
                int count, int hp = 1, int armor = 0, int damage = 0) : base(colony, hp, armor, damage)
            {
                Life = life;
                Bad = bad;
                Bonus = bonus;
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
            public List<Worker> Worker;
            public List<Warior> Warior;
            public List<Worker> Worker2;
            public List<Warior> Warior2;
            public Scarab Scarab;
            public Termite Termite;
            public Butterfly Butterfly;

            public Colony(string name, Queen queen) : this()
            {
                this.Name = name;
                this.Queen = queen;
                this.Worker = new List<Worker>();
                this.Worker2 = new List<Worker>();
                this.Warior = new List<Warior>();
                this.Warior2 = new List<Warior>();
                this.branch = 0;
                this.leaf = 0;
                this.stone = 0;
                this.water = 0;
            }

            public void Leaf(int a)
            {
                this.leaf += a;
            }

            public void Branch(int a)
            {
                this.branch += a;
            }

            public void Stone(int a)
            {
                this.stone += a;
            }

            public void Water(int a)
            {
                this.water += a;
            }
        }

        static void Reproduction(List<Colony> colonies, int count)
        {
            for (int j = 0; j < count; j++)
            {
                if (colonies[j].Queen.Count == 0)
                {
                    if (colonies[j].Queen.Start == 0)
                    {
                        Random random = new Random();
                        for (int g = 0; g < colonies[j].Queen.Kor[random.Next(0, 1)]; g++)
                        {
                            if (random.Next(1, 11) > 5)
                            {
                                if (colonies[j].Queen.Colony == 1)
                                {
                                    colonies.Add(new Colony(create_name(random),
                                        new Queen(create_name(random), new[] {2, 4}, new[] {3, 4}, 1, count, 1,
                                            3, 1, 1)));
                                }

                                if (colonies[j].Queen.Colony == 2)
                                {
                                    colonies.Add(new Colony(create_name(random),
                                        new Queen(create_name(random), new[] {2, 3}, new[] {3, 4}, 2, count, 1,
                                            2, 0, 2)));
                                }

                                if (colonies[j].Queen.Colony == 3)
                                {
                                    colonies.Add(new Colony(create_name(random),
                                        new Queen(create_name(random), new[] {1, 3}, new[] {1, 5}, 3, count, 1,
                                            5, 2)));
                                }

                                count += 1;
                            }
                        }
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Worker.Add(new Worker("легендарный", 1, colonies[j].Queen.Num, 1, 1, 2, 3, 3));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Worker.Add(new Worker("старший", 2, colonies[j].Queen.Num, 2, 1, 2, 1, 1));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Worker.Add(new Worker("легендарный", 3, colonies[j].Queen.Num, 1, 2, 2, 2, 3));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Worker2.Add(new Worker("легендарный крепкий", 1, colonies[j].Queen.Num, 2, 2, 2, 1,
                            3, 1, 1));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Worker2
                            .Add(new Worker("легендарный бригадир", 2, colonies[j].Queen.Num, 2, 2, 2, 1, 3));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Worker2
                            .Add(new Worker("старший бригадир", 3, colonies[j].Queen.Num, 1, 2, 2, 1, 1));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Warior.Add(new Warior(0, "обычный", 1, colonies[j].Queen.Num));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Warior.Add(new Warior(0, "старший", 2, colonies[j].Queen.Num));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Warior.Add(new Warior(0, "продвинутый", 3, colonies[j].Queen.Num, 2));
                    }
                }

                for (int g = 0; g < 7; g++)
                {
                    if (colonies[j].Queen.Colony == 1)
                    {
                        colonies[j].Warior2
                            .Add(new Warior(0, "продвинутый худой", 1, colonies[j].Queen.Num, 2, 1, 1, 0));
                    }

                    if (colonies[j].Queen.Colony == 2)
                    {
                        colonies[j].Warior2.Add(new Warior(1, "обычный аномальный", 2, colonies[j].Queen.Num));
                    }

                    if (colonies[j].Queen.Colony == 3)
                    {
                        colonies[j].Warior2.Add(new Warior(0, "старший сосредоточенный", 3, colonies[j].Queen.Num, 1, 1,
                            1, 1, 2));
                    }
                }
            }
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

        struct Kucha
        {
            public List<Warior> Wariors;
            public List<Worker> Workers;
            public Scarab Scarab;
            public Termite Termite;
            public Butterfly Butterfly;
            public int Leaf;
            public int Branch;
            public int Stone;
            public int Water;

            public Kucha(int leaf, int branch, int stone, int water) : this()
            {
                this.Leaf = leaf;
                this.Branch = branch;
                this.Stone = stone;
                this.Water = water;
                this.Workers = new List<Worker>();
                this.Wariors = new List<Warior>();
            }
        }
    }
}
using System.Diagnostics.Tracing;

namespace Practica_1year_ants
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Commands:\nnext - starts next day\nstop - stops program\ninfo - info about objects");
            string? comand;
            int i = 0;
            int dry = 11;
            // list of ants templates  for reproduction
            Worker[] repWorkers =
            {
                new("обычный", 0, 1, 0, 0, 0, 1, armor: 8),
                new("обычный", 0, 0, 0, 0, 1, 1),
                new("элитный", 0, 1, 0, 0, 1, 2, 8, 4),
                new("элитный", 0, 0, 0, 1, 1, 2, 8, 4),
                new("элитный капризный", 0, 0, 0, 1, 1, 2, 8, 4,
                    bonus: new List<string> {"игнорирует каждый 2й поход"}),
                new("обычный забывчивый", 0, 0, 1, 0, 0, 1,
                    bonus: new List<string> {"может забыть взять ресурс из кучи"})
            };
            Warrior[] repWarriors =
            {
                new(0, "обычный настойчивый", 0, 1, 1, 1, 0, 1,
                    new List<string> {"всегда наносит укус"}),
                new(0, "обычный точный", 0, 1, 1, 1, 0, 1,
                    new List<string> {"игнорирует защиту", "может наносить урон неуязвимым насекомым"}),
                new(0, "старший", 0, 1, 1, 2, 1, 2),
                new(0, "элитный", 0, 2, 2, 8, 4, 3),
                new(0, "элитный", 0, 2, 2, 8, 4, 3),
                new(0, "легендарный", 0, 3, 1, 10, 6, 6)
            };
            Special[] repSpecials =
            {
                new(1, 1, 1, 1, 1, 0,
                    "трудолюбивый неуязвимый агрессивный берсерк забывчивый - Сверчок", 0, 3, 3, 20, 5, 7,
                    new List<string>
                    {
                        "не может быть атакован войнами", "одноразовый, массового поражения",
                        "может забыть взять ресурс из кучи"
                    }),
                new(0, 0, 0, 0, 0, 0,
                    "ленивый обычный мирный осторожный - Бабочка", 0, 0, 0, 17, 7, 0,
                    new List<string> {"группа игнорирует эффекты агрессивных насекомых на территории"})
            };

            //create colonies
            List<Colony> colonies = new List<Colony>
            {
                new("красные", new Queen("София", new[] {3, 4}, new[] {3, 4}, 1, 0, 25, 8, 20), new[] {14, 9, 1}),
                new("зеленые",
                    new Queen("Елизавета", new[] {2, 4}, new[] {1, 3}, 2, 0, 18, 5, 22), new[] {17, 7, 1})
            };
            // cделать кучи
            Heap[] heaps =
            {
                new(35, 30, 0, 0), new(0, 39, 27, 17), new(14, 13, 15, 30),
                new(15, 37, 14, 28), new(15, 35, 0, 32)
            };
            // забить колонии муравьями
            for (int j = 0; j < colonies.Count; j++)
            {
                for (int g = 0; g < 6; g++)
                {
                    if (j == 0)
                    {
                        colonies[j].Workers.Add(new Worker("обычный", 1, 1, 0, 0, 0, 1, armor: 8));
                    }

                    if (j == 1)
                    {
                        colonies[j].Workers.Add(new Worker("обычный", 2, 0, 0, 0, 1, 1));
                    }
                }

                for (int g = 0; g < 5; g++)
                {
                    if (j == 0)
                    {
                        colonies[j].Workers.Add(new Worker("элитный", 1, 1, 0, 0, 1, 2, 8, 4));
                    }

                    if (j == 1)
                    {
                        colonies[j].Workers.Add(new Worker("элитный", 2, 0, 0, 1, 1, 2, 8, 4));
                    }
                }

                for (int g = 0; g < 5; g++)
                {
                    if (j == 0)
                    {
                        colonies[j].Workers.Add(new Worker("элитный капризный", 1, 0, 0, 1, 1, 2, 8, 4,
                            bonus: new List<string> {"игнорирует каждый 2й поход"}));
                    }

                    if (j == 1)
                    {
                        colonies[j].Workers.Add(new Worker("обычный забывчивый", 2, 0, 1, 0, 0, 1,
                            bonus: new List<string> {"может забыть взять ресурс из кучи"}));
                    }
                }

                for (int g = 0; g < 6; g++)
                {
                    if (j == 0)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "обычный настойчивый", 1, 1, 1, 1, 0, 1,
                            new List<string> {"всегда наносит укус"}));
                    }

                    if (j == 1)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "обычный точный", 2, 1, 1, 1, 0, 1,
                            new List<string> {"игнорирует защиту", "может наносить урон неуязвимым насекомым"}));
                    }
                }

                for (int g = 0; g < 5; g++)
                {
                    if (j == 0)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "старший", 1, 1, 1, 2, 1, 2));
                    }

                    if (j == 1)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "элитный", 2, 2, 2, 8, 4, 3));
                    }
                }

                for (int g = 0; g < 5; g++)
                {
                    if (j == 0)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "элитный", 1, 2, 2, 8, 4, 3));
                    }

                    if (j == 1)
                    {
                        colonies[j].Warriors.Add(new Warrior(0, "легендарный", 2, 3, 1, 10, 6, 6));
                    }
                }

                // создать особых
                if (j == 0)
                {
                    colonies[j].Specials.Add(new Special(1, 1, 1, 1, 1, 0,
                        "трудолюбивый неуязвимый агрессивный берсерк забывчивый - Сверчок", 1, 3, 3, 20, 5, 7,
                        new List<string>
                        {
                            "не может быть атакован войнами", "одноразовый, массового поражения",
                            "может забыть взять ресурс из кучи"
                        }));
                }

                if (j == 1)
                {
                    colonies[j].Specials.Add(new Special(0, 0, 0, 0, 0, 0,
                        "ленивый обычный мирный осторожный - Бабочка", 2, 0, 0, 17, 7, 0,
                        new List<string>
                            {"группа игнорирует эффекты агрессивных насекомых на территории"}));
                }
            }

            Random random = new Random();
            int aphidStartDay = random.Next(0, 7);
            int aphidColony = 0;
            int aphidType = 0;

            Console.WriteLine("=====");

            while (i < dry)
            {
                // comand = Console.ReadLine();
                comand = "next";

                if (comand == "next")
                {
                    int summary = 0;
                    foreach (var heap in heaps)
                    {
                        summary += heap.Branch;
                        summary += heap.Leaf;
                        summary += heap.Stone;
                        summary += heap.Water;
                    }

                    if (summary == 0)
                    {
                        Winner(colonies);
                    }

                    Console.WriteLine($"Day {i + 1}  (Until dry season {dry - i} days)");
                    if (aphidStartDay <= i && i < aphidStartDay + 5)
                    {
                        if (aphidStartDay != i && aphidType != -1)
                        {
                            switch (aphidType)
                            {
                                case 0:
                                    foreach (var w in colonies[aphidColony].Workers)
                                    {
                                        w.aphid = false;
                                    }

                                    break;
                                case 1:
                                    foreach (var w in colonies[aphidColony].Warriors)
                                    {
                                        w.aphid = false;
                                    }

                                    break;
                                case 2:
                                    foreach (var s in colonies[aphidColony].Specials)
                                    {
                                        s.aphid = false;
                                    }

                                    break;
                            }
                        }

                        Console.WriteLine($"Действует эффект \"Тля\" , осталось {aphidStartDay + 5 - i} дней ");
                        aphidColony = random.Next(0, colonies.Count);
                        if (colonies[aphidColony].Workers.Count != 0)
                        {
                            if (colonies[aphidColony].Warriors.Count != 0)
                            {
                                if (colonies[aphidColony].Specials.Count != 0)
                                {
                                    aphidType = random.Next(0, 3);
                                }
                                else
                                {
                                    aphidType = random.Next(0, 2);
                                }
                            }
                            else
                            {
                                if (colonies[aphidColony].Specials.Count != 0)
                                {
                                    aphidType = random.Next(0, 2);
                                    if (aphidType == 1) aphidType = 2; //костыль для случайного выбора двух опций, но корректного вычисления индекса
                                }
                                else
                                {
                                    aphidType = 0;
                                }
                            }
                        }
                        else
                        {
                            aphidType = -1;
                            Console.WriteLine("Тля не нашла кого подменить в колонии.");
                        }

                        if (aphidType != -1)
                        {
                            switch (aphidType)
                            {
                                case 0:
                                    colonies[aphidColony].Workers[random.Next(0, colonies[aphidColony].Workers.Count)]
                                        .aphid = true;
                                    break;
                                case 1:
                                    colonies[aphidColony].Warriors[random.Next(0, colonies[aphidColony].Warriors.Count)]
                                        .aphid = true;
                                    break;
                                case 2:
                                    colonies[aphidColony].Specials[random.Next(0, colonies[aphidColony].Specials.Count)]
                                        .aphid = true;
                                    break;
                            }
                        }
                    }

                    // Console.WriteLine($"День {i}  (До засухи {dryCount - day} дней)");
                    // Console.WriteLine();
                    foreach (Colony colony in colonies)
                    {
                        Console.WriteLine($"Колония \"{colony.Name}\" :");
                        Console.WriteLine($"==== Королева \"{colony.Queen.Name}\"");
                        Console.WriteLine(
                            $"== Популяция: Воины = {colony.Warriors.Count}; Рабочие = {colony.Workers.Count}; Особые = {colony.Specials.Count};");
                        Console.WriteLine(
                            $"== Ресурсы : в = {colony.branch}, к = {colony.stone}, л = {colony.leaf}, р = {colony.water}");
                        Console.WriteLine();
                    }

                    for (int j = 0; j < heaps.Length; j++)
                    {
                        Console.WriteLine(
                            $"Куча {j + 1}: в = {heaps[j].Branch}, к = {heaps[j].Stone}, л = {heaps[j].Leaf}, р = {heaps[j].Water}");
                    }

                    // распределение по кучам
                    for (int j = 0; j < heaps.Length; j++)
                    {
                        heaps[j].Specials = new List<Special?>();
                        heaps[j].Warriors = new List<Warrior?>();
                        heaps[j].Workers = new List<Worker?>();
                    }

                    foreach (var t in colonies)
                    {
                        foreach (var n in t.Workers)
                        {
                            heaps[random.Next(0, heaps.Length)].Workers.Add(n);
                        }

                        foreach (var n in t.Warriors)
                        {
                            heaps[random.Next(0, heaps.Length)].Warriors.Add(n);
                        }

                        foreach (var n in t.Specials)
                        {
                            heaps[random.Next(0, heaps.Length)].Specials.Add(n);
                        }
                    }


                    // Fight

                    for (var k = 0; k < heaps.Length; k++)
                    {
                        for (var warCount = 0; warCount < heaps[k].Warriors.Count; warCount++)
                        {
                            if (heaps[k].Warriors[warCount] is null) continue;
                            int RemainAttacks = heaps[k].Warriors[warCount].TargetNum;
                            for (var attack = 0; attack < RemainAttacks; attack++)
                            {
                                int enemyIndex = random.Next(0, 3);
                                if (heaps[k].Warriors[warCount] is not null)
                                {
                                    int[] randoms = new[]
                                    {
                                        random.Next(0, heaps[k].Workers.Count),
                                        random.Next(0, heaps[k].Warriors.Count),
                                        random.Next(0, heaps[k].Specials.Count)
                                    };
                                    if (heaps[k].Workers.Count != 0 && heaps[k].Workers[randoms[0]] is not null && enemyIndex == 0)
                                    {
                                        heaps[k].Warriors[warCount].Fight(heaps[k].Workers[randoms[0]]);
                                        if (heaps[k].Workers[randoms[0]].HP <= 0)
                                        {
                                            int warroirIndex = colonies[heaps[k].Workers[randoms[0]].Colony - 1]
                                                .Workers
                                                .IndexOf(heaps[k].Workers[randoms[0]]);
                                            if (warroirIndex != -1)
                                            {
                                                colonies[heaps[k].Workers[randoms[0]].Colony - 1].Workers
                                                    .RemoveAt(warroirIndex);
                                            }

                                            heaps[k].Workers[randoms[0]] = null;
                                        }
                                    }

                                    if (heaps[k].Warriors[randoms[1]] is not null && enemyIndex == 1)
                                    {
                                        heaps[k].Warriors[warCount]
                                            .Fight(heaps[k].Warriors[randoms[1]]);
                                        if (heaps[k].Warriors[randoms[1]].HP <= 0)
                                        {
                                            int warroirIndex = colonies[heaps[k].Warriors[randoms[1]].Colony - 1]
                                                .Warriors
                                                .IndexOf(heaps[k].Warriors[randoms[1]]);
                                            if (warroirIndex != -1)
                                            {
                                                colonies[heaps[k].Warriors[randoms[1]].Colony - 1].Warriors
                                                    .RemoveAt(warroirIndex);
                                            }

                                            heaps[k].Warriors[randoms[1]] = null;
                                        }
                                        else if (heaps[k].Warriors[warCount].HP <= 0)
                                        {
                                            int warroirIndex = colonies[heaps[k].Warriors[warCount].Colony - 1]
                                                .Warriors
                                                .IndexOf(heaps[k].Warriors[warCount]);
                                            if (warroirIndex != -1)
                                            {
                                                colonies[heaps[k].Warriors[warCount].Colony - 1].Warriors
                                                    .RemoveAt(warroirIndex);
                                            }

                                            heaps[k].Warriors[warCount] = null;
                                        }
                                    }

                                    if (heaps[k].Specials.Count == 0 || enemyIndex != 2) continue;
                                    {
                                        if (heaps[k].Specials[randoms[2]] is null) continue;
                                        heaps[k].Warriors[warCount].Fight(heaps[k].Specials[randoms[2]]);
                                        if (heaps[k].Specials[randoms[2]].HP <= 0)
                                        {
                                            int warroirIndex =
                                                colonies[heaps[k].Specials[randoms[2]].Colony - 1]
                                                    .Specials
                                                    .IndexOf(heaps[k].Specials[randoms[2]]);
                                            if (warroirIndex != -1)
                                            {
                                                colonies[heaps[k].Specials[randoms[2]].Colony - 1].Specials
                                                    .RemoveAt(warroirIndex);
                                            }

                                            heaps[k].Specials[randoms[2]] = null;
                                        }
                                        else if (heaps[k].Warriors[warCount].HP <= 0)
                                        {
                                            int warriorIndex = colonies[heaps[k].Warriors[warCount].Colony - 1]
                                                .Warriors
                                                .IndexOf(heaps[k].Warriors[warCount]);
                                            if (warriorIndex != -1)
                                            {
                                                colonies[heaps[k].Warriors[warCount].Colony - 1].Warriors
                                                    .RemoveAt(warriorIndex);
                                            }

                                            heaps[k].Warriors[warCount] = null;
                                        }
                                    }
                                }
                            }
                        }

                        for (var specialCount = 0; specialCount < heaps[k].Specials.Count; specialCount++)
                        {
                            if (heaps[k].Specials[specialCount] is null) continue;
                            int RemainAttacks = heaps[k].Specials[specialCount].TargetNum;
                            for (var attack = 0; attack < RemainAttacks; attack++)
                            {
                                int enemyIndex = random.Next(0, 3);
                                if (heaps[k].Specials[specialCount] is null) continue;
                                int[] randoms = new[]
                                {
                                    random.Next(0, heaps[k].Workers.Count),
                                    random.Next(0, heaps[k].Warriors.Count),
                                    random.Next(0, heaps[k].Specials.Count)
                                };
                                if (heaps[k].Workers.Count != 0 && heaps[k].Workers[randoms[0]] is not null &&
                                    enemyIndex == 0)
                                {
                                    heaps[k].Specials[specialCount]
                                        .Fight(heaps[k].Workers[randoms[0]]);
                                    if (heaps[k].Workers[randoms[0]].HP <= 0)
                                    {
                                        int workerIndex = colonies[heaps[k].Workers[randoms[0]].Colony - 1]
                                            .Workers
                                            .IndexOf(heaps[k].Workers[randoms[0]]);
                                        if (workerIndex != -1)
                                        {
                                            colonies[heaps[k].Workers[randoms[0]].Colony - 1]
                                                .Workers
                                                .RemoveAt(workerIndex);
                                        }

                                        heaps[k].Workers[randoms[0]] = null;
                                    }
                                }

                                if (heaps[k].Warriors.Count != 0 && heaps[k].Warriors[randoms[1]] != null &&
                                    enemyIndex == 1)
                                {
                                    heaps[k].Specials[specialCount]
                                        .Fight(heaps[k].Warriors[randoms[1]]);
                                    if (heaps[k].Warriors[randoms[1]].HP <= 0)
                                    {
                                        int warroirIndex = colonies[heaps[k].Warriors[randoms[1]].Colony - 1]
                                            .Warriors
                                            .IndexOf(heaps[k].Warriors[randoms[1]]);
                                        if (warroirIndex != -1)
                                        {
                                            colonies[heaps[k].Warriors[randoms[1]].Colony - 1].Warriors
                                                .RemoveAt(warroirIndex);
                                        }

                                        heaps[k].Warriors[randoms[1]] = null;
                                    }
                                    else if (heaps[k].Specials[specialCount].HP <= 0)
                                    {
                                        int specialIndex = colonies[heaps[k].Specials[specialCount].Colony - 1]
                                            .Specials
                                            .IndexOf(heaps[k].Specials[specialCount]);
                                        if (specialIndex != -1)
                                        {
                                            colonies[heaps[k].Specials[specialCount].Colony - 1].Specials
                                                .RemoveAt(specialIndex);
                                        }

                                        heaps[k].Specials[specialCount] = null;
                                    }
                                }

                                if (heaps[k].Specials.Count == 0 || enemyIndex != 2) continue;
                                {
                                    if (heaps[k].Specials[randoms[2]] != null && heaps[k].Specials[randoms[2]] !=
                                        heaps[k].Specials[specialCount])
                                    {
                                        heaps[k].Specials[specialCount].Fight(
                                            heaps[k].Specials[randoms[2]]);
                                        if (heaps[k].Specials[randoms[2]].HP <= 0)
                                        {
                                            int warroirIndex = colonies[heaps[k].Specials[randoms[2]].Colony - 1]
                                                .Specials
                                                .IndexOf(heaps[k].Specials[randoms[2]]);
                                            if (warroirIndex != -1)
                                            {
                                                colonies[heaps[k].Specials[randoms[2]].Colony - 1].Specials
                                                    .RemoveAt(warroirIndex);
                                            }

                                            heaps[k].Specials[randoms[2]] = null;
                                        }
                                        else if (heaps[k].Specials[specialCount].HP <= 0)
                                        {
                                            int specialIndex =
                                                colonies[heaps[k].Specials[specialCount].Colony - 1]
                                                    .Specials
                                                    .IndexOf(heaps[k].Specials[specialCount]);
                                            if (specialIndex != -1)
                                            {
                                                colonies[heaps[k].Specials[specialCount].Colony - 1].Specials
                                                    .RemoveAt(specialIndex);
                                            }

                                            heaps[k].Specials[specialCount] = null;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // взять ресурсы
                    for (var h = 0; h < heaps.Length; h++)
                    {
                        foreach (var w in heaps[h].Workers)
                        {
                            if (w is null || w.Count == 0 || w.aphid) continue;
                            int safe = w.Count;
                            // веточка
                            if (heaps[h].Branch >= w.Branch && safe > 0)
                            {
                                heaps[h].Branch -= w.Branch;
                                w.Count -=
                                    w.Branch;
                                int resource = w.Branch;
                                colonies[w.Colony - 1].Branch(resource);
                            }

                            // листик
                            if (heaps[h].Leaf >= w.Leaf && safe > 0)
                            {
                                heaps[h].Leaf -= w.Leaf;
                                w.Count -=
                                    w.Leaf;
                                int resource = w.Leaf;
                                colonies[w.Colony - 1].Leaf(resource);
                            }

                            // камушек
                            if (heaps[h].Stone >= w.Stone && safe > 0)
                            {
                                heaps[h].Stone -= w.Stone;
                                w.Count -=
                                    w.Stone;
                                int resource = w.Stone;
                                colonies[w.Colony - 1].Stone(resource);
                            }

                            // росинка
                            if (heaps[h].Water >= w.Water && safe > 0)
                            {
                                heaps[h].Water -= w.Water;
                                w.Count -=
                                    w.Water;
                                int resource = w.Water;
                                colonies[w.Colony - 1].Water(resource);
                            }

                            w.Count = safe;
                        }
                        foreach (var s in heaps[h].Specials)
                        {
                            if (s is null || s.Count == 0 || s.aphid) continue;
                            int safe = s.Count;
                            // веточка
                            if (heaps[h].Branch >= s.Branch && safe > 0)
                            {
                                heaps[h].Branch -= s.Branch;
                                s.Count -=
                                    s.Branch;
                                int resource = s.Branch;
                                colonies[s.Colony - 1].Branch(resource);
                            }

                            // листик
                            if (heaps[h].Leaf >= s.Leaf && safe > 0)
                            {
                                heaps[h].Leaf -= s.Leaf;
                                s.Count -=
                                    s.Leaf;
                                int resource = s.Leaf;
                                colonies[s.Colony - 1].Leaf(resource);
                            }

                            // камушек
                            if (heaps[h].Stone >= s.Stone && safe > 0)
                            {
                                heaps[h].Stone -= s.Stone;
                                s.Count -=
                                    s.Stone;
                                int resource = s.Stone;
                                colonies[s.Colony - 1].Stone(resource);
                            }

                            // росинка
                            if (heaps[h].Water >= s.Water && safe > 0)
                            {
                                heaps[h].Water -= s.Water;
                                s.Count -=
                                    s.Water;
                                int resource = s.Water;
                                colonies[s.Colony - 1].Water(resource);
                            }

                            s.Count = safe;
                        }
                    }


                    foreach (var colony in colonies)
                    {
                        colony.Queen.Grow(colony, repWorkers, repWarriors, repSpecials);
                    }

                    Reproduction(colonies, colonies.Count, repWorkers, repWarriors, repSpecials);

                    Console.WriteLine("============== END OF THE DAY {0}===============", i + 1);
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
                    return;
                }

                else
                {
                    Console.WriteLine("{0}: command not found", comand);
                }

                i++;
            }

            Winner(colonies);
        }

        static void Winner(List<Colony> colonies)
        {
            int resources = 0;
            int currResources = 0;
            string colonyName = "";
            foreach (var colony in colonies)
            {
                currResources += colony.branch;
                currResources += colony.leaf;
                currResources += colony.stone;
                currResources += colony.water;

                if (currResources >= resources)
                {
                    resources = currResources;
                    currResources = 0;
                    colonyName = colony.Name;
                }
            }

            Console.WriteLine($"Победила колония {colonyName} с общим колиеством ресурсов {resources}");
        }

        static void Reproduction(List<Colony> colonies, int count, Worker[] workers, Warrior[] warriors,
            Special[] specials)
        {
            Random random = new Random();
            for (int colony = 0; colony < count; colony++)
            {
                if (colonies[colony].SubColony) continue;
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
                        new int[] {random.Next(3, 18), random.Next(2, 10), random.Next(0, 2)}, true));
                    count += 1;
                    AddAnts(colonies[^1], random, count, workers, warriors, specials);
                    colonies[colony].Queen.Count = 0;
                    colonies[colony].Queen.QueenDoughter[0]++;
                }
            }
        }

        static void AddAnts(Colony colony, Random random, int colonyNum, Worker[] workers, Warrior[] warriors,
            Special[] specials)
        {
            for (int worker = 0; worker < colony.Population![0]; worker++)
            {
                colony.Workers.Add(
                    (Worker) workers[random.Next(0, workers.Length)].Clone());
                colony.Workers[worker].Colony = colonyNum;
            }

            for (int warrior = 0; warrior < colony.Population[1]; warrior++)
            {
                colony.Warriors.Add((Warrior) warriors[random.Next(0, warriors.Length)]
                    .Clone());
                colony.Warriors[warrior].Colony = colonyNum;
            }

            for (int special = 0; special < colony.Population[2]; special++)
            {
                colony.Specials.Add((Special) specials[random.Next(0, specials.Length)]
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

            public void Grow(Colony colony, Worker[] workers, Warrior[] warriors, Special[] specials)
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
                                (Worker) workers[random.Next(0, workers.Length)].Clone());
                            colony.Workers[^1].Colony = this.Colony;
                        }
                        else if (type == 1)
                        {
                            colony.Warriors.Add(
                                (Warrior) warriors[random.Next(0, warriors.Length)].Clone());
                            colony.Warriors[^1].Colony = this.Colony;
                        }
                        else if (type == 2)
                        {
                            colony.Specials.Add((Special) specials[random.Next(0, specials.Length)]
                                .Clone());
                            colony.Specials[^1].Colony = this.Colony;
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
                int hp = 1, int armor = 0, int damage = 0, List<string>? bonus = null) : base(colony, tags,
                damage: damage, armor: armor, hp: hp, bonus: bonus)
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

            public void Fight(Worker worker, bool groupIgnoreEffects = false)
            {
                if (this.aphid || worker.Colony == Colony && Bad != 1) return;
                if (Bonus is not null && Bonus.Contains("игнорирует защиту"))
                {
                    worker.HP -= Damage;
                }
                else
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
                }
            }

            public void Fight(Warrior? warrior, bool groupIgnoreEffects = false)
            {
                if (this.aphid || warrior is null) return;
                if (warrior.Colony != Colony || Bad == 1)
                {
                    if (Bonus is not null && Bonus.Contains("игнорирует защиту"))
                    {
                        warrior.HP -= Damage;
                    }
                    else
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
                    }
                }

                if ((warrior.HP <= 0 && (warrior.Bonus is null || !warrior.Bonus.Contains("всегда наносит укус"))) ||
                    (warrior.Colony == Colony && warrior.Bad != 1) || warrior.aphid) return;
                if (warrior.Bonus is not null && warrior.Bonus.Contains("игнорирует защиту"))
                {
                    HP -= warrior.Damage;
                }
                else
                {
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

            public void Fight(Special? special, bool groupIgnoreEffects = false)
            {
                if (this.aphid || special is null) return;
                if (special.Colony != Colony || Bad == 1)
                {
                    if (!special.Bonus!.Contains("не может быть атакован войнами") ||
                        special.Bonus!.Contains("игнорирует защиту"))
                    {
                        if (Bonus is not null && Bonus.Contains("игнорирует защиту"))
                        {
                            special.HP -= Damage;
                        }
                        else
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

                if (special.Colony == Colony || special.aphid) return;
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
                target, attackNum, hp, armor, damage, bonus: bonus)
            {
                Leaf = leaf;
                Branch = branch;
                Stone = stone;
                Water = water;
                Count = count;
            }
        }

        class Colony
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
                            if (warrior1.Bonus is not null)
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
                            if (special.Bonus is not null)
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
            public List<Warrior?> Warriors;
            public List<Worker?> Workers;
            public List<Special?> Specials;
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
                Workers = new List<Worker?>();
                Warriors = new List<Warrior?>();
                Specials = new List<Special?>();
            }
        }
    }
}
using CodeFirst_Revize.Data;

anamenu:
Console.WriteLine("*** YAPILACAKLAR ***");
using (var db = new UygulamaDbContext())
{
    foreach (Gorev gorev in db.Gorevler.OrderBy(g => g.Yapildi))
    {
        string durum = gorev.Yapildi ? "[x]" : "[ ]";
        Console.WriteLine($"{durum} {gorev.Id,2} {gorev.Baslik}");
    }
}

Console.WriteLine(@"
1. G�rev Ekle
2. G�revi 'Yap�ld�' Olarak ��aretle
3. G�revi 'Yap�lmad�' Olarak ��aretle
4. G�revi Sil
");

Console.Write("Yapaca��n�z i�lemin nosunu giriniz: ");
string tercih = Console.ReadLine();

if (tercih == "1")
{
    Console.Write("Yeni G�rev: ");
    string baslik = Console.ReadLine();

    using (var db = new UygulamaDbContext())
    {
        Gorev gorev = new Gorev() { Baslik = baslik };
        db.Gorevler.Add(gorev);
        db.SaveChanges();

        MesajGoster("Yeni g�rev ba�ar�yla eklendi.");
        goto anamenu;
    }
}
else if (tercih == "2")
{
    Console.Write("Yap�ld� olarak i�aretlenecek g�revin nosu: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var db = new UygulamaDbContext())
    {
        Gorev? gorev = db.Gorevler.Find(id);

        if (gorev == null)
        {
            MesajGoster("Belirtti�iniz no ile ili�kili bir g�rev bulunamad�.");
            goto anamenu;
        }

        gorev.Yapildi = true;
        db.SaveChanges();

        MesajGoster("Belirtti�iniz g�rev ba�ar�yla g�ncellendi.");
        goto anamenu;
    }
}
else if (tercih == "3")
{
    Console.Write("Yap�lmad� olarak i�aretlenecek g�revin nosu: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var db = new UygulamaDbContext())
    {
        Gorev? gorev = db.Gorevler.Find(id);

        if (gorev == null)
        {
            MesajGoster("Belirtti�iniz no ile ili�kili bir g�rev bulunamad�.");
            goto anamenu;
        }

        gorev.Yapildi = false;
        db.SaveChanges();

        MesajGoster("Belirtti�iniz g�rev ba�ar�yla g�ncellendi.");
        goto anamenu;
    }
}
else if (tercih == "4")
{
    Console.Write("Silinecek G�revin Nosu: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var db = new UygulamaDbContext())
    {
        Gorev? gorev = db.Gorevler.Find(id);

        if (gorev == null)
        {
            MesajGoster("Belirtti�iniz no ile ili�kili bir g�rev bulunamad�.");
            goto anamenu;
        }

        db.Gorevler.Remove(gorev);
        db.SaveChanges();

        MesajGoster("Belirtti�iniz g�rev ba�ar�yla silindi.");
        goto anamenu;
    }
}
else
{
    Console.WriteLine("Ge�ersiz se�im!");
}

Console.ReadKey();

void MesajGoster(string mesaj)
{
    Console.Clear();
    Console.WriteLine("### " + mesaj + " ###");
    Console.WriteLine();
}
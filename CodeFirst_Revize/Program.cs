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
1. Görev Ekle
2. Görevi 'Yapýldý' Olarak Ýþaretle
3. Görevi 'Yapýlmadý' Olarak Ýþaretle
4. Görevi Sil
");

Console.Write("Yapacaðýnýz iþlemin nosunu giriniz: ");
string tercih = Console.ReadLine();

if (tercih == "1")
{
    Console.Write("Yeni Görev: ");
    string baslik = Console.ReadLine();

    using (var db = new UygulamaDbContext())
    {
        Gorev gorev = new Gorev() { Baslik = baslik };
        db.Gorevler.Add(gorev);
        db.SaveChanges();

        MesajGoster("Yeni görev baþarýyla eklendi.");
        goto anamenu;
    }
}
else if (tercih == "2")
{
    Console.Write("Yapýldý olarak iþaretlenecek görevin nosu: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var db = new UygulamaDbContext())
    {
        Gorev? gorev = db.Gorevler.Find(id);

        if (gorev == null)
        {
            MesajGoster("Belirttiðiniz no ile iliþkili bir görev bulunamadý.");
            goto anamenu;
        }

        gorev.Yapildi = true;
        db.SaveChanges();

        MesajGoster("Belirttiðiniz görev baþarýyla güncellendi.");
        goto anamenu;
    }
}
else if (tercih == "3")
{
    Console.Write("Yapýlmadý olarak iþaretlenecek görevin nosu: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var db = new UygulamaDbContext())
    {
        Gorev? gorev = db.Gorevler.Find(id);

        if (gorev == null)
        {
            MesajGoster("Belirttiðiniz no ile iliþkili bir görev bulunamadý.");
            goto anamenu;
        }

        gorev.Yapildi = false;
        db.SaveChanges();

        MesajGoster("Belirttiðiniz görev baþarýyla güncellendi.");
        goto anamenu;
    }
}
else if (tercih == "4")
{
    Console.Write("Silinecek Görevin Nosu: ");
    int id = Convert.ToInt32(Console.ReadLine());

    using (var db = new UygulamaDbContext())
    {
        Gorev? gorev = db.Gorevler.Find(id);

        if (gorev == null)
        {
            MesajGoster("Belirttiðiniz no ile iliþkili bir görev bulunamadý.");
            goto anamenu;
        }

        db.Gorevler.Remove(gorev);
        db.SaveChanges();

        MesajGoster("Belirttiðiniz görev baþarýyla silindi.");
        goto anamenu;
    }
}
else
{
    Console.WriteLine("Geçersiz seçim!");
}

Console.ReadKey();

void MesajGoster(string mesaj)
{
    Console.Clear();
    Console.WriteLine("### " + mesaj + " ###");
    Console.WriteLine();
}
// See https://aka.ms/new-console-template for more information
using berek11_19;
using System.Text;

//1.Készítsen grafikus vagy konzolalkalmazást (projektet) a következő feladatok megoldásához, amelynek projektjét berek2020 néven mentse el!
Console.WriteLine("1.feladat");
Console.WriteLine("nekem most nem berek2020 hanem az ami\n");

//2. Olvassa be a berek2020.txt állomány sorait és tárolja az adatokat egy olyan összetett adatszerkezetben, amely használatával a további feladatok megoldhatók! Ügyeljen arra, hogy az állomány első sora az adatok fejlécét tartalmazza!
Console.WriteLine("2.feladat");
List<Ber> berek = new();
using StreamReader sr = new(
    path: @"..\..\..\src\berek2020.txt",
    encoding: Encoding.UTF8);
sr.ReadLine();
while(!sr.EndOfStream)
{
    berek.Add(new Ber(sr.ReadLine()));
}
sr.Close();
Console.WriteLine("kész!\n");

//3. Határozza meg és írja ki a képernyőre, hogy hány dolgozó adatai találhatók a forrásállományban!
Console.WriteLine("3.feladat");
Console.WriteLine($"összesen {berek.Count} dolgozó adat van\n");

//4. Határozza meg és írja ki a képernyőre a 2020-as átlagbéreket! Az eredményt ezer forintban, egy tizedesjegyre kerekítve jelenítse meg!
Console.WriteLine("4.feladat");
var atlag = berek.Average(x => x.Fizetes) / 1000;
Console.WriteLine($"2020-as átlagbérek: {atlag:F1} ezer forint\n");

//5. Kérje be egy részleg nevét a felhasználótól a minta szerint!
Console.WriteLine("5.feladat");
Console.Write("írj be egy részlet nevét: ");
string reszletNev = Console.ReadLine().ToLower();



//6. Az előző feladatban megadott részlegen keresse meg és írja ki a legnagyobb bérrel (fizetéssel) rendelkező dolgozó adatait! Ha a megadott részleg nem létezik a cégnél, akkor a „A megadott részleg nem létezik a cégnél!” feliratot jelenítse meg! Feltételezheti, hogy nem alakult ki „holtverseny” egy-egy részlegen dolgozók fizetése között!
Console.WriteLine("6.feladat");
var legnagyobb = berek.Where(x => x.Reszlet.ToLower().Contains(reszletNev.ToLower())).OrderByDescending(x => x.Fizetes).FirstOrDefault();

if (legnagyobb != null)
{
    Console.WriteLine($"név: {legnagyobb.Nev}, fizetés: {legnagyobb.Fizetes}, részleg: {legnagyobb.Reszlet}");
}
else
{
    Console.WriteLine("Ilyen részleg nincs");
}



//7. Készítsen statisztikát az egyes részlegeken dolgozók számáról! A részlegek kiírásának sorrendje tetszőleges!
Console.WriteLine("\n7.feladat");
var stat = berek.GroupBy(x => x.Reszlet).Select(x => new { Reszleg = x.Key, DolgozokSzama = x.Count() });

foreach (var item in stat)
{
    Console.WriteLine($"\t{item.Reszleg}: {item.DolgozokSzama} fő");
}


Console.WriteLine("\nA feleadattal kész lettem 38 perc alatt");
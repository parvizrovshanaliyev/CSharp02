using System;
using System.Collections;

#region collections
/*
 * Array ve Collection arasindaki ferq nelerdir?
 *
 * Bu level ucun oyreneceyimiz colection-lar deyer olaraq object tipinden
 * deyerleri  qebul etdikleri ucun(dezavantajlardan biri)  ve . net framework strukturunda
 * butun classlar object classindan inheritance(qabaqki derslerde danisacayiq) aldigi ucun butun data typelari
 * qebul ede bilecek mexanizme sahibdirler.
 *
 * Collectionlarda Array-de oldugu kimi her hansisa serhed yoxdur.
 *
 * Collectionlarda teyin olunan yer/serhed doldugu zaman avtomatik olaraq
 * icerisindeki movcud yeri artira bilirler.
 *
 * Generic movzusundan sonra Generic Collectionlari goreceyik.
 *
 * Collection-larin avantajlari :
 * eyni ve ferqli tiplerde deyerleri bir yerde
 * saxlayib istifade ede bilmeyimiz.
 *
 * Array-lerde uzunluq mecburi sekilde qeyd edilerken , collection
 * dinamikdir.
 *
 * Collection-a element elave etdikce capacity dinamik olaraq artirilir,
 * Ram-daki yere gore
 *
 *
 * Collection icindeki elementlere foreach(iterator) ile cata bilerik,
 * bunun sebebi Collection-larin IEnumerable interface-ni implement etmesinden
 * qaynaqlanir,
 * burdanda bu neticeye gelmek olarki, her collection base obyektlerimiz
 * IEnumerable(OOP-derslerimizde bu movzuya geri qayidacagig helelik oxuyub kecin) interface-ni implement etmekdedir.
 *
 * https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.arraylist?view=netframework-4.8
 *
 */

#region arrayList
/*
 *
 */
//string[] values = new string[10];
//ArrayList a = new ArrayList();

#region add
/*
 * object tipinde qebul etdiyi ucun ferqli tipleri add ede bilirik,
 * yalniz bir deyer daxil eden zaman
 */
//ArrayList arrList = new ArrayList();
//arrList.Add(1);
//arrList.Add(2);
//arrList.Add(3);
//arrList.Add(4);
#endregion

#region addRange
/*
 * eyni anda birden cox deyerin ArrayListe daxil edilmesi
 */
//ArrayList arrlist = new ArrayList();
//arrlist.Add(1);

//foreach (var item in arrlist)
//{
//    arrlist.Add(2);
//}
// addrange

//ArrayList arrlist2 = new ArrayList();
//arrlist2.Add(1);
//arrlist2.Add(2);

//arrlist.AddRange(arrlist2);
#endregion

#region capacity,Count
/*
 * Capacity collection-nin ala bileceyi maksimum deyeri ifade edir.
 * Count hazirda icerisindeki element sayini ifade edir.
 *
 * Collectiona yaranan zaman bunlar ikiside 0 olaraq teyin edilir,
 * Lakin collectiona bir deyer menimseden zaman Count 1 ,
 * Capacity 4 olaraq deyismektedir.
 *
 * her defe yeni element daxil edilerken belece capacity artmaqdadir.
 * ArrayList-den evvel bunu elmizle etmeli idik sonrada net framework bele bir
 * struktur yaratdi ve arraye nisebeten cox istifade oluna veziyyete geldi,
 * hazirki zaman ucun arrayListlerde GenericCollectionlara nisbetde az istifade
 * edilir.
 */

//int capacity = 0;
//int count = 0;

#endregion

#region arrayListden deyerini oxuma ve deyisdirme
/*
 * Array strukturunu basa dusulmesi onemlidir, cunki
 * ArrayListde-de indexer dediyimiz operator ile istenilen indexdeki
 * elementin deyerini oxuya bilerik.
 */
//ArrayList arrList = new ArrayList();
//arrList.Add("Ferid");
////arrList[0] = 1;
//object obj = arrList[0];

//string name = arrList[0].ToString();


#endregion

#region deyerin silinmesi

//// Remove uygun deyere sahib elementi silir
//ArrayList arrList = new ArrayList();
//arrList.Add("Ferid");

//arrList.Remove("Ferid");
//// removeRange
///*
// * Remove range bizden basyacagi Index-i ve silinecek element sayini
// * isteyir.
// */
//arrList.Add("Kamran");
//arrList.Add("Resad");
//arrList.RemoveRange(0,1);

//// removeAt
///*
// * uygun idexe sahib elementi silir.
// */
//arrList.RemoveAt(0);
//arrList.Clear();

//// clear methodundan istifade zamani capacity 0lanmir bu methodala capacity 0-laya bilersiz .
/// 
//arrList.TrimToSize();
/*
 * Clear collection icerisindeki deyerleri silir.
 *
 */

/*
 * Clear metodu ile elementler silinse bele capacity deyismeden oldugu kimi
 * qalmaqdadir.
 *
 */
#endregion

#region siralama
/*
 * A-Z siralama // Sort
 * qeyd: sort-la siralayan zaman meselen stringler icersinde birdene
 * int tipinde elementiniz varsa size xeta verecek.
 * Reverse tersine cevirme // Reverse
 */
//ArrayList names = new ArrayList();
//names.Add("Elcan");
//names.Add("Kamran");
//names.Add("Resad");
//names.Add(1);
//names.Add(true);
//names.Sort();

#endregion

#region helpers commands
/*
 * deyerin collectionda olub olmamasini yoxlaya bilerik ve geriye bool deyer
 * qaytarir.
 */
//ArrayList names = new ArrayList();
//names.Add("Elcan");
//names.Add("Kamran");
//names.Add("Resad");
//names.Add(1);
//names.Add(true);
//names.Sort();

//bool result = names.Contains("Elcan");
//if (names[0] is "Ferid")
//{

//}
/*
 * IndexOf
 * uygun deyere sahib elementin index qarsiligini verir.
 */
//var nameIndex = names.IndexOf("Elcan");

//if (names.Contains("Kamran"))
//{
//    var index1 = names.IndexOf("Kamran");
//    names.RemoveAt(index1);
//}

#endregion

#region toArray

//object[] objects = names.ToArray();

#endregion

#region example 10 elementli array listi z-a-ya siralayin

//ArrayList names = new ArrayList();

//names.Add("Parviz");
//names.Add("Kamran");
//names.Add("Avaz");
//names.Add("Zaur");
//names.Add("Elcan");
//names.Add("Ferid");

//names.Sort(); // a-z
//names.Reverse(); // z-a

#endregion
#endregion

#region hashTable
/*
 * HashTable bir cox xususiyyetine gore array liste oxsayir,
 * amma arrayList-de index value pair , hashTable-da key value pair-dir.
 * Hashtable-da daxil edilen key-ler unique olmalidir, eger olmazsa xeta verecek.
 *
 */

#region yeni deyer elave edilmesi

//Hashtable h1 = new Hashtable();

//h1.Add("Car", "Masin");
//h1.Add("Key", "Acar");


#endregion

#region helper methods

#region Contains
/*
 * Arraylistde Contains-le deyere gore yoxlama aparilarken hashtableda
 * key-deyerine gore yoxlama aparilmaqdadir.
 */
//Hashtable h1 = new Hashtable();

//h1.Add("Car", "Masin");
//h1.Add("Key", "Acar");

//bool result1 = h1.Contains("Car");
//bool result2 = h1.ContainsKey("Car");
//bool result3 = h1.ContainsValue("Masin");

#endregion

#region Clear collection icersindeki elementleri silir



#endregion

#region CopyTo




#endregion

#region Remove

/*
 * keye uygun gelen deyerin silinmesi
 */
Hashtable h2 = new Hashtable();

h2.Remove("Car");
#endregion

#region update

//Hashtable h3 = new Hashtable();
//h3.Add("Old", "kohne data");
////
//h3["Old"] = "Yeni data";
#endregion

#endregion

#region example

#region mini luget hazirlayin.
/*
 * Ingilis-Azerbaycan mini luget hazirlayin.
 *
 * Lugete yeni soz elave etmek isteyirsinizmi? b/x (beli/xeyr)
 *
 * Beli cavabinda yeni soz elave edilir.
 * Istifadeci once Ingilis dilinde sozu daxil edir,
 * Sozun Lugetde olub olmamasi yoxlanilir,
 * Yoxdursa Bu sefer sozun Azerbaycan dilinde qarsiligini daxil edir.
 * Xeyr cavabinda elave edilmis sozlerin hamisi istifadeciye gosterilir.
 *
 */
//Hashtable vocabulary = new Hashtable();

//#region 1

//do
//{
//    Console.Clear();

//    Console.WriteLine("Lugete elave etmek ucun deyeri daxil edin");
//    Console.Write("En:\t");
//    string wordEN = Console.ReadLine();

//    if (vocabulary.Contains(wordEN))
//    {
//        Console.WriteLine("Daxil edilen {0} deyeri lugetde movcuddur {0} qarsiligi {1}, ferqli deyer daxil edin", wordEN, wordEN, vocabulary[wordEN]);

//    }
//    else
//    {
//        Console.WriteLine("{0} deyerinin qarsiligini daxil edin", wordEN);
//        Console.Write("AZ:\t");
//        string wordAZ = Console.ReadLine();
//        vocabulary.Add(wordEN, wordAZ);
//        Console.WriteLine("Elave edildi");


//    }
//    Console.Write("Lugete yeni soz elave etmek isteyirsinizmi? b/x (beli/xeyr):\t");
//    Console.ReadLine();


//} while (Console.ReadLine().ToUpper() != "X");

////1
//foreach (var item in vocabulary.Keys)
//{
//    Console.WriteLine("EN: {0} : AZ: {1}", item, vocabulary[item]);
//}

////2. item.GetType().Name
//foreach (DictionaryEntry item in vocabulary)
//{
//    Console.WriteLine("EN: {0} : AZ: {1}", item.Key, item.Value);
//}
#endregion


#endregion

#endregion

#region sortedList
/*
 * SortedList-de(sl) HasTable kimi key value pair mexanizmi ile isleyir,
 * ferqi sl key deyrlerini a-z ye olacaq sekilde siralayir,
 * bunun ucunde key deyerleri eyni tipde olmalidir,
 * meselen string keyler olan liste int tipinde deyer sahib key yerlesdirsez siralama
 * zamani bize xeta verecek.
 *
 * Kicik olculu isler datalarla isleyerken serferli olsa bele
 * Boyuk datalar uzerinde performasi daha asagidir.
 */
//SortedList sortedList = new SortedList();
//sortedList.Add(100, "a");
//sortedList.Add(40, "b");
//sortedList.Add(95, "c");
////sortedList.Add("form", "form");

//foreach (DictionaryEntry item in sortedList)
//{
//    Console.WriteLine("{0} {1}",item.Key,item.Value);
//}

#endregion

//ArrayList arr = new ArrayList();
//arr.Sort();

#region Stack
/*
 * Stack-de diger oyrendiyimiz collectionlar kimi collection base classlardan biridir.
 * Stack LIFO(Last In First Out) mentiqi ile isleyir.
 * ICollection, IEnumerable, ICloneable interface-lerini implement edir.
 *
 *
 * https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.stack?view=netframework-4.8
 */
// default olaraq capacity 10 teyin edilir.
//Stack myStack = new Stack();

//// ICollection implement eden her hansi sinifden stack collection yaradilir
//myStack = new Stack(new ArrayList());

//// eger capacity yeterli olmazsa 2 qat artirilir.
//myStack = new Stack(10);
//var myStackCount = myStack.Count;

#region methods

#region push(Object)
/*
 * bu method collection-a yeni bir element elave etmeyimize imkan verir.
 */
//myStack.Push(2);
//myStack.Push(3);


#endregion
#region pop()
/*
 * bu method collection-a elave edilen en son elementin deyerini bize verir,
 * ve hemin elementi collection-dan xaric edir.
 *
 */
//var elem= myStack.Pop();

#endregion
#region peek()
/*
 *bu method collection-nin son elementini bize verir ancaq collectiondan silmir.
 */
//var elem2 = myStack.Peek();

//var count = myStack.Count;
#endregion
#region clear



#endregion
#region contains



#endregion
#region toArray



#endregion
#region clone



#endregion

#region getEnumerator
//Stack myStack = new Stack();
//myStack.Push(10);
//myStack.Push(20);
//myStack.Push(30);

//IEnumerator enumerator = myStack.GetEnumerator();
//while (enumerator.MoveNext())
//{
//    Console.WriteLine(enumerator.Current);
//}


#endregion
#endregion

#region foreach

//foreach (var item in myStack)
//{
//    Console.WriteLine(item);
//}

#endregion
#endregion

#region Queue
/*
 * Sira/Quyruq - First In First Out
 *
 * https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.queue?view=netframework-4.8
 */
//Queue myQueue = new Queue();

//myQueue = new Queue(10);

#region Dequeue() == stack-deki pop()
/*
 * siranin ilk elementini verir ve onu siradan silir.
 *
 * Eger queue-da element yoxdursa bu methodun istifadesi zamani
 * InvalidOperationException() xetasi alacagiq.
 */

#endregion
#region Enqueue(Object) == stackdeki push()
/*
 * siranin sonuna yeni element elave edir
 */


#endregion
#region Peek()
/*
 * siradaki ilk elementi verir lakin onu siradan silmir
 */


#endregion


#endregion
#endregion





